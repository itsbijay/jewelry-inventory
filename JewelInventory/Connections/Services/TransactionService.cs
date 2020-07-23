using System;
using System.Linq;
using JetCoders.Shared;

namespace Connections
{
    public class TransactionService : ServiceBase, ITransactionService
    {
        private readonly IConfigurationService _configurationService;

        public TransactionService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public IQueryable<TransactionInvoices> GetJewelTransactionInvoices()
        {
            return DbContext.TransactionInvoices;
        }

        public IQueryable<CreditNote> GetCreditNotes()
        {
            return DbContext.CreditNotes;
        }

        public IQueryable<JewelStockLedger> GetJewelStockLedgers()
        {
            return DbContext.JewelStockLedgers;
        }

        public IQueryable<JewelTransaction> GetJewelTransactions()
        {
            return DbContext.JewelTransactions;
        }

        public IQueryable<TransactionLookup> GetJewelTransactionsLookUp(TransactionType type)
        {
            return DbContext.TransactionLookups.Where(x => x.TransactionType_Enum == (Int32)type);
        }

        public IQueryable<TransactionLookup> GetJewelTransactionsLookUp()
        {
            return DbContext.TransactionLookups;
        }

        public TransactionLookup GetJewelTransactionsLookUpById(int lookUpId)
        {
            return DbContext.TransactionLookups.Single(x => x.TransactionLookupId == lookUpId);
        }

        public JewelTransaction GetJewelTransactionsById(int id)
        {
            return DbContext.JewelTransactions.SingleOrDefault(x => x.JewelTransactionId == id);
        }

        public JewelTransaction GetJewelTransactionsByJewelNo(string jewelNo)
        {
            return DbContext.JewelTransactions.
                        SingleOrDefault(x => x.JewelNumber == jewelNo && x.UpdatedTransactionBy == null);
        }

        public JewelStockLedger GetJewelStockByJewelNo(string jewelNo)
        {
            return DbContext.JewelStockLedgers.SingleOrDefault(x => x.JewelNumber == jewelNo);
        }

        public JewelTransactionResponse CreateJewelTransaction(JewelTransactionRequest request)
        {
            Logger.Debug("CreateJewelTransaction(): ----- Start Creating transaction --- ");

            var response = new JewelTransactionResponse();

            var lookup = request.TransactionLookup;
            var finYrCode = _configurationService.GetFinancialYearCode(lookup.TransactionDate);
            if (finYrCode.IsEmpty())
                response.AddValidationError("FinancialYearMasters", "Financial Year is not active for transaction date " + lookup.TransactionDate.ToShortDateString());

            if (!lookup.JewelTransactions.Any())
                response.AddValidationError("JewelTransactions", "Jewel Transactions is not available.");

            if (response.IsValid == false)
                return response;

            // Get next instance id
            var nexttrn = DbContext.JewelTransactions.Max(x => (int?)x.JewelTransactionId) ?? 0;
            var nextlookup = DbContext.TransactionLookups.Max(x => (int?)x.TransactionLookupId) ?? 0;

            switch (lookup.TransactionType)
            {
                case TransactionType.PurchaseTransaction:
                    SetMemoFormat(lookup, nextlookup, Constants.PURCHASE_MEMOFORMAT);
                    break;
                case TransactionType.ApprovalTransaction:
                    SetMemoFormat(lookup, nextlookup, Constants.APPROVAL_MEMOFORMAT);
                    break;
                case TransactionType.MarketingTransaction:
                    SetMemoFormat(lookup, nextlookup, Constants.MARKETING_MEMOFORMAT);
                    break;
                case TransactionType.MarketingInReturnTransaction:
                    SetMemoFormat(lookup, nextlookup, Constants.MARKETING_RETURN_MEMOFORMAT);
                    break;
                case TransactionType.ApprovalInReturnTransaction:
                    SetMemoFormat(lookup, nextlookup, Constants.APPROVAL_RETURN_MEMOFORMAT);
                    break;
                case TransactionType.SalesInTransaction:
                    SetMemoFormat(lookup, nextlookup, Constants.SALES_MEMOFORMAT);
                    break;
                case TransactionType.SalesInReturnTransaction:
                    SetMemoFormat(lookup, nextlookup, Constants.SALES_RETURN_MEMOFORMAT);
                    break;
            }

            lookup.FinancialYearCode = finYrCode;
            lookup.JewelTransactions.ToList().ForEach(tran =>
            {
                tran.TransactionType = lookup.TransactionType;
                tran.TransactionDate = lookup.TransactionDate;
                tran.AccessedDate = DateTime.Now;
                tran.AccessedBy = LocalStore.CurrentUser.UserId;

                tran.CostingDetail.AccessedDate = DateTime.Now;
                tran.CostingDetail.AccessedBy = LocalStore.CurrentUser.UserId;

                if (lookup.TransactionType == TransactionType.PurchaseTransaction)
                {
                    tran.Properties.ItemDetails.JewelNumber = String.Concat(Constants.TRANSACTIONPREFIX, ++nexttrn);
                    tran.JewelNumber = String.Concat(Constants.TRANSACTIONPREFIX, nexttrn);

                    var ledgers = new JewelStockLedger
                    {
                        JewelNumber = tran.JewelNumber,
                        DesignCode = tran.DesignCode,
                        CertificateNumber = tran.CertificateNumber,
                        MetalColor = tran.MetalColor,
                        TotalWeight = tran.TotalWeight,
                        MetalWeight = tran.MetalWeight,
                        KT = tran.KT,
                        JewelType = tran.JewelType,
                        StoneWeight = tran.StoneWeight,
                        StonePcs = tran.StonePcs,
                        CStonePcs = tran.CStonePcs,
                        CStoneWeight = tran.CStoneWeight,
                        JewelItemCategory = tran.JewelItemCategory,
                        StockStatus = StockStatus.ItemIsInStock,
                        TransactionDate = tran.TransactionDate,
                        AccessedDate = DateTime.Now,
                        AccessedBy = tran.AccessedBy
                    };

                    // Add JewelStockLedgers
                    DbContext.JewelStockLedgers.AddObject(ledgers);
                }
                var ledgerItem = GetJewelStockByJewelNo(tran.JewelNumber);

                var _totalAmt = lookup.JewelTransactions.Sum(x => x.TotalAmount);
                lookup.NetAmount = _totalAmt;

                switch (lookup.TransactionType)
                {
                    case TransactionType.ApprovalTransaction:
                        ledgerItem.StockStatus = StockStatus.ItemOutOfStock;
                        ledgerItem.JewelState = JewelState.OnApproval;
                        break;
                    case TransactionType.MarketingTransaction:
                        ledgerItem.StockStatus = StockStatus.ItemLockedInStock;
                        ledgerItem.JewelState = JewelState.OnMarketing;
                        break;
                    case TransactionType.MarketingInReturnTransaction:
                        ledgerItem.StockStatus = StockStatus.ItemIsInStock;
                        ledgerItem.JewelState = JewelState.NotSet;
                        break;
                    case TransactionType.CancelledTransaction:
                        ledgerItem.StockStatus = StockStatus.CancelledStock;
                        ledgerItem.JewelState = JewelState.NotSet;
                        break;
                    case TransactionType.ApprovalInReturnTransaction:
                        ledgerItem.StockStatus = StockStatus.ItemIsInStock;
                        ledgerItem.JewelState = JewelState.NotSet;
                        break;
                    case TransactionType.SalesInTransaction:
                        ledgerItem.StockStatus = StockStatus.ItemOutOfStock;
                        ledgerItem.JewelState = JewelState.OnSale;
                        // Tax Calculation
                        var firmMaster = DbContext.FirmMasters.Single();
                        lookup.Properties = new TransactionLookupDetail
                        {
                            TaxRate = firmMaster.Tax,
                            OtherTaxRate = firmMaster.OtherTax,
                            TaxAmount = (_totalAmt + _totalAmt * firmMaster.Tax / 100),
                            OtherTaxAmount = (_totalAmt + _totalAmt * firmMaster.OtherTax / 100),
                        };
                        lookup.NetAmount = lookup.Properties.TotalAmount;
                        break;
                    case TransactionType.SalesInReturnTransaction:
                        var invoice = DbContext.TransactionInvoices.Single(x => x.InvoiceNumber == lookup.ReferenceMemoNumber);
                        invoice.Cancelled = true;
                        ledgerItem.StockStatus = StockStatus.ItemIsInStock;
                        ledgerItem.JewelState = JewelState.NotSet;
                        break;
                }
            });

            lookup.AccessedDate = DateTime.Now;
            lookup.AccessedBy = LocalStore.CurrentUser.UserId;
            DbContext.TransactionLookups.AddObject(lookup);
            DbContext.SaveChanges();

            response.TransactionLookup = lookup;
            Logger.Debug("CreateJewelTransaction(): ----- transaction done --- ");
            return response;
        }

        private static void SetMemoFormat(TransactionLookup lookup, int nextlookup, string format)
        {
            lookup.MemoNumber = String.Format(String.Format(format, DateTime.UtcNow.Date), nextlookup);
        }

        public SalesTransactionResponse CreateSalesTransaction(SalesTransactionRequest request)
        {
            Logger.Debug("CreateSalesTransaction(): ----- Start Creating transaction --- ");
            var response = new SalesTransactionResponse();
            var invoice = request.TransactionInvoice;

            // Transaction Lookup
            var lookup = request.TransactionLookup;

            lookup.TransactionDate = invoice.InvoiceDate;
            lookup.TransactionType = TransactionType.SalesInTransaction;
            lookup.AccessedDate = DateTime.Now;
            lookup.AccessedBy = LocalStore.CurrentUser.UserId;

            var tranRequest = new JewelTransactionRequest { TransactionLookup = lookup };
            var lookupResponse = CreateJewelTransaction(tranRequest);

            if (lookupResponse.IsValid == false)
            {
                foreach (var err in lookupResponse.AllErrors)
                    response.AddValidationError(err.Key, err.Value);

                return response;
            }
            // TransactionInvoices
            invoice.InvoiceNumber = lookup.MemoNumber;
            invoice.AccessedDate = DateTime.Now;
            invoice.AccessedBy = LocalStore.CurrentUser.UserId;

            DbContext.TransactionInvoices.AddObject(invoice);

            DbContext.SaveChanges();
            Logger.Debug("CreateSalesTransaction(): ----- transaction done --- ");
            response.TransactionLookup = lookup;
            return response;
        }

        public void UpdateJewelDetail(JewelUpdateRequest request)
        {
            Logger.Debug("UpdateJewelDetail(): ----- Start Creating updation --- ");
            var ledger = GetJewelStockByJewelNo(request.JewelNumber);

            ledger.DesignCode = request.DesignCode;
            ledger.CertificateNumber = request.CertificateNumber;
            ledger.MetalColor = request.MetalColor;
            if (request.IsCancelled)
            {
                ledger.StockStatus = StockStatus.CancelledStock;
                ledger.JewelState = JewelState.NotSet;
            }
            ledger.AccessedDate = DateTime.Now;
            ledger.AccessedBy = LocalStore.CurrentUser.UserId;

            var trans = GetJewelTransactionsByJewelNo(request.JewelNumber);
            trans.DesignCode = request.DesignCode;
            trans.CertificateNumber = request.CertificateNumber;
            trans.MetalColor = request.MetalColor;

            if (request.IsCancelled)
                trans.TransactionType = TransactionType.CancelledTransaction;

            trans.AccessedDate = DateTime.Now;
            trans.AccessedBy = LocalStore.CurrentUser.UserId;

            DbContext.SaveChanges();
            Logger.Debug("CreateSalesTransaction(): updation done --- ");
        }

        public CreditNoteResponse CreateCreditNote(CreditNoteRequest request)
        {
            var creditNote = request.CreditNote;

            var response = new CreditNoteResponse();
            var finYrCode = _configurationService.GetFinancialYearCode(creditNote.TransactionDate);
            if (finYrCode.IsEmpty())
                response.AddValidationError("FinancialYearMasters", "Financial Year is not active for transaction date " + creditNote.TransactionDate.ToShortDateString());

            if (response.IsValid == false)
                return response;


            creditNote.AccessedDate = DateTime.Now;
            creditNote.AccessedBy = LocalStore.CurrentUser.UserId;

            if (creditNote.Id == 0)
                DbContext.CreditNotes.AddObject(creditNote);

            DbContext.SaveChanges();
            return response;
        }
    }
}

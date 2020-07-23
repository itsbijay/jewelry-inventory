using System;
using System.Linq;
using JetCoders.Shared;

namespace Connections
{
    public class ReportService : ServiceBase, IReportService
    {
        readonly IDataSetProvider _dataSetProvider;
        readonly IConfigurationService _configurationService;

        public ReportService(IConfigurationService configurationService, IDataSetProvider dataSetProvider)
        {
            _configurationService = configurationService;
            _dataSetProvider = dataSetProvider;
        }

        public TaxInvoiceReportResponse GetTransactionSumaryReport(TaxInvoiceReportRequest request)
        {
            var response = new TaxInvoiceReportResponse();

            var firmMaster = response.TaxInvoiceSummaryDataSet.Tables["FirmMaster"];
            var summary = response.TaxInvoiceSummaryDataSet.Tables["JewelSummary"];
            var otherInfo = response.TaxInvoiceSummaryDataSet.Tables["OtherInfo"];

            var transactionLookups = DbContext.TransactionLookups.Single(lookup => lookup.MemoNumber == request.TransactionNumber);

            var data = (from tran in transactionLookups.JewelTransactions
                        let lookup = DbContext.TransactionLookups.Single(x => x.MemoNumber == request.TransactionNumber)
                        let inv = DbContext.TransactionInvoices.SingleOrDefault(x => x.InvoiceNumber == request.TransactionNumber)
                        select new
                        {
                            Tax = inv != null ? inv.Tax : 0.0M,
                            OtherCharges = inv != null ? inv.OtherCharges : 0.0M,
                            PaymentTerm = inv != null ? inv.PaymentTerm : string.Empty,
                            lookup.MemoNumber,
                            lookup.TransactionPartyRef,
                            lookup.TransactionDate,
                            FinancialYearCode = _configurationService.GetFinancialYearCode(lookup.TransactionDate),
                            lookup.ContactName,
                            lookup.DocNumber,
                            lookup.Remarks,
                            tran.TotalAmount,
                            tran.KT,
                            tran.CertificateNumber,
                            tran.JewelType,
                            tran.JewelNumber,
                            tran.DesignCode,
                            tran.TotalWeight,
                            tran.MetalWeight,
                            tran.StoneWeight,
                            tran.StonePcs,
                            tran.CStonePcs,
                            tran.CStoneWeight,
                        }).ToList();

            if (data.Count == 0)
            {
                response.AddValidationError("NoDataFound", "No Tax Invoice found!");
            }

            if (response.IsValid == false)
                return response;

            var counter = 0;
            var dataGroup = (from g in data
                            group g by g.JewelType into s
                            select new
                            {
                                JewelDesc = s.Key,
                                GrWt = s.Sum(x => x.TotalWeight),
                                NetWt = s.Sum(x => x.StoneWeight),
                                Qty = s.Count(),
                                MetalKT = s.Any() ? s.First().KT : string.Empty,
                                DiaWt = s.Sum(x => x.StoneWeight),
                                DiaPcs = s.Sum(x => x.StonePcs),
                                ColStoneWt = s.Sum(x => x.CStoneWeight),
                                ColStonePcs = s.Sum(x => x.CStonePcs),
                                Amount = s.Sum(x => x.TotalAmount)
                            }).ToList();

            foreach (var item in dataGroup)
            {
                var invoicerow = summary.NewRow();

                invoicerow["SrNo"] = ++counter;
                invoicerow["JewelDesc"] = item.JewelDesc;
                invoicerow["GrWt"] = item.GrWt;
                invoicerow["NetWt"] = item.NetWt;
                invoicerow["Qty"] = item.Qty;
                invoicerow["MetalKT"] = item.MetalKT;
                invoicerow["DiaWt"] = item.DiaWt;
                invoicerow["DiaPcs"] = item.DiaPcs;
                invoicerow["ColStoneWt"] = item.ColStoneWt;
                invoicerow["ColStonePcs"] = item.ColStonePcs;
                invoicerow["Amount"] = item.Amount;

                summary.Rows.Add(invoicerow);
            }

            _dataSetProvider.GetFirmDataTable(firmMaster);

            var transactionInfo = data.First();

            var inforow = otherInfo.NewRow();
            inforow["InvoiceNo"] = transactionInfo.MemoNumber;
            inforow["FinancialYearCode"] = transactionInfo.FinancialYearCode;
            inforow["TransactionDate"] = transactionInfo.TransactionDate;
            inforow["ContactName"] = transactionInfo.ContactName;
            inforow["PaymentTerms"] = transactionInfo.PaymentTerm;

            var tax = Math.Max(data.Sum(x => x.OtherCharges) + data.Sum(x => x.Tax), 0);
            inforow["Tax"] = tax;

            var totalamount =
                Math.Max(data.Sum(x => x.TotalAmount) + tax, 0);

            inforow["TotalAmount"] = totalamount;
            inforow["AmountInWords"] = SpellNumber.SpellInWord(totalamount);

            if (request.TransactionType == TransactionType.PurchaseTransaction)
            {
                var supplier = DbContext.Suppliers
                        .Single(sa => sa.SupplierCode == transactionInfo.TransactionPartyRef);

                inforow["Address"] = supplier.Address.ToString();
                inforow["CompanyName"] = supplier.CompanyName;
                inforow["CSTNumber"] = supplier.CSTNumber;
                inforow["VATNumber"] = supplier.VATNumber;
            }
            else
            {
                var customer = DbContext.Customers
                        .Single(sa => sa.CustomersCode == transactionInfo.TransactionPartyRef);

                inforow["Address"] = customer.Address.ToString();
                inforow["CompanyName"] = customer.CompanyName;
                inforow["CSTNumber"] = customer.CSTNumber;
                inforow["VATNumber"] = customer.VATNumber;
            }
            otherInfo.Rows.Add(inforow);

            return response;
        }

        public TaxInvoiceReportResponse GetTransactionDetailReport(TaxInvoiceReportRequest request)
        {
            var response = new TaxInvoiceReportResponse();

            var detail = response.TaxInvoiceDetailDataSet.Tables["JewelDetails"];
            var otherInfo = response.TaxInvoiceDetailDataSet.Tables["OtherInfo"];

            var transactionLookups = DbContext.TransactionLookups.Single(lookup => lookup.MemoNumber == request.TransactionNumber);

            var data = (from tran in transactionLookups.JewelTransactions
                        let lookup = DbContext.TransactionLookups.Single(x => x.MemoNumber == request.TransactionNumber)
                        let inv = DbContext.TransactionInvoices.SingleOrDefault(x => x.InvoiceNumber == request.TransactionNumber)
                        select new
                        {
                            Tax = inv != null ? inv.Tax : 0.0M,
                            OtherCharges = inv != null ? inv.OtherCharges : 0.0M,
                            lookup.MemoNumber,
                            lookup.TransactionDate,
                            tran.TotalAmount,
                            tran.DesignCode,
                            tran.KT,
                            tran.MetalColor,
                            tran.JewelType,
                            tran.TotalWeight,
                            tran.MetalWeight,
                            tran.StoneWeight,
                            tran.StonePcs,
                            tran.CStonePcs,
                            tran.CStoneWeight,
                        }).ToList();

            if (data.Count == 0)
            {
                response.AddValidationError("NoDataFound", "No Tax Invoice found!");
            }

            if (response.IsValid == false)
                return response;

            var counter = 0;
            foreach (var item in data)
            {
                var taxInvoiceRow = detail.NewRow();

                taxInvoiceRow["SrNo"] = ++counter;
                taxInvoiceRow["JewelDesc"] = item.JewelType;
                taxInvoiceRow["JewelImage"] = ImageConverterHelper.ImageToByteArray(ImageExtension.ResolveImage(item.DesignCode));
                taxInvoiceRow["DesignCode"] = item.DesignCode;
                taxInvoiceRow["MetalKT"] = item.KT;
                taxInvoiceRow["MetalCol"] = item.MetalColor;
                taxInvoiceRow["GrWt"] = item.TotalWeight;
                taxInvoiceRow["NetWt"] = item.MetalWeight;
                taxInvoiceRow["DiaPcs"] = item.StonePcs;
                taxInvoiceRow["DiaWt"] = item.StoneWeight;
                taxInvoiceRow["ColStonePcs"] = item.CStonePcs;
                taxInvoiceRow["ColStoneWt"] = item.CStoneWeight;
                taxInvoiceRow["Amount"] = item.TotalAmount;                
                detail.Rows.Add(taxInvoiceRow);
            }

            var transactionInfo = data.First();

            var otherInfoRow = otherInfo.NewRow();
            otherInfoRow["InvoiceNo"] = transactionInfo.MemoNumber;
            otherInfoRow["TransactionDate"] = transactionInfo.TransactionDate;
            var tax = Math.Max(data.Sum(x => x.OtherCharges) + data.Sum(x => x.Tax), 0);
            otherInfoRow["Tax"] = tax;

            var totalamount =
               Math.Max(data.Sum(x => x.TotalAmount) + tax, 0);

            otherInfoRow["TotalAmount"] = totalamount;
            otherInfoRow["AmountInWords"] = SpellNumber.SpellInWord(totalamount);
            otherInfo.Rows.Add(otherInfoRow);

            return response;
        }
    }
}
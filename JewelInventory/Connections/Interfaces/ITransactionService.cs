using System.Linq;

namespace Connections
{
    public interface ITransactionService
    {
        IQueryable<JewelStockLedger> GetJewelStockLedgers();
        IQueryable<TransactionInvoices> GetJewelTransactionInvoices();
        IQueryable<TransactionLookup> GetJewelTransactionsLookUp();
        IQueryable<JewelTransaction> GetJewelTransactions();
        IQueryable<TransactionLookup> GetJewelTransactionsLookUp(TransactionType type);
        IQueryable<CreditNote> GetCreditNotes();

        TransactionLookup GetJewelTransactionsLookUpById(int lookUpId);

        JewelTransaction GetJewelTransactionsById(int id);
        JewelTransaction GetJewelTransactionsByJewelNo(string jewelNo);

        JewelStockLedger GetJewelStockByJewelNo(string jewelNo);

        JewelTransactionResponse CreateJewelTransaction(JewelTransactionRequest request);
        void UpdateJewelDetail(JewelUpdateRequest tran);
        SalesTransactionResponse CreateSalesTransaction(SalesTransactionRequest request);
        CreditNoteResponse CreateCreditNote(CreditNoteRequest request);
    }
}
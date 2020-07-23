namespace Connections
{
    public class SalesTransactionRequest : RequestBase
    {
        public TransactionLookup TransactionLookup { get; set; }
        public TransactionInvoices TransactionInvoice { get; set; }
    }
}

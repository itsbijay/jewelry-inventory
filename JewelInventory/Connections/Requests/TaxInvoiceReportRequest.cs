
namespace Connections
{
    public class TaxInvoiceReportRequest : RequestBase
    {
        /// <summary>
        /// Invoice number in case of sales/ return transaction OR Memo number in case of marketing/ approval memo
        /// </summary>
        public string TransactionNumber { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}

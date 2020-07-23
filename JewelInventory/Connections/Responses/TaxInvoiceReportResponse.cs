using Connections.Dataset;
namespace Connections
{
	public class TaxInvoiceReportResponse : ResponseBase
	{
		public TaxInvoiceReportResponse()
		{
            TaxInvoiceSummaryDataSet = new TaxInvoiceSummaryDataSet();
            TaxInvoiceDetailDataSet = new TaxInvoiceDetailDataSet();
		}

        public TaxInvoiceSummaryDataSet TaxInvoiceSummaryDataSet { get; set; }
        public TaxInvoiceDetailDataSet TaxInvoiceDetailDataSet { get; set; }
	}
}

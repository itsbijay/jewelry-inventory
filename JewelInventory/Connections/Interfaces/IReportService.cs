namespace Connections
{
    public interface IReportService
    {
        TaxInvoiceReportResponse GetTransactionSumaryReport(TaxInvoiceReportRequest request);
        TaxInvoiceReportResponse GetTransactionDetailReport(TaxInvoiceReportRequest request);
    }
}
using System;
using System.Linq;
using System.Windows.Forms;
using Connections;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Generic;

namespace JewelInventory
{
    public partial class frmTaxInvoiceReport : BaseFormControl
    {
        private readonly IReportService _reportService;
        public readonly IWinSettingProvider _winSettingProvider;

        public frmTaxInvoiceReport()
        {
            InitializeComponent();
        }

        public frmTaxInvoiceReport(IConfigurationService configurationService, IReportService reportService, IWinSettingProvider winSettingProvider)
            : this()
        {
            _reportService = reportService;
            _winSettingProvider = winSettingProvider;
            IConfigurationService configurationService1 = configurationService;

            cboFinancialYear.DataSource = configurationService1.GetAllFinancialYears().Select(x => x.YearCode).ToList();
            cboFinancialYear.SelectedItem = configurationService1.GetCurrentFinancialYearCode;
            cboTransactionType.DataSource = Enum.GetNames(typeof(TransactionType))
                                            .Except(new List<string> { TransactionType.NotSet.ToString(), TransactionType.PurchaseTransaction.ToString() })
                                            .ToList();

            rdoDetail.Checked = true;
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            var transactionType = (TransactionType)Enum.Parse(typeof(TransactionType), cboTransactionType.SelectedItem.ToString());

            var request = new TaxInvoiceReportRequest
            {
                TransactionNumber = txtInvoiceNo.Text,
                TransactionType = transactionType
            };

            var response = new TaxInvoiceReportResponse();
            var reportDocument = new ReportDocument();

            if (rdoDetail.Checked)
            {
                response = _reportService.GetTransactionDetailReport(request);
                reportDocument.Load(ReportUtility.GetTaxInvoiceDetailReportPath(transactionType));
            }
            else if (rdoSummary.Checked)
            {
                response = _reportService.GetTransactionSumaryReport(request);
                reportDocument.Load(ReportUtility.GetTaxInvoiceSummaryReportPath(transactionType));
            }

            if (false == response.IsValid)
            {
                MessageBox.Show(response.AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                crystalReportViewer.ReportSource = null;
                return;
            }

            if (rdoDetail.Checked)
                reportDocument.SetDataSource(response.TaxInvoiceDetailDataSet);
            else if (rdoSummary.Checked)
                reportDocument.SetDataSource(response.TaxInvoiceSummaryDataSet);

            crystalReportViewer.ReportSource = reportDocument;
            crystalReportViewer.Refresh();
        }
    }
}

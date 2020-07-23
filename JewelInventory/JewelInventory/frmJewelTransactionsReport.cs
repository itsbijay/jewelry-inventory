using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Connections;
using CrystalDecisions.CrystalReports.Engine;
using Connections.Dataset;
using JewelInventory.Properties;

namespace JewelInventory
{
	public partial class frmJewelTransactionsReport : BaseFormControl
	{
		private readonly ITransactionService _transactionsServices;
	    private readonly IDataSetProvider _firmDataSetService;

		public frmJewelTransactionsReport(ITransactionService transactionsServices, IConfigurationService configurationService, IDataSetProvider firmDataSetService)
		{
		    InitializeComponent();
			_transactionsServices = transactionsServices;
			var configurationService1 = configurationService;
            _firmDataSetService = firmDataSetService;

			cboFinancialYear.DataSource = configurationService1.GetAllFinancialYears().Select(x => x.YearCode).ToList();
			cboFinancialYear.SelectedItem = configurationService1.GetCurrentFinancialYearCode;
			cboTransactionType.DataSource = LocalStore.TransactionTypeItems.GetTransactionTypeItems();
		}

		private void btnShowReport_Click(object sender, EventArgs e)
		{
            var reportDataSet = GetJewelTransactionReport();
            if (reportDataSet == null)
                return;

			var reportDocument = new ReportDocument();
			reportDocument.Load(ReportUtility.ResolveReportPath(ReportConstants.JEWELTRANSACTIONREPORTPATH));
			crystalReportViewer1.ReportSource = reportDocument;
            reportDocument.SetDataSource(reportDataSet);
			crystalReportViewer1.Refresh();
		}

		private DataSet GetJewelTransactionReport()
		{
			var jewelTransactionsDataSet = new JewelTransactionsDataSet();
			var jewelTransactionDataTable = jewelTransactionsDataSet.Tables["JewelTransactions"];

			var firmDataTable = jewelTransactionsDataSet.Tables["FirmMaster"];
            _firmDataSetService.GetFirmDataTable(firmDataTable);

            var temp = _transactionsServices.GetJewelTransactionsLookUp().ToList();
            var jewelLookupList = temp 
				.Where(tr => tr.TransactionType == ((LocalStore.TransactionTypeItems)(cboTransactionType.SelectedItem)).JewelTransactionType
				&& tr.TransactionDate.Date >= fromDateTimePicker.Value.Date && tr.TransactionDate.Date <= toDateTimePicker.Value.Date).ToList();

			if (jewelLookupList.Count == 0)
			{
				MessageBox.Show(Resources.frmJewelTransactionsReport_GetJewelTransactionReport_No_Data_found_);
				return null;
			}

			int counter = 1;

            foreach (var jewelLookup in jewelLookupList)
			{
                jewelLookup.JewelTransactions.ToList().ForEach(tran =>
                {
                    var jewelTransactionRow = jewelTransactionDataTable.NewRow();

                    jewelTransactionRow["SrNo"] = counter;
                    jewelTransactionRow["TransactionDate"] = jewelLookup.TransactionDate;
                    jewelTransactionRow["ContactName"] = jewelLookup.ContactName;
                    jewelTransactionRow["DocNumber"] = jewelLookup.DocNumber;
                    jewelTransactionRow["Remarks"] = jewelLookup.Remarks;
                    jewelTransactionRow["CertificateNumber"] = tran.CertificateNumber;
                    jewelTransactionRow["JewelType"] = tran.JewelType;
                    jewelTransactionRow["JewelNumber"] = tran.JewelNumber;
                    jewelTransactionRow["DesingCode"] = tran.DesignCode;
                    jewelTransactionRow["TotalWeight"] = tran.TotalWeight;
                    jewelTransactionRow["MetalWeight"] = tran.MetalWeight;
                    jewelTransactionRow["StoneWeight"] = tran.StoneWeight;
                    jewelTransactionRow["StonePcs"] = tran.StonePcs;
                    jewelTransactionRow["TotalAmount"] = tran.TotalAmount;

                    jewelTransactionDataTable.Rows.Add(jewelTransactionRow);

                    counter = counter + 1;  
                });
			}

			return jewelTransactionsDataSet;
		}
	}
}

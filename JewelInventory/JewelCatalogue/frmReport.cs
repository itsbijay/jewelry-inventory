using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;


namespace JewelCatalogue
{
	public partial class frmReport : BaseFormControl
	{
		public frmReport()
		{
			InitializeComponent();
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
		}

		private void frmReport_Load(object sender, EventArgs e)
		{
			var rptDoc = new ReportDocument();
			rptDoc.Load(ReportPath);
            //rptDoc.SetDatabaseLogon("sa", "mail_123");
			crystalReportViewer1.ReportSource = rptDoc;
			rptDoc.SetDataSource(ReportDataSet);
			crystalReportViewer1.Refresh();
		}

		public DataSet ReportDataSet { get; set; }

		public string ReportPath { get; set; }
	}
}

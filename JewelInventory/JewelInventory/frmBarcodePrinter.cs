using System;
using JetCoders.Forms.UI;
using Connections;
using System.IO;
using Connections.Dataset;
using CrystalDecisions.CrystalReports.Engine;
using JetCoders.Shared;

namespace JewelInventory
{
	public partial class frmBarcodePrinter : BaseFormControl
	{
		public frmBarcodePrinter()
		{
			InitializeComponent();
		}

        private void frmBarcodePrinter_Load(object sender, EventArgs e)
        {
            var jewels = FormData as TransactionLookup;

            var jewelMasterDataSet = new JewelMasterDataSet();
            var barcode = new BarcodeUtility();

            foreach (var jewel in jewels.JewelTransactions)
            {
                var jewelImage = barcode.MakeBarcodeImage(jewel.JewelNumber);
                var jewelMasterRow = jewelMasterDataSet.Tables["JewelMaster"].NewRow();

                jewelMasterRow["JewelNo"] = jewel.JewelNumber;
                jewelMasterRow["CertificateNo"] = jewel.CertificateNumber;
                jewelMasterRow["StyleNo"] = jewel.DesignCode;
                jewelMasterRow["JewelDescription"] = jewel.JewelType;
                jewelMasterRow["MetalColor"] = jewel.MetalColor;
                jewelMasterRow["ImagePath"] = ImageExtension.GetImageName(jewel.DesignCode);
                jewelMasterRow["DiamondPcs"] = Convert.ToString(jewel.StonePcs);
                jewelMasterRow["DiamondWt"] = Convert.ToString(jewel.StoneWeight);
                jewelMasterRow["GrsWt"] = Convert.ToString(jewel.TotalWeight);
                jewelMasterRow["NetWt"] = Convert.ToString(jewel.MetalWeight);
                jewelMasterRow["JewelImage"] = ImageConverterHelper.ImageToByteArray(jewelImage);

                jewelMasterDataSet.Tables["JewelMaster"].Rows.Add(jewelMasterRow);
            }

            if (File.Exists(ReportUtility.ResolveReportPath(ReportConstants.JEWELMASTERREPORTPATH)))
            {
                var reportDocument = new ReportDocument();
                reportDocument.Load(ReportUtility.ResolveReportPath(ReportConstants.JEWELMASTERREPORTPATH));

                crystalReportViewer.ReportSource = null;
                crystalReportViewer.ReportSource = reportDocument;
                reportDocument.SetDataSource(jewelMasterDataSet);
                crystalReportViewer.Refresh();
            }
        }
	}
}

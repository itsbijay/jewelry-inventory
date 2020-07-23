using System;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;
using Connections;
using CrystalDecisions.Shared;
using System.IO;
using Connections.Dataset;
using JetCoders.Forms.UI;
using JetCoders.Shared;

namespace JewelInventory
{
    public interface IReportUtility
    {
        void ShowCostingReport(List<Int32> transactionId);
        void ShowBarcodeTag(IEnumerable<String> jewelNumbers);
        void ShowStickerReport(IEnumerable<String> jewelNumbers);
        void ShowTaxInvoice(Guid createJewelTransactionResponse);
    }

    public class ReportUtility : IReportUtility
    {
        readonly IDataSetProvider _dataSetService;
        readonly ITransactionService _transactionService;

        public ReportUtility(IDataSetProvider dataSetService, ITransactionService transactionService)
        {
            _dataSetService = dataSetService;
            _transactionService = transactionService;
        }

        public void ShowCostingReport(List<Int32> transactionId)
        {
            var reportDocument = new ReportDocument();
            reportDocument.Load(ResolveReportPath(ReportConstants.Costingchartreport));

            var dataSet = _dataSetService.GetCostingChartDataSet(transactionId);
            reportDocument.SetDataSource(dataSet);

            var fileName = Application.StartupPath + @"/ExcelFiles/" + "CostingChart_" + DateTime.Now.ToString("MMddyyyy_HHmmss") + ".xls";

            var crDiskFileDestinationOptions = new DiskFileDestinationOptions();
            var crFormatTypeOptions = new ExcelFormatOptions();
            crDiskFileDestinationOptions.DiskFileName = fileName;
            var crExportOptions = reportDocument.ExportOptions;
            crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
            crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
            crExportOptions.FormatOptions = crFormatTypeOptions;
            reportDocument.Export();

            if (!File.Exists(fileName)) return;
            var excelApp = new Microsoft.Office.Interop.Excel.Application {Visible = true};

            //Workbooks is a collection of all the workbook objects currently open in Excel
            var books = excelApp.Workbooks;

            //Workbook sheet is used to access the sheet identified above in mysheet
            books.Open(fileName);
        }

        public void ShowBarcodeTag(IEnumerable<String> jewelNumbers)
        {
            var jewelMasterDataSet = new JewelMasterDataSet();
            var barcode = new BarcodeUtility();

            foreach (var jewel in jewelNumbers)
            {
                var jeweltran = _transactionService.GetJewelStockByJewelNo(jewel);
                if (jeweltran == null)
                    continue;

                var jewelImage = barcode.MakeBarcodeImage(jeweltran.JewelNumber);
                var jewelMasterRow = jewelMasterDataSet.Tables["JewelMaster"].NewRow();

                jewelMasterRow["JewelNo"] = jeweltran.JewelNumber;
                jewelMasterRow["StyleNo"] = jeweltran.DesignCode;
                jewelMasterRow["CertificateNo"] = jeweltran.CertificateNumber;
                jewelMasterRow["JewelDescription"] = jeweltran.JewelType;
                jewelMasterRow["MetalColor"] = jeweltran.MetalColor;
                jewelMasterRow["ImagePath"] = ImageExtension.GetImageName(jeweltran.DesignCode);
                jewelMasterRow["DiamondPcs"] = Convert.ToString(jeweltran.StonePcs);
                jewelMasterRow["DiamondWt"] = Convert.ToString(jeweltran.StoneWeight);
                jewelMasterRow["GrsWt"] = Convert.ToString(jeweltran.TotalWeight);
                jewelMasterRow["NetWt"] = Convert.ToString(jeweltran.MetalWeight);
                jewelMasterRow["JewelImage"] = ImageConverterHelper.ImageToByteArray(jewelImage);

                jewelMasterDataSet.Tables["JewelMaster"].Rows.Add(jewelMasterRow);
            }

            var orderReport = new frmReport
            {
                ReportPath = ResolveReportPath(ReportConstants.JEWELMASTERREPORTPATH),
                ReportDataSet = jewelMasterDataSet
                
            };
            orderReport.Show();
        }

        public void ShowStickerReport(IEnumerable<String> jewelNumbers)
        {
            var jewelStickerDataSet = new JewelStickerDataSet();

            foreach (var jewelNo in jewelNumbers)
            {
                var jewel = _transactionService.GetJewelStockByJewelNo(jewelNo.Trim());
                if (jewel == null)
                    continue;

                var jewelMasterRow = jewelStickerDataSet.Tables["JewelSticker"].NewRow();

                jewelMasterRow["JewelNumber"] = jewel.JewelNumber;
                jewelMasterRow["DesignCode"] = jewel.DesignCode;
                jewelMasterRow["NetWeight"] = jewel.MetalWeight;
                jewelMasterRow["GrossWeight"] = jewel.TotalWeight;
                jewelMasterRow["StoneWeight"] = jewel.StoneWeight;
                jewelMasterRow["StonePcs"] = jewel.StonePcs;
                jewelMasterRow["JewelImage"] = ImageConverterHelper.ImageToByteArray(ImageExtension.ResolveImage(jewel.DesignCode));

                jewelStickerDataSet.Tables["JewelSticker"].Rows.Add(jewelMasterRow);
            }

            var orderReport = new frmReport
            {
                ReportPath = ResolveReportPath(ReportConstants.JewelStickerReport),
                ReportDataSet = jewelStickerDataSet
            };
            orderReport.Show();
        }

        public void ShowTaxInvoice(Guid identifier)
        {
            var taxInvoiceDataSet = new TaxInvoiceDetailDataSet();
            var firmDataTable = taxInvoiceDataSet.Tables["FirmMaster"];
            _dataSetService.GetFirmDataTable(firmDataTable);
        }

        public static string ResolveReportPath(string reportname)
        {
            return Application.StartupPath + @"\Reports\" + reportname;
        }

        public static string GetTaxInvoiceSummaryReportPath(TransactionType transactionType)
        {
            var reportPath = string.Empty;
            switch (transactionType)
            {
                case TransactionType.PurchaseTransaction:
                    reportPath = ResolveReportPath(ReportConstants.TaxInvoiceSummaryReport);
                    break;
                case TransactionType.ApprovalTransaction:
                    reportPath = ResolveReportPath(ReportConstants.ApprovalMemoSummaryReport);
                    break;
                case TransactionType.MarketingTransaction:
                    reportPath = ResolveReportPath(ReportConstants.MarketingMemoSummaryReport);
                    break;
                case TransactionType.MarketingInReturnTransaction:
                    reportPath = ResolveReportPath(ReportConstants.MarketingMemoReturnSummaryReport);
                    break;
                case TransactionType.ApprovalInReturnTransaction:
                    reportPath = ResolveReportPath(ReportConstants.ApprovalMemoReturnSummaryReport);
                    break;
                case TransactionType.SalesInTransaction:
                    reportPath = ResolveReportPath(ReportConstants.TaxInvoiceSummaryReport);
                    break;
                case TransactionType.SalesInReturnTransaction:
                    reportPath = ResolveReportPath(ReportConstants.TaxInvoiceReturnSummaryReport);
                    break;
            }
            return reportPath;
        }

        public static string GetTaxInvoiceDetailReportPath(TransactionType transactionType)
        {
            var reportPath = string.Empty;
            switch (transactionType)
            {
                case TransactionType.PurchaseTransaction:
                    reportPath = ResolveReportPath(ReportConstants.TaxInvoiceDetailReport);
                    break;
                case TransactionType.ApprovalTransaction:
                    reportPath = ResolveReportPath(ReportConstants.ApprovalMemoDetailReport);
                    break;
                case TransactionType.MarketingTransaction:
                    reportPath = ResolveReportPath(ReportConstants.MarketingMemoDetailReport);
                    break;
                case TransactionType.MarketingInReturnTransaction:
                    reportPath = ResolveReportPath(ReportConstants.MarketingMemoReturnDetailReport);
                    break;
                case TransactionType.ApprovalInReturnTransaction:
                    reportPath = ResolveReportPath(ReportConstants.ApprovalMemoReturnDetailReport);
                    break;
                case TransactionType.SalesInTransaction:
                    reportPath = ResolveReportPath(ReportConstants.TaxInvoiceDetailReport);
                    break;
                case TransactionType.SalesInReturnTransaction:
                    reportPath = ResolveReportPath(ReportConstants.TaxInvoiceReturnDetailReport);
                    break;
            }
            return reportPath;
        }
    }
}
 
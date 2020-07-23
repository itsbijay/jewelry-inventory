using Connections;
using Connections.Dataset;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelInventory
{
    public partial class frmJewelStockReport : BaseFormControl
    {
        private readonly ITransactionService _transactionsServices;
        private readonly IDataSetProvider _firmDataSetService;
        private const string ALL = "All";

        public frmJewelStockReport(ITransactionService transactionsServices, IDataSetProvider firmDataSetService)
        {
            InitializeComponent();
            _transactionsServices = transactionsServices;
            _firmDataSetService = firmDataSetService;

            cboKT.DataSource = Enum.GetValues(typeof(JewelItemCategory)).Cast<JewelItemCategory>().ToList();
            cboStoneType.DataSource = LocalStore.Products.GetProducts();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            var jewelStockDataSet = new JewelStockDataSet();
            var jewelStockDataTable = jewelStockDataSet.Tables["JewelStockLedger"];
            var firmDataTable = jewelStockDataSet.Tables["FirmMaster"];
            var jewelStockSummaryDataTable = jewelStockDataSet.Tables["JewelStockSummary"];
            _firmDataSetService.GetFirmDataTable(firmDataTable);

            IQueryable<JewelStockLedger> jewelStockList; JewelItemCategory metalType;
            var stoneType = cboStoneType.SelectedItem.ToString();
            Enum.TryParse(cboKT.SelectedItem.ToString(), out metalType);

            if (metalType == JewelItemCategory.NotSet && cboStoneType.SelectedItem.ToString() == ALL)
                jewelStockList = _transactionsServices.GetJewelStockLedgers();
            else if (metalType != JewelItemCategory.NotSet && cboStoneType.SelectedItem.ToString() == ALL)
                jewelStockList = _transactionsServices.GetJewelStockLedgers()
                    .Where(tr => tr.JewelItemCategory_Enum == (int) metalType);
            else
                jewelStockList = _transactionsServices.GetJewelStockLedgers()
                    .Where(tr => tr.JewelItemCategory_Enum == (short) metalType && tr.JewelType == stoneType);

            int counter = 1;

            var list = jewelStockList.Where(x => x.StockStatus_Enum == (short)StockStatus.ItemIsInStock).ToList();
            foreach (var jewel in list)
            {
                var jewelRow = jewelStockDataTable.NewRow();
                jewelRow["SrNo"] = counter;
                jewelRow["JewelStockMasterId"] = jewel.JewelStockMasterId;
                jewelRow["JewelNumber"] = jewel.JewelNumber;
                jewelRow["DesignCode"] = jewel.DesignCode;
                jewelRow["TotalWeight"] = jewel.TotalWeight;
                jewelRow["MetalType"] = jewel.JewelItemCategory;
                jewelRow["KT"] = jewel.KT;
                jewelRow["StoneType"] = jewel.JewelType;
                jewelRow["MetalWeight"] = jewel.MetalWeight;
                jewelRow["StoneWeight"] = jewel.StoneWeight;
                jewelRow["StonePcs"] = jewel.StonePcs;
                jewelRow["ColorStonePcs"] = jewel.CStonePcs;
                jewelRow["ColorStoneWt"] = jewel.CStoneWeight;

                jewelStockDataTable.Rows.Add(jewelRow);

                counter = counter + 1;
            }

            var summaryRow = jewelStockSummaryDataTable.NewRow();
            summaryRow["TotalInStock"] = jewelStockList.Count(x => x.StockStatus_Enum == (short)StockStatus.ItemIsInStock);
            summaryRow["TotalOutOfStock"] = jewelStockList.Count(x => x.JewelState_Enum == (short)JewelState.OnMarketing && x.StockStatus_Enum == (short)StockStatus.ItemLockedInStock);
            summaryRow["TotalOnApproval"] = jewelStockList.Count(x => x.JewelState_Enum == (short)JewelState.OnApproval && x.StockStatus_Enum == (short)StockStatus.ItemOutOfStock);
            jewelStockSummaryDataTable.Rows.Add(summaryRow);

            var reportDocument = new ReportDocument();
            reportDocument.Load(ReportUtility.ResolveReportPath(ReportConstants.JEWELSTOCKREPORTPATH));
            crystalReportViewer1.ReportSource = reportDocument;
            reportDocument.SetDataSource(jewelStockDataSet);
            crystalReportViewer1.Refresh();
        }
    }
}

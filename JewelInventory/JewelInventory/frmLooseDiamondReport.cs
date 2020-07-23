using Connections;
using Connections.Dataset;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JewelInventory
{
    public partial class frmLooseDiamondReport : BaseFormControl
    {
        private readonly ICustomerService _customerService = null;
        private readonly ILooseDiamondService _looseDiamondService = null;
        private readonly IFirmDataSetService _firmDataService = null;

        public frmLooseDiamondReport(ICustomerService customerService, ILooseDiamondService looseDiamondService, IFirmDataSetService firmDataService)
        {
            InitializeComponent();
            _customerService = customerService;
            _looseDiamondService = looseDiamondService;
            _firmDataService = firmDataService;

            cboCustomer.DataSource = _customerService.GetAllCustomers();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            var reportDataSet = this.GetLooseDiamondReport();
            if (reportDataSet == null)
                return;

            var reportDocument = new ReportDocument();
            reportDocument.Load(Application.StartupPath + @"/Reports/" + ReportConstants.LOOSEDIAMONDREPORT);
            crystalReportViewer1.ReportSource = reportDocument;
            reportDocument.SetDataSource(reportDataSet);
            crystalReportViewer1.Refresh();
        }

        private DataSet GetLooseDiamondReport()
        {
            var looseDiamondDataSet = new LooseDiamondDataSet();
            var looseDiamondDataTable = looseDiamondDataSet.Tables["LooseDiamonds"];

            var firmDataTable = looseDiamondDataSet.Tables["FirmMaster"];
            firmDataTable = _firmDataService.GetFirmDataTable(firmDataTable);
            var abd = cboCustomer.SelectedItem;

            //var looseDiamondList = _looseDiamondService.GetLooseDiamonds()
            //                           .Where(ld => ld.CustomerId == ((Customer)(cboCustomer.SelectedItem)).CustomersId
            //                           && ld.DiamondDate.Date >= fromDateTimePicker.Value.Date && ld.DiamondDate.Date <= toDateTimePicker.Value.Date).ToList();


            var looseDiamondList = _looseDiamondService.GetLooseDiamonds();

            if (looseDiamondList.Count == 0)
            {
                MessageBox.Show("No Data found!");
                return null;
            }

            int counter = 1;

            foreach (var diamond in looseDiamondList)
            {
                var diamondRow = looseDiamondDataTable.NewRow();

                diamondRow["SrNo"] = counter;
                diamondRow["DiamondCode"] = diamond.DiamondCode;
                diamondRow["Customer"] = _customerService.GetCustomerByCode(diamond.DiamondCode).ContactName;
                diamondRow["SieveSize"] = diamond.SieveSize;
                diamondRow["DiamondWeight"] = diamond.DiamondWeight;
                diamondRow["Quality"] = diamond.Quality;
                diamondRow["VVS"] = diamond.VVS;
                diamondRow["Amount"] = diamond.Amount;

                looseDiamondDataTable.Rows.Add(diamondRow);

                counter = counter + 1;
            }

            return looseDiamondDataSet;
        }
    }
}

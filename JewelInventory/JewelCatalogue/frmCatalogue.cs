using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using CrystalDecisions.Shared;
using JewelCatalogue.Properties;

namespace JewelCatalogue
{
    public partial class frmCatalogue : BaseFormControl
    {
        private readonly ICatalogueService _catalogueService;

        public double DiamnondWeight;
        public double FromJewel, ToJewel;
        public int AddRowToGrid;
        public string Weight, SelectedWeight, JewelDescription;
        public List<QueryRequest> CatalogueRequest { get; set; }

        public List<Tuple<Decimal, Decimal, String>> Filters = new List<Tuple<Decimal, Decimal, String>>();

        private decimal GoldWeight { get { return GetTotal("NetWt"); } }
        private decimal GoldPieces { get { return GetTotal("GrsWt"); } }
        private decimal DiamondWeight { get { return GetTotal("DiaWt"); } }
        private decimal DiamondPieces { get { return GetTotal("DiaPcs"); } }

        public bool IsSelectAll { get; set; }

        public frmCatalogue()
        {
            InitializeComponent();
        }

        public frmCatalogue(ICatalogueService catalogueService)
            : this()
        {
            _catalogueService = catalogueService;

            CatalogueRequest = new List<QueryRequest>();
            cmbJewelDescription.DataSource = LocalStore.Products.GetProducts();
        }

        private void btnJewelDescription_Click(object sender, EventArgs e)
        {
            IsSelectAll = false;
            if (!HasFilters && !SelectWeight()) return;
            btnSelectAll.Enabled = false;
            ShowManagedForm<frmProduct>(this, OwnerType.NonMdiOwner);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            btnJewelDescription.Enabled = false;
            IsSelectAll = true;
            ShowManagedForm<frmAllCatalogueProduct>(this, OwnerType.NonMdiOwner);
        }

        private bool SelectWeight()
        {
            if (txtWeightFrom.Text == "" || txtWeightTo.Text == "" || cmbWeight.Text == "")
            {
                MessageBox.Show(Resources.frmCatalogue_SelectWeight_Please_enter_valid_range_of_Weight_and_select_Jewel_Description_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWeightFrom.Focus();
                return false;
            }

            if (cmbJewelDescription.Text == "")
            {
                MessageBox.Show(Resources.frmCatalogue_SelectWeight_Please_select_atleast_one_Jewel_Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbJewelDescription.Focus();
                return false;
            }

            Weight = cmbWeight.Text;

            Double.TryParse(txtWeightFrom.Text, out FromJewel);
            Double.TryParse(txtWeightTo.Text, out ToJewel);

            switch (Weight)
            {
                case "Diamond Wt":
                    SelectedWeight = "DiamondWt";
                    break;
                case "Diamond Pcs":
                    SelectedWeight = "DiamondPcs";
                    break;
                case "Gold Wt":
                    SelectedWeight = "NetWt";
                    break;
                case "Gold Pcs":
                    SelectedWeight = "GrsWt";
                    break;
                default:
                    SelectedWeight = "DiamondWt";
                    break;
            }

            JewelDescription = cmbJewelDescription.Text;
            return true;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CatalogueRequest.Count == 0)
            {
                MessageBox.Show(Resources.frmCatalogue_btnProcess_Click_No_Records_to_Process_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWeightFrom.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show(Resources.frmCatalogue_btnProcess_Click_Please_enter_Customer_Name_for_Excel_Process_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;

            var orderDataSet = _catalogueService.GetCatalogueReport(CatalogueRequest, true);

            var paramFields = new ParameterFields();
            var pfItemCustomerName = new ParameterField();
            var dcItemCustomerName = new ParameterDiscreteValue();
            pfItemCustomerName.ParameterFieldName = "pCustomerName";
            dcItemCustomerName.Value = txtCustomerName.Text;
            pfItemCustomerName.CurrentValues.Add(dcItemCustomerName);
            paramFields.Add(pfItemCustomerName);

            var pfItemQuotationNo = new ParameterField();
            
            var dcItemQuotationNo = new ParameterDiscreteValue();
            pfItemQuotationNo.ParameterFieldName = "pQuotationNo";
            dcItemQuotationNo.Value = txtQuotationNo.Text;
            pfItemQuotationNo.CurrentValues.Add(dcItemQuotationNo);
            paramFields.Add(pfItemQuotationNo);

            var orderReport = new frmReport
            {
                crystalReportViewer1 = {ParameterFieldInfo = paramFields},
                ReportPath = Application.StartupPath + @"\" + ReportConstants.ORDERREPORTPATH,
                ReportDataSet = orderDataSet,
                Text = Resources.frmCatalogue_btnProcess_Click_Jewel_Order_Report
            };
            orderReport.Show();

            Cursor = Cursors.Default;
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            dgvJewel.Rows.Clear();
            FromJewel = 0.0;
            ToJewel = 0.0;
            txtWeightFrom.Text = string.Empty;
            txtWeightTo.Text = string.Empty;
            txtQuotationNo.Text = String.Empty;
            txtCustomerName.Text = String.Empty;
            lblTotal.Text = "";
            lblGoldWeight.Text = "";
            lblGrsWt.Text = "";
            lblDiamondWeight.Text = "";
            lblDiamondPieces.Text = "";
            cmbJewelDescription.SelectedIndex = 0;
            cmbWeight.SelectedItem = 0;
            AddRowToGrid = 0;
            CatalogueRequest = new List<QueryRequest>();
            btnSelectAll.Enabled = true;
            btnJewelDescription.Enabled = true;
            txtWeightFrom.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseOrderForm(dgvJewel, this);
        }

        public void GetTotal()
        {
            lblTotal.Text = Convert.ToString(TotalRows);
            lblGoldWeight.Text = Convert.ToString(GoldWeight);
            lblGrsWt.Text = Convert.ToString(GoldPieces);
            lblDiamondWeight.Text = Convert.ToString(DiamondWeight);
            lblDiamondPieces.Text = Convert.ToString(DiamondPieces);
        }

        public int TotalRows
        {
            get
            {
                return dgvJewel.Rows.Cast<DataGridViewRow>().Count(dgvr => Convert.ToBoolean(dgvr.Cells["select"].EditedFormattedValue));
            }
        }

        private decimal GetTotal(string colname)
        {
            return dgvJewel.Rows.Cast<DataGridViewRow>().Where(dgvr => Convert.ToBoolean(dgvr.Cells["select"].EditedFormattedValue)).Aggregate(default(decimal), (current, dgvr) => current + Convert.ToDecimal(dgvr.Cells[colname].Value));
        }

        private void txtQuotationNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lnkfilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnkfilter.Text == @"Advance Filter")
            {
                ShowManagedForm<frmAdvancesearch>(this, OwnerType.NonMdiOwner);
            }
            else
            {
                // Clear Filters
                lnkfilter.Text = @"Advance Filter";
                grpfilters.Enabled = true;
            }
        }

        public void SetUpAdvanceFilters(dynamic filters)
        {
            grpfilters.Enabled = false;
            Filters = filters;
            lnkfilter.Text = @"Clear Filter";
        }

        public bool HasFilters
        {
            get
            {
                return Filters != null && Filters.Count != 0;
            }
        }
    }
}

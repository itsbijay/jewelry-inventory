using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using CrystalDecisions.Shared;
using JewelCatalogue.Properties;

namespace JewelCatalogue
{
    public partial class frmAllCatalogueProduct : BaseFormControl
    {
        private readonly ICatalogueService _catalogueService;
        private readonly IJewelService _jewelService;

        int GridRow;

        public List<QueryRequest> CatalogueRequest { get; set; }

        public frmAllCatalogueProduct()
        {
            InitializeComponent();
        }

        public frmAllCatalogueProduct(ICatalogueService catalogueService, IJewelService jewelService)
            : this()
        {
            _catalogueService = catalogueService;
            _jewelService = jewelService;

            CatalogueRequest = new List<QueryRequest>();
        }

        private void frmAllCatalogueProduct_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            lblProductName.Text = ((frmCatalogue)Owner).JewelDescription;

            var JewelData = _jewelService.GetAllCatalogueJewels();

            if (JewelData.Count == 0)
            {
                MessageBox.Show(Resources.frmAllCatalogueProduct_frmAllCatalogueProduct_Load_Record_s__Not_found__);
                Close();
                return;
            }

            dgvJewel.Rows.Clear();
            GridRow = 0;

            foreach (var jewel in JewelData)
            {
                dgvJewel.Rows.Add(1);
                dgvJewel.Rows[GridRow].Height = 100;
                dgvJewel.Rows[GridRow].Cells[2].Value = jewel.JewelNo;
                dgvJewel.Rows[GridRow].Cells[3].Value = jewel.StyleNo;
                dgvJewel.Rows[GridRow].Cells[4].Value = jewel.JewelDescription;
                dgvJewel.Rows[GridRow].Cells[5].Value = jewel.MetalColor;
                dgvJewel.Rows[GridRow].Cells[6].Value = ImageExtension.GetImageName(jewel.StyleNo);
                dgvJewel.Rows[GridRow].Cells[7].Value = jewel.DiamondPcs;
                dgvJewel.Rows[GridRow].Cells[8].Value = jewel.DiamondWt;
                dgvJewel.Rows[GridRow].Cells[9].Value = jewel.GrsWt;
                dgvJewel.Rows[GridRow].Cells[10].Value = jewel.NetWt;
                dgvJewel[1, GridRow].Value = ImageExtension.ResolveImage(jewel.StyleNo);
                GridRow = GridRow + 1;
                dgvJewel.FirstDisplayedScrollingRowIndex = dgvJewel.RowCount - 1;

            }
            lblTotItems.Text = Resources.frmAllCatalogueProduct_frmAllCatalogueProduct_Load_ + Convert.ToString(dgvJewel.RowCount);
            dgvJewel.Focus();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CatalogueRequest.Count == 0)
            {
                MessageBox.Show(Resources.frmAllCatalogueProduct_btnProcess_Click_Please_select_Jewelno_for_Excel_Process_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvJewel.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show(Resources.frmAllCatalogueProduct_btnProcess_Click_Please_enter_Customer_Name_for_Excel_Process_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Text = Resources.frmAllCatalogueProduct_btnProcess_Click_Jewel_Order_Report
            };
            orderReport.Show();

            Cursor = Cursors.Default;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvJewel.Rows)
            {
                dgvr.Cells[0].Value = true;

                CatalogueRequest.Add(new QueryRequest
                    {
                        JewelNo = dgvr.Cells[2].Value.ToString(),
                        StyleNo = dgvr.Cells[3].Value.ToString(),
                    });
            }

            GetTotal();
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            if (CatalogueRequest.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgvJewel.Rows)
                {
                    dgvr.Cells[0].Value = false;
                    CatalogueRequest.Remove(CatalogueRequest.FirstOrDefault(x => x.JewelNo == dgvr.Cells[2].Value.ToString()));
                }

                GetTotal();
            }
            else
            {
                MessageBox.Show(Resources.frmAllCatalogueProduct_btnDeselectAll_Click_It_is_already_deselected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSelectAll.Focus();
            }
        }

        private void GetTotal()
        {
            lblTotal.Text = Convert.ToString(TotalRows);
            lblGoldWeight.Text = Convert.ToString(GoldWeight);
            lblGrsWt.Text = Convert.ToString(GoldPieces);
            lblDiamondWeight.Text = Convert.ToString(DiamondWeight);
            lblDiamondPieces.Text = Convert.ToString(DiamondPieces);
        }

        private int TotalRows
        {
            get
            {
                return dgvJewel.Rows.Cast<DataGridViewRow>().Count(dgvr => Convert.ToBoolean(dgvr.Cells["select"].EditedFormattedValue));
            }
        }
        private decimal DiamondWeight { get { return GetTotal("DiaWt"); } }
        private decimal DiamondPieces { get { return GetTotal("DiaPcs"); } }
        private decimal GoldWeight { get { return GetTotal("NetWt"); } }
        private decimal GoldPieces { get { return GetTotal("GrsWt"); } }

        private decimal GetTotal(string colname)
        {
            return dgvJewel.Rows.Cast<DataGridViewRow>().Where(dgvr => Convert.ToBoolean(dgvr.Cells["select"].EditedFormattedValue)).Aggregate(default(decimal), (current, dgvr) => current + Convert.ToDecimal(dgvr.Cells[colname].Value));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseOrderForm(dgvJewel, this);
        }

        private void txtQuotationNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

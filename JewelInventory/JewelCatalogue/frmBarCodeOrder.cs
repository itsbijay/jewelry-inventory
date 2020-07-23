using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using CrystalDecisions.Shared;
using JewelCatalogue.Properties;

namespace JewelCatalogue
{
    public partial class frmBarCodeOrder : BaseFormControl
    {
        private readonly ICatalogueService _catalogueService;
        private readonly IJewelService _jewelService;
        public List<QueryRequest> CatalogueRequest { get; set; }

        public frmBarCodeOrder()
        {
            InitializeComponent();
        }

        public frmBarCodeOrder(IJewelService jewelService, ICatalogueService catalogueService)
            : this()
        {
            _catalogueService = catalogueService;
            _jewelService = jewelService;
            CatalogueRequest = new List<QueryRequest>();
        }

        private enum FindJewelBy { JewelNo, StyleNo, }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            dgvJewel.Rows.Clear();
            txtBarCode.Text = String.Empty;
            txtStyleNo.Text = String.Empty;
            txtQuotationNo.Text = String.Empty;
            txtCustomerName.Text = String.Empty;
            lblTotal.Text = String.Empty;
            lblGoldWeight.Text = String.Empty;
            lblGrsWt.Text = String.Empty;
            lblDiamondWeight.Text = String.Empty;
            lblDiamondPieces.Text = String.Empty;
            CatalogueRequest = new List<QueryRequest>();
            txtBarCode.Focus();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CatalogueRequest.Count == 0)
            {
                MessageBox.Show(Resources.frmBarCodeOrder_btnProcess_Click_Please_select_Jewelno_for_Excel_Process_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBarCode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show(Resources.frmBarCodeOrder_btnProcess_Click_Please_enter_Customer_Name_for_Excel_Process_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Text = Resources.frmBarCodeOrder_btnProcess_Click_Jewel_Order_Report
            };
            orderReport.Show();

            Cursor = Cursors.Default;
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
                e.Handled = true;

            if (e.KeyChar == 13 && String.IsNullOrEmpty(txtBarCode.Text) == false)
            {
                FindJewel(FindJewelBy.JewelNo);
                txtBarCode.Text = String.Empty;
            }
        }

        private void FindJewel(FindJewelBy findParam)
        {
            foreach (DataGridViewRow dgvr in dgvJewel.Rows)
            {
                var findCode = "";
                var code = "";
                if (findParam == FindJewelBy.JewelNo)
                {
                    findCode = dgvr.Cells["JewelNo"].Value.ToString();
                    code = txtBarCode.Text;
                }
                else if (findParam == FindJewelBy.StyleNo)
                {
                    findCode = dgvr.Cells["StyleNo"].Value.ToString();
                    code = txtStyleNo.Text;
                }
                if (String.Compare(findCode, code, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    MessageBox.Show(findParam + Resources.frmBarCodeOrder_FindJewel__already_exists_Please_search_for_new_record_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBarCode.Text = String.Empty;
                    txtStyleNo.Text = String.Empty;
                    return;
                }
            }
            JewelMaster JewelData = null;
            if (findParam == FindJewelBy.JewelNo)
            {
                JewelData = _jewelService.GetJewelsByJewelNo(txtBarCode.Text);
            }
            else if (findParam == FindJewelBy.StyleNo)
            {
                JewelData = _jewelService.GetJewelsByStyleNo(txtStyleNo.Text);
            }

            if (JewelData == null)
            {
                MessageBox.Show(Resources.frmBarCodeOrder_FindJewel_Records_Not_found__);
                txtBarCode.Text = String.Empty;
                txtStyleNo.Text = String.Empty;
                return;
            }

            int _newRow = dgvJewel.RowCount;

            dgvJewel.Rows.Add(1);
            dgvJewel.Rows[_newRow].Cells[0].Value = true;
            dgvJewel.Rows[_newRow].Height = 100;
            dgvJewel.Rows[_newRow].Cells[2].Value = JewelData.JewelNo;
            dgvJewel.Rows[_newRow].Cells[3].Value = JewelData.StyleNo;
            dgvJewel.Rows[_newRow].Cells[4].Value = JewelData.JewelDescription;
            dgvJewel.Rows[_newRow].Cells[5].Value = JewelData.MetalColor;
            dgvJewel.Rows[_newRow].Cells[6].Value = ImageExtension.GetImageName(JewelData.StyleNo);
            dgvJewel.Rows[_newRow].Cells[7].Value = JewelData.DiamondPcs;
            dgvJewel.Rows[_newRow].Cells[8].Value = JewelData.DiamondWt;
            dgvJewel.Rows[_newRow].Cells[9].Value = JewelData.GrsWt;
            dgvJewel.Rows[_newRow].Cells[10].Value = JewelData.NetWt;
            dgvJewel[1, _newRow].Value = ImageExtension.ResolveImage(JewelData.StyleNo);

            dgvJewel.FirstDisplayedScrollingRowIndex = dgvJewel.RowCount - 1;

            CatalogueRequest.Add(new QueryRequest
                {
                    JewelNo = JewelData.JewelNo,
                    StyleNo = JewelData.StyleNo,
                });

            GetTotal();
        }

        private void txtStyleNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtStyleNo.Text != String.Empty)
            {
                FindJewel(FindJewelBy.StyleNo);
                GetTotal();
            }
        }

        private void GetTotal()
        {
            txtBarCode.Text = String.Empty;
            txtStyleNo.Text = String.Empty;
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

        private void dgvJewel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick(dgvJewel, e);
        }

        private void dgvJewel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJewel.Columns[e.ColumnIndex].CellType == typeof(DataGridViewCheckBoxCell))
            {
                GetTotal();
                if (Convert.ToBoolean(dgvJewel.Rows[e.RowIndex].Cells["select"].EditedFormattedValue))
                {
                    CatalogueRequest.Add(new QueryRequest
                        {
                            JewelNo = dgvJewel.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            StyleNo = dgvJewel.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        });
                }
                else
                {
                    CatalogueRequest.Remove(CatalogueRequest.FirstOrDefault(x => x.JewelNo == dgvJewel.Rows[e.RowIndex].Cells[2].Value.ToString()));
                }
            }
        }

        private void dgvJewel_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            CellMouseMove(dgvJewel, e);
        }

        private void txtQuotationNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lblGrsWt_Click(object sender, EventArgs e)
        {

        }

        private void lblGoldWeight_Click(object sender, EventArgs e)
        {

        }

        private void frmBarCodeOrder_Load(object sender, EventArgs e)
        {

        }

        private void lblDiamondPieces_Click(object sender, EventArgs e)
        {

        }

        private void lblDiamondWeight_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
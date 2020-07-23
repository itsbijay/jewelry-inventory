using System;
using System.Linq;
using System.Windows.Forms;
using Connections;
using System.Collections.Generic;
using JewelCatalogue.Properties;

namespace JewelCatalogue
{
    public partial class frmProduct : BaseFormControl
    {
        private readonly IJewelService _jewelService;

        int GridRow;
        int totalRecords, totalPages, pageNo, startRow;
        int pageNos, AddProductToGrid;
        const int PageSize = 10;
        frmCatalogue _owner;

        public frmProduct()
        {
            InitializeComponent();
        }

        public frmProduct(IJewelService jewelService)
            : this()
        {
            _jewelService = jewelService;
        }

        public frmCatalogue OWNERS
        {
            get { return _owner ?? (_owner = ((frmCatalogue) Owner)); }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            AddProductToGrid = OWNERS.AddRowToGrid;
            lblProductName.Text = OWNERS.JewelDescription;
            pageNo = 1;
            startRow = ((pageNo - 1) * PageSize);
            FillGrid(startRow);

            totalPages = Convert.ToInt32(totalRecords / PageSize);

            if (totalRecords % 10 > 0)
            {
                totalPages += 1;
            }
            cmbPageNos.Items.Clear();

            for (pageNos = 1; pageNos <= totalPages; pageNos++)
            {
                cmbPageNos.Items.Add(pageNos);
            }

            dgvJewel.Focus();
        }

        private void cmbPageNos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageNo = (Convert.ToInt32(cmbPageNos.SelectedItem));

            if (pageNo < 0 && pageNo > cmbPageNos.Items.Count)
            {
                MessageBox.Show(Resources.frmProduct_cmbPageNos_SelectedIndexChanged_No_such_PageNo_eixsts__Please_select_different_Page_No, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPageNos.Focus();
                return;
            }
            startRow = ((pageNo - 1) * PageSize);
            FillGrid(startRow);
        }

        private void FillGrid(int StartRow)
        {
            //var owner = (frmCatalogue)Owner;
            //var Jewels = _jewelService.GetCatalogueJewels(owner.FromJewel, owner.ToJewel, owner.JewelDescription, owner.SelectedWeight);

            IList<JewelMaster> Jewels;

            Jewels = OWNERS.HasFilters ? _jewelService.GetCatalogueJewels(OWNERS.Filters) : _jewelService.GetCatalogueJewels(OWNERS.FromJewel, OWNERS.ToJewel, OWNERS.JewelDescription, OWNERS.SelectedWeight);

            totalRecords = Jewels.Count;
            if (totalRecords == 0)
            {
                MessageBox.Show(Resources.frmProduct_FillGrid_Records_Not_found__);
                Close();
                return;
            }
            var JewelData = Jewels.Skip(StartRow).Take(10).ToList();

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
            }

            lblTotItems.Text = Resources.frmProduct_FillGrid_ + Convert.ToString(dgvJewel.RowCount);
            dgvJewel.Focus();
        }

        private void dgvJewel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = ((frmCatalogue)Owner).dgvJewel;
            try
            {
                if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "Select" & e.RowIndex >= 0)
                {
                    if (dgvJewel.Columns[e.ColumnIndex].CellType == typeof(DataGridViewCheckBoxCell))
                    {
                        int dl;
                        for (dl = 0; dl <= dataGridView.Rows.Count - 1; dl++)
                        {
                            if (dataGridView.Rows[dl].Cells[2].Value.ToString().Trim() == dgvJewel.Rows[e.RowIndex].Cells[2].Value.ToString().Trim())
                            {
                                MessageBox.Show(Resources.frmProduct_dgvJewel_CellContentClick_Record_already_exists_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgvJewel.Rows[e.RowIndex].Cells[0].Value = false;
                                return;
                            }
                        }

                        dataGridView.Rows.Add(1);
                        dataGridView.Rows[AddProductToGrid].Cells[0].Value = true;
                        dataGridView.Rows[AddProductToGrid].Height = 100;
                        dataGridView.Rows[AddProductToGrid].Cells[2].Value = dgvJewel.Rows[e.RowIndex].Cells[2].Value;
                        dataGridView.Rows[AddProductToGrid].Cells[3].Value = dgvJewel.Rows[e.RowIndex].Cells[3].Value;
                        dataGridView.Rows[AddProductToGrid].Cells[4].Value = dgvJewel.Rows[e.RowIndex].Cells[4].Value;
                        dataGridView.Rows[AddProductToGrid].Cells[5].Value = dgvJewel.Rows[e.RowIndex].Cells[5].Value;
                        dataGridView.Rows[AddProductToGrid].Cells[6].Value = dgvJewel.Rows[e.RowIndex].Cells[6].Value;
                        dataGridView.Rows[AddProductToGrid].Cells[7].Value = dgvJewel.Rows[e.RowIndex].Cells[7].Value;
                        dataGridView.Rows[AddProductToGrid].Cells[8].Value = dgvJewel.Rows[e.RowIndex].Cells[8].Value;
                        dataGridView.Rows[AddProductToGrid].Cells[9].Value = dgvJewel.Rows[e.RowIndex].Cells[9].Value;
                        dataGridView.Rows[AddProductToGrid].Cells[10].Value = dgvJewel.Rows[e.RowIndex].Cells[10].Value;

                        var styleno = dataGridView.Rows[AddProductToGrid].Cells[6].Value;
                        dataGridView[1, AddProductToGrid].Value = ImageExtension.ResolveImage(styleno.ToString());
                        dgvJewel[1, GridRow].Value = ImageExtension.ResolveImage(styleno.ToString());

                        dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.RowCount - 1;
                        AddProductToGrid = ((frmCatalogue)Owner).AddRowToGrid = ((frmCatalogue)Owner).AddRowToGrid + 1;

                        ((frmCatalogue)Owner).CatalogueRequest.Add(new QueryRequest()
                        {
                            JewelNo = dgvJewel.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            StyleNo = dgvJewel.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        });
                    }
                    ((frmCatalogue)Owner).GetTotal();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvJewel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            base.CellClick(dgvJewel, e);
        }

        private void dgvJewel_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.CellMouseMove(dgvJewel, e);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int NextPageNo;

            if (cmbPageNos.Text == Convert.ToString(cmbPageNos.Items.Count))
            {
                MessageBox.Show(Resources.frmProduct_btnNext_Click_This_is_the_Last_Page_, "Last Page", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(cmbPageNos.Text))
            {
                NextPageNo = 0;
                if (NextPageNo == cmbPageNos.Items.Count - 1)
                {
                    cmbPageNos.SelectedIndex = 0;
                    MessageBox.Show(Resources.frmProduct_btnNext_Click_This_is_the_Last_Page_, "Last Page", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                NextPageNo = NextPageNo + 1;
                cmbPageNos.SelectedIndex = NextPageNo;
            }
            else
            {
                NextPageNo = cmbPageNos.SelectedIndex;
                NextPageNo = NextPageNo + 1;
                cmbPageNos.SelectedIndex = NextPageNo;
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPageNos.Text) | cmbPageNos.SelectedIndex == 0)
            {
                cmbPageNos.SelectedIndex = 0;
                MessageBox.Show(Resources.frmProduct_btnPrevious_Click_This_is_the_First_Page_, "First Page", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var PreviousPageNo = cmbPageNos.SelectedIndex;
                PreviousPageNo = PreviousPageNo - 1;
                cmbPageNos.SelectedIndex = PreviousPageNo;
            }
        }

        private void frmProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}

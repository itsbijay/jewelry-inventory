using Connections;
using Connections.Dataset;
using CrystalDecisions.CrystalReports.Engine;
using JetCoders.Forms.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using JetCoders.Shared;
using JewelCatalogue.Properties;

namespace JewelCatalogue
{
    public partial class frmAllJewelsBarcodePrint : BaseFormControl
    {
        int GridRow;
        int totalRecords, totalPages, pageNo, startRow;
        int pageNos;
        const int PageSize = 10;
        readonly IQueryable<JewelMaster> Jewels;
        readonly IList<JewelMaster> SelectedJewels;

        public frmAllJewelsBarcodePrint()
        {
            InitializeComponent();
        }

        public frmAllJewelsBarcodePrint(IJewelService jewelService)
            : this()
        {
            SelectedJewels = new List<JewelMaster>();
            Jewels = jewelService.GetJewelMaster();
        }

        private void frmAllJewelsBarcodePrint_Load(object sender, EventArgs e)
        {
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
                MessageBox.Show(Resources.frmAllJewelsBarcodePrint_cmbPageNos_SelectedIndexChanged_No_such_PageNo_eixsts__Please_select_different_Page_No, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPageNos.Focus();
                return;
            }
            startRow = ((pageNo - 1) * PageSize);
            FillGrid(startRow);
        }

        private void FillGrid(int StartRow)
        {
            totalRecords = Jewels.Count();
            if (totalRecords == 0)
            {
                MessageBox.Show(Resources.frmAllJewelsBarcodePrint_FillGrid_Records_Not_found__);
                //Close();
                return;
            }
            var JewelData = Jewels.OrderBy(x=>x.JewelId).Skip(StartRow).Take(10).ToList();

            dgvJewel.Rows.Clear();
            SelectedJewels.Clear();
            GridRow = 0;

            foreach (var jewel in JewelData)
            {
                //Add data to grid.
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

                

                GridRow = GridRow + 1;
            }


            dgvJewel.Focus();
        }

        private void dgvJewel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                crystalReportViewer1.ReportSource = null;
                if (dgvJewel.Columns[e.ColumnIndex].CellType == typeof(DataGridViewCheckBoxCell))
                {
                    if (Convert.ToBoolean(dgvJewel.Rows[e.RowIndex].Cells["select"].EditedFormattedValue))
                    {
                        var jewelNo = dgvJewel.Rows[e.RowIndex].Cells[2].Value;

                        if (Jewels.Any())
                            SelectedJewels.Add(Jewels.SingleOrDefault(j => j.JewelNo == (string) jewelNo));
                    }
                    else
                    {
                        if (SelectedJewels.Any())
                            SelectedJewels.Remove(SelectedJewels.FirstOrDefault(x => x.JewelNo == dgvJewel.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    }

                    lblTotItems.Text = Resources.frmAllJewelsBarcodePrint_dgvJewel_CellContentClick_ + Convert.ToString(SelectedJewels.Count);
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
            SelectedJewels.Clear();

            int NextPageNo;

            if (cmbPageNos.Text == Convert.ToString(cmbPageNos.Items.Count))
            {
                MessageBox.Show(Resources.frmAllJewelsBarcodePrint_btnNext_Click_This_is_the_Last_Page_, "Last Page", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(cmbPageNos.Text))
            {
                NextPageNo = 0;
                if (NextPageNo == cmbPageNos.Items.Count - 1)
                {
                    cmbPageNos.SelectedIndex = 0;
                    MessageBox.Show(Resources.frmAllJewelsBarcodePrint_btnNext_Click_This_is_the_Last_Page_, "Last Page", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            crystalReportViewer1.ReportSource = null;
            SelectedJewels.Clear();
            if (string.IsNullOrEmpty(cmbPageNos.Text) | cmbPageNos.SelectedIndex == 0)
            {
                cmbPageNos.SelectedIndex = 0;
                MessageBox.Show(Resources.frmAllJewelsBarcodePrint_btnPrevious_Click_This_is_the_First_Page_, "First Page", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var PreviousPageNo = cmbPageNos.SelectedIndex;
                PreviousPageNo = PreviousPageNo - 1;
                cmbPageNos.SelectedIndex = PreviousPageNo;
            }
        }

        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            if (!SelectedJewels.Any())
            {
                MessageBox.Show(Resources.frmAllJewelsBarcodePrint_btnGenerateBarcode_Click_No_Jewel_selected_for_report_, "No Jewel selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var jewelMasterDataSet = new JewelMasterDataSet();
            var barcode = new BarcodeUtility();

            foreach (var jewel in SelectedJewels)
            {
                //Add data to crystal report.
                var jewelImage = barcode.MakeBarcodeImage(jewel.JewelNo);
                var jewelMasterRow = jewelMasterDataSet.Tables["JewelMaster"].NewRow();

                jewelMasterRow["JewelId"] = jewel.JewelId;
                jewelMasterRow["JewelNo"] = jewel.JewelNo;
                jewelMasterRow["StyleNo"] = jewel.StyleNo;
                jewelMasterRow["JewelDescription"] = jewel.JewelDescription;
                jewelMasterRow["MetalColor"] = jewel.MetalColor;
                jewelMasterRow["ImagePath"] = ImageExtension.GetImageName(jewel.StyleNo);
                jewelMasterRow["DiamondPcs"] = Convert.ToString(jewel.DiamondPcs);
                jewelMasterRow["DiamondWt"] = Convert.ToString(jewel.DiamondWt);
                jewelMasterRow["GrsWt"] = Convert.ToString(jewel.GrsWt);
                jewelMasterRow["NetWt"] = Convert.ToString(jewel.NetWt);
                jewelMasterRow["JewelImage"] = ImageConverterHelper.ImageToByteArray(jewelImage);

                jewelMasterDataSet.Tables["JewelMaster"].Rows.Add(jewelMasterRow);
            }

            if (File.Exists(Application.StartupPath + @"\" + ReportConstants.JEWELMASTERREPORTPATH))
            {
                var reportDocument = new ReportDocument();
                reportDocument.Load(Application.StartupPath + @"\" + ReportConstants.JEWELMASTERREPORTPATH);

                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.ReportSource = reportDocument;
                reportDocument.SetDataSource(jewelMasterDataSet);
                crystalReportViewer1.Refresh();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SelectedJewels.Clear();
            foreach (DataGridViewRow dgvr in dgvJewel.Rows)
            {
                dgvr.Cells[0].Value = true;

                var jewelNo = dgvr.Cells[2].Value.ToString();
                if (Jewels.Any())
                    SelectedJewels.Add(Jewels.SingleOrDefault(j => j.JewelNo == jewelNo));
            
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            if (SelectedJewels.Any())
            {
                foreach (DataGridViewRow dgvr in dgvJewel.Rows)
                {
                    dgvr.Cells[0].Value = false;

                    if (SelectedJewels.Any())
                        SelectedJewels.Remove(SelectedJewels.FirstOrDefault(x => x.JewelNo == dgvr.Cells[2].Value.ToString()));
                }
            }
            else
            {
                MessageBox.Show(Resources.frmAllJewelsBarcodePrint_btnDeselectAll_Click_It_is_already_deselected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSelectAll.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

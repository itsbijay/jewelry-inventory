using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Connections;
using CrystalDecisions.Windows.Forms;
using JetCoders.Shared;
using Connections.Dataset;
using JetCoders.Forms.UI;
using CrystalDecisions.CrystalReports.Engine;
using JewelCatalogue.Properties;

namespace JewelCatalogue
{
    public partial class frmJewelMaster :
#if ENABLE_RUNTIMEMODE
 frmNavigableForm<JewelMaster>,
#elif ENABLE_DESIGNMODE
     frmDataEntry
#endif
 INavigable
    {
        private readonly IJewelService _jewelService;
        private readonly IWinSettingProvider _winSettingProvider;
        public bool HasImage { get; set; }
        public frmJewelMaster()
        {
            InitializeComponent();
        }

        public frmJewelMaster(IJewelService jewelService, IWinSettingProvider winSettingProvider)
            : this()
        {
            _jewelService = jewelService;
            _winSettingProvider = winSettingProvider;
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;

            txtDiamondPcs.KeyPress += WinEvents.AllowNumber_KeyPress;
            txtDiamondWt.KeyPress += WinEvents.AllowNumeric_KeyPress;
            txtNetWt.KeyPress += WinEvents.AllowNumeric_KeyPress;
            txtGrsWt.KeyPress += WinEvents.AllowNumeric_KeyPress;

            BindForm();
        }

        private void BindForm()
        {
            fileDialog.Filter = Resources.frmJewelMaster_BindForm_All_Graphics_Types___jpg__JPG___jpg_;
            groupBox.Enabled = btnSave.Enabled = false;

            cboJewelDesc.DataSource = LocalStore.Products.GetProducts();
            QueryableItems = _jewelService.GetJewelMaster().OrderBy(x => x.JewelId);
            MDIForm.autoComplete.Items.Clear();

            if (QueryableItems != null)
            {
                BindValues(CurrentItem.Entity);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (base.IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            if (HasImage == false)
            {
                MessageBox.Show(Resources.frmJewelMaster_btnSave_Click_Please_select_file_to_upload_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            var jewelMaster = new JewelMaster();

            if (false == string.IsNullOrEmpty(txtJewelNo.Text))
                jewelMaster = _jewelService.GetJewelsByJewelNo(txtJewelNo.Text);

            decimal dimWt;
            if (!Decimal.TryParse(txtDiamondWt.Text, out dimWt))
            {
                MessageBox.Show(Resources.frmJewelMaster_btnSave_Click_Please_select_proper_dia_Wt_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            decimal netWt;
            if (!Decimal.TryParse(txtNetWt.Text, out netWt))
            {
                MessageBox.Show(Resources.frmJewelMaster_btnSave_Click_Please_select_proper_net_Wt_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            decimal grsWt;
            if (!Decimal.TryParse(txtGrsWt.Text, out grsWt))
            {
                MessageBox.Show(Resources.frmJewelMaster_btnSave_Click_Please_select_proper_grs_Wt_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            jewelMaster.StyleNo = txtStyleNo.Text;
            jewelMaster.JewelDescription = cboJewelDesc.Text;
            jewelMaster.MetalColor = cboMetalColor.Text;
            jewelMaster.DiamondPcs = Convert.ToInt32(txtDiamondPcs.Text);
            jewelMaster.DiamondWt = dimWt;
            jewelMaster.GrsWt = grsWt;
            jewelMaster.NetWt = netWt;
            jewelMaster.AccessedBy = 0;
            jewelMaster.AccessedDate = DateTime.Now;

            var filePath = Path.Combine(_winSettingProvider.ImageDirectory, ImageExtension.GetImageName(txtStyleNo.Text));
            if (File.Exists(fileDialog.FileName))
            {
                File.Copy(fileDialog.FileName, filePath, true);
            }

            var jewelRequest = new JewelMasterRequest()
            {
                JewelMaster = jewelMaster
            };

            var jewelMasterResponse = _jewelService.CreateJewelMaster(jewelRequest);

            if (false == jewelMasterResponse.IsValid)
            {
                MessageBox.Show(jewelMasterResponse.AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            groupBox.Enabled = btnSave.Enabled = false;
            btnPrintSticker.Enabled = true;

            GenerateBarcodeTag(jewelMaster);

            MessageBox.Show("Record saved!");
        }

        public override void ToolStripItems_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Add":
                    {
                        ClearFields();
                        MdiMode = FormMode.Add;
                        groupBox.Enabled = true;
                        btnPrintSticker.Enabled = false;
                        break;
                    }
                case "Edit":
                    {
                        MdiMode = FormMode.Edit;
                        groupBox.Enabled = true;
                        btnPrintSticker.Enabled = true;
                        break;
                    }
                case "Refresh":
                    {
                        MdiMode = FormMode.Normal;
                        BindForm();
                        break;
                    }
                case "Search":
                    {
                        var search = MDIForm.autoComplete.Text;
                        if (search.IsEmpty())
                            return;

                        var user = QueryableItems.ToList().FirstOrDefault(x => x.StyleNo == search);
                        MDIForm.autoComplete.Text = String.Empty;
                        if (user == null)
                        {
                            MessageBox.Show("Records not found !", Constants.ALERTMESSAGEHEADER);
                            return;
                        }

                        break;
                    }
            }

            base.MDIAction();
            base.ToolStripItems_Clicked(sender, e);
        }

        private void ClearFields()
        {
            txtJewelNo.Text = "";
            txtStyleNo.Text = "";
            cboJewelDesc.Text = "";
            cboMetalColor.Text = "";
            txtDiamondPcs.Text = "";
            txtDiamondWt.Text = "";
            txtNetWt.Text = "";
            txtGrsWt.Text = "";
            jewelPictureBox.Image = null;
            crystalReportViewer1.ReportSource = null;
        }

        #region INavigable

        public FormMode MdiMode { get; set; }

        public bool HasNext
        {
            get { return CurrentItem.HasNextRecord; }
        }

        public bool HasPrev
        {
            get { return CurrentItem.HasPreviousRecord; }
        }

        #endregion

        public override void BindValues(JewelMaster entity)
        {
            if (entity == null) return;
            btnPrintSticker.Enabled = true;

            txtJewelNo.Text = entity.JewelNo;
            txtStyleNo.Text = entity.StyleNo;
            cboJewelDesc.Text = entity.JewelDescription;
            cboMetalColor.Text = entity.MetalColor;
            txtDiamondPcs.Text = Convert.ToString(entity.DiamondPcs);
            txtDiamondWt.Text = Convert.ToString(entity.DiamondWt);
            txtNetWt.Text = Convert.ToString(entity.NetWt);
            txtGrsWt.Text = Convert.ToString(entity.GrsWt);

            var imagePath = Path.Combine(_winSettingProvider.ImageDirectory, ImageExtension.GetImageName(entity.StyleNo));
            {
                if (File.Exists(imagePath))
                {
                    HasImage = true;
                    using (var img = Image.FromFile(imagePath))
                        jewelPictureBox.Image = img.Clone<Image>();
                }
                else
                {
                    HasImage = false;
                    jewelPictureBox.Image = Image.FromFile(Application.StartupPath + @"\Resource\TirthJewels.JPG");
                }
            }
            GenerateBarcodeTag(entity);
        }

        private void GenerateBarcodeTag(JewelMaster entity)
        {
            var jewelMasterDataSet = new JewelMasterDataSet();

            var barcode = new BarcodeUtility();
            var jewelImage = barcode.MakeBarcodeImage(entity.JewelNo);
            var jewelMasterRow = jewelMasterDataSet.Tables["JewelMaster"].NewRow();

            jewelMasterRow["JewelId"] = entity.JewelId;
            jewelMasterRow["JewelNo"] = entity.JewelNo;
            jewelMasterRow["StyleNo"] = entity.StyleNo;
            jewelMasterRow["JewelDescription"] = entity.JewelDescription;
            jewelMasterRow["MetalColor"] = entity.MetalColor;
            jewelMasterRow["ImagePath"] = ImageExtension.GetImageName(entity.StyleNo);
            jewelMasterRow["DiamondPcs"] = Convert.ToString(entity.DiamondPcs);
            jewelMasterRow["DiamondWt"] = Convert.ToString(entity.DiamondWt);
            jewelMasterRow["GrsWt"] = Convert.ToString(entity.GrsWt);
            jewelMasterRow["NetWt"] = Convert.ToString(entity.NetWt);
            jewelMasterRow["JewelImage"] = ImageConverterHelper.ImageToByteArray(jewelImage);

            jewelMasterDataSet.Tables["JewelMaster"].Rows.Add(jewelMasterRow);

            if (!File.Exists(Application.StartupPath + @"\" + ReportConstants.JEWELMASTERREPORTPATH)) 
                return;

            var reportDocument = new ReportDocument();
            reportDocument.Load(Application.StartupPath + @"\" + ReportConstants.JEWELMASTERREPORTPATH);
            reportDocument.SetDataSource(jewelMasterDataSet);
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }

        private void btnimgUpload_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();

        }

        private void fileDialog_FileOk(object sender, CancelEventArgs e)
        {
            using (fileDialog.OpenFile())
            {
                jewelPictureBox.Image = Image.FromStream(fileDialog.OpenFile());
                HasImage = true;
            }
        }

        private void btnPrintSticker_Click(object sender, EventArgs e)
        {
            if (CurrentItem != null)
            {
                var frm = new frmJewelMasterDetails();
                frm.BindForm(CurrentItem.Entity);
                frm.Show();
            }
        }

        private void txtGrsWt_Leave(object sender, EventArgs e)
        {
            if (txtDiamondWt.Text != string.Empty && txtNetWt.Text != string.Empty)
            {
                txtGrsWt.Text = (Convert.ToDecimal(txtDiamondWt.Text) + Convert.ToDecimal(txtNetWt.Text)).ToString();
            }
        }
    }
}
using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using Connections;
using System.IO;
using System.Diagnostics;
using JewelCatalogue.Properties;

namespace JewelCatalogue
{
    public partial class frmMDIParent : BaseFormControl
    {
        //TODO: Search box is not disabling even when form is closed
        private readonly IWinSettingProvider _iWinSettingProvider;

        public frmMDIParent(IWinSettingProvider IWinSettingProvider)
        {
            InitializeComponent();
            toolStrip.ItemClicked += SetMDIMode;
            _iWinSettingProvider = IWinSettingProvider;
        }

        #region MenuItems

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmAboutBox>(null);
        }

        private void frmMDIParent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void manageJewelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (false == new DirectoryInfo(_iWinSettingProvider.ImageDirectory).Exists)
                if (MessageBox.Show(Resources.frmMDIParent_manageJewelsToolStripMenuItem_Click_Image_Directory_path_not_set____please_click_ok_to_set_it_now_, Constants.ALERTMESSAGEHEADER, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ShowManagedForm<frmSettings>(this);
                    return;
                }
                else return;

            ShowManagedForm<frmJewelMaster>(this);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmSettings>(this);
        }

        private void marketingCatalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmBarCodeOrder>(this);
        }

        private void firmInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmCatalogue>(this);
        }

        private void printTagForAllJewelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmAllJewelsBarcodePrint>(this);
        }
        #endregion

        #region Application

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void _terminate()
        {
            if (MessageBox.Show(Resources.frmMDIParent__terminate_Are_you_sure_want_to_exit__, Resources.frmMDIParent__terminate_Exit_Application, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        #endregion

        private void frmMDIParent_Load(object sender, EventArgs e)
        {
            if (false == new DirectoryInfo(_iWinSettingProvider.ImageDirectory).Exists) lblError.Text = Resources.frmMDIParent_frmMDIParent_Load_Image_Directory_path_not_set____please_set_it_from_Tools____App_Settings__;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(LocalStore.SceenBitMap, 0, 0);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _terminate();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.frmMDIParent_deleteToolStripButton_Click_Are_you_sure_want_to_delete_jewel_record_, Constants.ALERTMESSAGEHEADER, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //
            }
        }

        private void toolStripSearch_Click(object sender, EventArgs e)
        {

        }

        private void helpbtn_Click(object sender, EventArgs e)
        {
            Process.Start("Jewel_Catalog.mht");
        }
    }
}

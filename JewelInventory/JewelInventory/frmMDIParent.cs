using System;
using System.Windows.Forms;
using Connections;
using JetCoders.Forms.UI;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmMDIParent : BaseFormControl
    {
        private readonly IWinSettingProvider _iWinSettingProvider;
        private readonly IConfigurationService _configurationService;

        public frmMDIParent(IWinSettingProvider IWinSettingProvider, IConfigurationService configurationService)
        {
            InitializeComponent();
            toolStrip.ItemClicked += SetMDIMode;
            _iWinSettingProvider = IWinSettingProvider;
            _configurationService = configurationService;
        }

        #region MenuItems
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            _terminate();
        }

        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
            autoComplete.Visible = toolBarToolStripMenuItem.Checked;
            btnPrint.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmSupplierDataEntry>(this);
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmManageTransaction>(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmAboutBox>(null);
        }

        private void mnuFinYear_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmFinancialYear>(this);
        }

        private void frmMDIParent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mnuconnectiontoDB_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmConnection>(null);
        }

        private void userSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmManageUser>(this);
        }

        private void newTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ShowCostingForm(JewelItemCategory.Alloy);
        }
        private void goldTrnsactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCostingForm(JewelItemCategory.Gold);
        }
        private void silverTrnsactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCostingForm(JewelItemCategory.Silver);
        }
        private void ShowCostingForm(JewelItemCategory type)
        {
            frmCostingBase.MetalType = type;
            ShowManagedForm<frmCostingBase>(this);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmCustomerDataEntry>(this);
        }
        private void mnuConfiguration_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmConfiguration>(this);
        }
        private void mastersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmMasterReport>(this);
        }
        private void jewelTransactionsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmJewelTransactionsReport>(this);
        }

        private void marketingMemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMemoOrder.ApprovalSelection = false;
            ShowManagedForm<frmMemoOrder>(this);
        }

        private void approvalMemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMemoOrder.ApprovalSelection = true;
            ShowManagedForm<frmMemoOrder>(this);
        }
        private void firmInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmFirmMaster>(this);
        }
        private void taxInvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmTaxInvoiceReport>(this);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmSettings>(this);
        }
        private void manageLooseDiamondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmLooseDiamonds>(this);
        }

        private void salesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmSalesOrder>(this);
        }
        private void costingValuationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmCostingValuation>(this);
        }
        private void cutomerSupplierTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmPartyTransaction>(this);
        }
        private void masterMaintainanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmMasterMaintenance>(this);
        }
        private void jewelHistroyLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmJewelHistory>(this);
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
            username.Text = LocalStore.CurrentUser.Properties.FullName();
            this.Text = Constants.INVENTORYPRODUCT_TTITLE;

            if (false == new DirectoryInfo(_iWinSettingProvider.ImageDirectory).Exists)
            {    
                EmptyLabel.Text = Resources.frmMDIParent_frmMDIParent_Load_Image_Directory_path_not_set____please_set_it_from_Tools____App_Settings__;
                EmptyLabel.ForeColor = Color.Red;
            }
            
            CheckUserAccess();
        }

        public void CheckUserAccess()
        {
            if (LocalStore.CurrentUser.LoginInformations.UserType != UserType.SuperUser)
            {
                mnuconnectiontoDB.Enabled = false;
                mnuFinYear.Enabled = false;
                userSetupToolStripMenuItem.Enabled = false;
                costingValuationToolStripMenuItem.Enabled = false;
                mnuConfiguration.Enabled = false;
                backupToolStripMenuItem.Enabled = false;
            }

            if (String.IsNullOrEmpty(_configurationService.GetCurrentFinancialYearCode))
            {
                if (MessageBox.Show(Resources.frmMDIParent_CheckUserAccess_, Constants.ALERTMESSAGEHEADER, MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ShowManagedForm<frmFinancialYear>(this);
                }
            }
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.frmMDIParent_backupToolStripMenuItem_Click_Are_you_sure_want_to_close_current_application, Constants.ALERTMESSAGEHEADER, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Process.Start("BackupRestore.exe");
                Application.Exit();
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(LocalStore.SceenBitMap, 0, 0);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            LocalStore.SceenBitMap = this.CaptureScreen();
            if (LocalStore.SceenBitMap != null)
            {
                if (ActiveMdiChild != null)
                    printDocument.Print();
            }
        }

        private void jewelStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmJewelStockReport>(this);
        }

        private void helpbtn_Click(object sender, EventArgs e)
        {
            Process.Start("steps.pdf");
        }

        private void company_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("www.jetcodersolutions.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void creditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmCreditNote>(this);
        }

        private void masterMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmMasterMaintenance>(this);
        }

        private void purchaseTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmLooseDiamonds>(this);
        }

        private void masterMaintenanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmMasterMaintenance>(this);
        }

        private void salesReturnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManagedForm<frmSalesReturnTransactions>(this);
        }
    }
}

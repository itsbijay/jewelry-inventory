using System;
using System.Windows.Forms;
using System.IO;
using Connections;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmSettings : BaseFormControl
    {
        public frmSettings(IWinSettingProvider settingProvider)
        {
            InitializeComponent();
            var settingProvider1 = settingProvider;

            txtImagePath.Text = settingProvider1.ImageDirectory;
            txtExcelPath.Text = settingProvider1.ExcelDirectory;
        }

        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            txtImagePath.Text = OpenFolderBrowserDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtImagePath.Text) || String.IsNullOrEmpty(txtExcelPath.Text)) return;

            switch (new DirectoryInfo(txtImagePath.Text).Exists || new DirectoryInfo(txtExcelPath.Text).Exists == false)
            {
                case false:
                    MessageBox.Show(Resources.frmSettings_btnSave_Click_Please_enter_proper_folder_path, Resources.frmSettings_btnSave_Click_Error___Folder_Path_Not_Found, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    CoreSettings.UpdateAppSettings("appSettings", Constants.IMAGEDIRECTORY, txtImagePath.Text);
                    CoreSettings.UpdateAppSettings("appSettings", Constants.STOCKUPLOADMANULMODE, rdomanual.Checked.ToString());
                    CoreSettings.UpdateAppSettings("appSettings", Constants.EXCELDIRECTORY, txtExcelPath.Text);

                    MessageBox.Show(Resources.frmSettings_btnSave_Click_Setting_are_Saved, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }

        private void btnExcelBrowse_Click(object sender, EventArgs e)
        {
            txtExcelPath.Text = OpenFolderBrowserDialog();
        }

        private string OpenFolderBrowserDialog()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }

            return "";
        }
    }
}

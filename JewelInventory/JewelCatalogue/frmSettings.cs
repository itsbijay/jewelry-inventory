using System;
using System.Windows.Forms;
using System.IO;
using Connections;
using JewelCatalogue.Properties;

namespace JewelCatalogue
{
	public partial class frmSettings : BaseFormControl
    {
	    public frmSettings(IWinSettingProvider settingProvider)
        {
            InitializeComponent();

            txtImagePath.Text = settingProvider.ImageDirectory;
        }

        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtImagePath.Text)) return;

            switch (new DirectoryInfo(txtImagePath.Text).Exists)
            {
                case false:
                    MessageBox.Show(Resources.frmSettings_btnSave_Click_Please_enter_proper_folder_path, Resources.frmSettings_btnSave_Click_Error___Folder_Path_Not_Found, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    CoreSettings.UpdateAppSettings("appSettings", Constants.IMAGEDIRECTORY, txtImagePath.Text);
                    MessageBox.Show("Image Path is Saved! \napplication will close now. please start it again to take effect;", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
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
    }
}

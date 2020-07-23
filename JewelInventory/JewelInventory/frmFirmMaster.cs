using System;
using System.Drawing;
using System.Windows.Forms;
using Connections;
using System.IO;
using System.Text.RegularExpressions;
using JetCoders.Shared;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmFirmMaster : frmDataEntry
    {
        readonly IFirmService _firmService;
        public frmFirmMaster()
        {
            InitializeComponent();
        }
        public frmFirmMaster(IFirmService firmService)
            : this()
        {
            _firmService = firmService;

            BindForm();
        }

        private void BindForm()
        {
            grpContainer.Enabled = false;
            btnSave.Enabled = false;

            var firmInfo = _firmService.GetFrimMaster();

            if (firmInfo == null)
                return;

            txtName.Text = firmInfo.FirmName;
            txtEmail.Text = firmInfo.FirmEmail;
            txtHeaderOrSlogan.Text = firmInfo.FirmHeader;

            txtWebsite.Text = firmInfo.FirmWebsite;
            txtVATNumber.Text = firmInfo.FirmVATNumber;
            txtTINNumber.Text = firmInfo.FirmTINNumber;
            txtTAX.Text = firmInfo.Tax.ToString();
            txtOtherTAX.Text = firmInfo.OtherTax.ToString();
            txtTopHeader.Text = firmInfo.FirmTopHeader;
            txtAddress.Text = firmInfo.FirmAddress;
            txtAdditionalInformation.Text = firmInfo.FirmAdditionalInfo;

            if (firmInfo.FirmLogo != null)
            {
                picLogo.Image = ImageConverterHelper.ByteArrayToImage(firmInfo.FirmLogo);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }
            if (txtEmail.Text != String.Empty && !Regex.IsMatch(txtEmail.Text, Constants.EMAILPATTERN))
            {
                txtEmail.Focus();
                MessageBox.Show(Resources.frmFirmMaster_btnSave_Click_Please_Enter_Valid_Email_Address_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            if (!txtTAX.Text.IsEmpty() && !txtTAX.Text.IsDecimal())
            {
                MessageBox.Show(Resources.frmFirmMaster_btnSave_Click_Invalid_TAX_field, Constants.ALERTMESSAGEHEADER);
                return;
            }

            if (!txtOtherTAX.Text.IsEmpty() && !txtOtherTAX.Text.IsDecimal())
            {
                MessageBox.Show(Resources.frmFirmMaster_btnSave_Click_Invalid_Other_TAX_field, Constants.ALERTMESSAGEHEADER);
                return;
            }

            if(!txtLogo.Text.IsEmpty() && !File.Exists(txtLogo.Text))
            {
                MessageBox.Show(Resources.frmFirmMaster_btnSave_Click_Invalid_file_Logo_path_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            var firmInfo = _firmService.GetFrimMaster();

            var firmMaster = new FirmMaster
                {
                    FirmName = txtName.Text,
                    FirmEmail = txtEmail.Text,
                    FirmHeader = txtHeaderOrSlogan.Text,
                    FirmWebsite = txtWebsite.Text,
                    FirmVATNumber = txtVATNumber.Text,
                    FirmTINNumber = txtTINNumber.Text,
                    FirmTopHeader = txtTopHeader.Text,
                    FirmAddress = txtAddress.Text,
                    FirmAdditionalInfo = txtAdditionalInformation.Text,
                    Tax = Convert.ToDecimal(txtTAX.Text),
                    OtherTax = Convert.ToDecimal(txtOtherTAX.Text),
                };

            if (firmInfo != null)
                firmMaster.FirmMasterId = firmInfo.FirmMasterId;

            if (File.Exists(txtLogo.Text))
            {
                var imageIn = Image.FromFile(txtLogo.Text);
                File.ReadAllBytes(txtLogo.Text);
                firmMaster.FirmLogo = ImageConverterHelper.ImageToByteArray(imageIn);
            }

            var firmRequest = new FirmMasterRequest
                {
                    FirmMaster = firmMaster
                };

            _firmService.SaveFirm(firmRequest);
            BindForm();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = @"Image Files(*.JPG;*.PNG)|*.PNG;*.JPG;"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtLogo.Text = openFileDialog.FileName;
            }
        }

        private void lnkEditFirmInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpContainer.Enabled = true;
            btnSave.Enabled = true;
            
        }

        private void frmFirmMaster_Load(object sender, EventArgs e)
        {

        }

        private void txtHeaderOrSlogan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

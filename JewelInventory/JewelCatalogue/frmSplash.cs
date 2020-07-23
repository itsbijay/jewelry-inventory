using Connections;
using JetCoders.Forms.UI;
using System;

namespace JewelCatalogue
{
    public partial class frmSplash : BaseFormControl
    {
        public frmSplash()
        {
            InitializeComponent();
        }

		private void frmSplash_Load(object sender, EventArgs e)
		{
            lblTitle.Text = Constants.CATALOGUEPRODUCT_TITLE;
            lblLicensee.Text = Constants.PRODUCTLICENSEE;
            lblVersion.Text = JewelHelper.AssemblyVersion;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
				timer1.Enabled = false;
				Hide();

                ShowManagedForm<frmMDIParent>(null);
		}
    }
}

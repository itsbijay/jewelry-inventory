using System;
using System.Windows.Forms;
using System.Diagnostics;
using JetCoders.Forms.UI;

namespace JewelInventory
{
    partial class frmAboutBox : BaseFormControl
	{
		public frmAboutBox()
		{
			InitializeComponent();
			Text = String.Format("About {0}", JewelHelper.AssemblyTitle);

			var linkEmail = new LinkLabel.Link {LinkData = "info@jetcodersolutions.com"};
		    linkLabelEmail.Links.Add(linkEmail);

            var linkWeb = new LinkLabel.Link {LinkData = "http://www.jetcodersolutions.com"};
		    linkLabelWebsite.Links.Add(linkWeb);
		}

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void okButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void linkLabelEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				// Send the URL to the operating system.
				Process.Start("mailto:" + e.Link.LinkData);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void linkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(e.Link.LinkData as string);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void frmAboutBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}

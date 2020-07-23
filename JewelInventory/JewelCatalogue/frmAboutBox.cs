using System;
using System.Windows.Forms;
using System.Diagnostics;
using JetCoders.Forms.UI;

namespace JewelCatalogue
{
	partial class frmAboutBox : Form
	{
		public frmAboutBox()
		{
			InitializeComponent();
			Text = String.Format("About {0}", JewelHelper.AssemblyTitle);

			var linkWeb = new LinkLabel.Link {LinkData = "http://www.jetcodersolutions.com"};
		    linkLabelWebsite.Links.Add(linkWeb);

			var linkEmail = new LinkLabel.Link {LinkData = "info@jetcodersolutions.com"};
		    linkLabelEmail.Links.Add(linkEmail);
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
				// Send the URL to the operating system.
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

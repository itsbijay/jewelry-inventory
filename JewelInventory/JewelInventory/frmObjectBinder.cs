using System;
using System.Drawing.Printing;
using Connections;
using JetCoders.Forms.UI;

namespace JewelInventory
{
	public partial class frmObjectBinder : BaseFormControl
	{
		public frmObjectBinder()
		{
			InitializeComponent();
		}
		public void BindForm(object FormDataSource, string FormTitle)
		{
			Text = FormTitle;
			groupBox1.Text = FormTitle;
			dgDataControl.DataSource = FormDataSource;
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void chkAllowOnTop_CheckedChanged(object sender, EventArgs e)
		{
			TopMost = chkAllowOnTop.Checked;
		}
		private void btnPrint_Click(object sender, EventArgs e)
		{
			btnPrint.Visible = false;
			btnPrint.SendToBack();

			LocalStore.SceenBitMap = this.CaptureScreen();
			if (LocalStore.SceenBitMap != null)
			{
				printDocument.Print();
			}

			btnPrint.Visible = true;
			btnPrint.BringToFront();
		}

	    private void printDocument_PrintPage_1(object sender, PrintPageEventArgs e)
	    {
	        e.Graphics.DrawImage(LocalStore.SceenBitMap, 0, 0);
	    }
	}
}
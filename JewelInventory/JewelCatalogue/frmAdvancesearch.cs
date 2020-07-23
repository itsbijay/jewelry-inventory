using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JewelCatalogue.Properties;

namespace JewelCatalogue
{
	public partial class frmAdvancesearch : BaseFormControl
	{
	    readonly List<Tuple<Decimal, Decimal, String>> data = new List<Tuple<Decimal, Decimal, String>>();

	    public frmAdvancesearch()
		{
			InitializeComponent();
			
			foreach (var crtl in grpFilter.Controls)
			{
				if (crtl is TextBox)
				{
					(crtl as TextBox).KeyPress += new KeyPressEventHandler(dest);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (
				(txtWtDiaWtFr.Text == "" || txtWtDiaWtTo.Text == "") &&
				(txtGrWtFm.Text == "" || txtGrWtTo.Text == "") &&
				(txtNetWtFm.Text == "" || txtNetWtTo.Text == "") &&
				(txtDiaPcsFm.Text == "" || txtDiaPcsTo.Text == "")
				)
			{
				MessageBox.Show(Resources.frmAdvancesearch_button2_Click_Please_enter_valid_range_of_Weight__, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtWtDiaWtFr.Focus();
				return;
			}

			if ((txtWtDiaWtFr.Text != "" && txtWtDiaWtTo.Text != ""))
			{
                data.Add(new Tuple<decimal, decimal, string>(Decimal.Parse(txtWtDiaWtFr.Text), Decimal.Parse(txtWtDiaWtTo.Text), "DiamondWt"));
			}

			if ((txtGrWtFm.Text != "" && txtGrWtTo.Text != ""))
			{
                data.Add(new Tuple<decimal, decimal, string>(Decimal.Parse(txtGrWtFm.Text), Decimal.Parse(txtGrWtTo.Text), "NetWt"));
			}

			if ((txtNetWtFm.Text != "" && txtNetWtTo.Text != ""))
			{
                data.Add(new Tuple<decimal, decimal, string>(Decimal.Parse(txtNetWtFm.Text), Decimal.Parse(txtNetWtTo.Text), "GrsWt"));
			}

			if ((txtDiaPcsFm.Text != "" && txtDiaPcsTo.Text != ""))
			{
                data.Add(new Tuple<decimal, decimal, string>(Decimal.Parse(txtDiaPcsFm.Text), Decimal.Parse(txtDiaPcsTo.Text), "DiamondPcs"));
			}
			((frmCatalogue)Owner).SetUpAdvanceFilters(data);

			Close();
		}

		private void frmAdvancesearch_Load(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
		}
	}
}

using System;
using System.Drawing.Printing;
using System.Linq;
using Connections;
using JetCoders.Forms.UI;

namespace JewelInventory
{
	public partial class frmItemDetail : BaseFormControl
	{
		public frmItemDetail()
		{
			InitializeComponent();
		}
		private StoneChart _chart;

		public void BindForm(ItemDetail item)
		{
			CertificateCharges.Text = item.CertificateCharges.ToString("C");
			DesignCode.Text = item.DesignCode;
			ItemCategory.Text = item.ItemCategory;
			ItemDesc.Text = item.ItemDescription;
			LabourCharges.Text = item.LabourCharges.ToString("C");
			MetalNetAmount.Text = item.MetalDetail.MetalNetAmount.ToString("C");
			MetalNetWt.Text = item.MetalDetail.MetalNetWt.ToString();
			MetalType.Text = item.MetalDetail.MetalType;
			StoneNetAmount.Text = item.StoneDetail.StoneNetAmount.ToString("C");
            lblTotalAmount.Text = item.Amount.ToString("C");
			StoneNetWt.Text = item.StoneDetail.StoneNetWt.ToString();
			StoneType.Text = item.StoneDetail.StoneType;
			TotalWeight.Text = item.TotalWeight.ToString();
            lblStamping.Text = item.StampingCharges.ToString("C");
			CStpe.Text = item.ColorStoneDetail.ColorStoneType;
			CSwt.Text = item.ColorStoneDetail.ColorStoneNetWt.ToString();
			CSnamt.Text = item.ColorStoneDetail.ColorStoneNetAmount.ToString("C");

			_chart = item.StoneDetail.StoneChart;

			TotalStonePcs.Text = item.StoneDetail.TotalStonePcs != 0 ? item.StoneDetail.TotalStonePcs.ToString()
									: item.ColorStoneDetail.ColorTotalStonePcs.ToString();

			JewelNumber.Text = item.DesignCode;
            pictureBox.Image = ImageExtension.ResolveImage(item.DesignCode);
		}

		private void btnStoneChart_Click(object sender, EventArgs e)
		{
			if (_chart == null)
				return;

			var bindingObject = (from list in _chart.StoneMetaDetailList
								 select new { StoneSieveSize = list.StoneSieveSz, StonePieces = list.StonePcs, StoneValue = list.StoneValue.ToString("C"), StoneWt = list.StoneWt.ToString() }).ToList();

			var frm = new frmObjectBinder();
			frm.BindForm(bindingObject, "StoneMeta Detail");
			frm.Show();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			LocalStore.SceenBitMap = this.CaptureScreen();
			if (LocalStore.SceenBitMap != null)
			{
				printDocument.Print();
			}
		}

		private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			e.Graphics.DrawImage(LocalStore.SceenBitMap, 0, 0);
		}

        private void ItemDesc_Click(object sender, EventArgs e)
        {

        }

        private void ItemCategory_Click(object sender, EventArgs e)
        {

        }

        private void TotalWeight_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
	}
}

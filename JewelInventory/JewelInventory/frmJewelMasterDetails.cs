using System;
using Connections;
using JetCoders.Forms.UI;

namespace JewelInventory
{
    public partial class frmJewelMasterDetails : BaseFormControl
    {
        public frmJewelMasterDetails()
        {
            InitializeComponent();
        }

        public void BindForm(JewelStockLedger jewelStockLedger)
        {
            lblJewelNoValue.Text =  jewelStockLedger.JewelNumber;
            lblStyleNoValue.Text = jewelStockLedger.DesignCode;
            //lblJewelDescValue.Text = jewelStockLedger.JewelDescription;
            //lblMetalColorValue.Text = Convert.ToString(jewelStockLedger.MetalColor);
            lblDiamondPcsValue.Text = Convert.ToString(jewelStockLedger.StonePcs);
            lblDiamondWtValue.Text = Convert.ToString(jewelStockLedger.StoneWeight);
            lblGoldPcsValue.Text = Convert.ToString(0.00);
            lblGoldWtValue.Text = Convert.ToString(jewelStockLedger.StoneWeight);
            pictureBox.Image = ImageExtension.ResolveImage(jewelStockLedger.DesignCode);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            LocalStore.SceenBitMap = this.CaptureScreen();
            if (LocalStore.SceenBitMap != null)
            {
                printDocument.Print();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

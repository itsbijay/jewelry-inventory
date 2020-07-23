using System;
using Connections;
using JetCoders.Forms.UI;

namespace JewelCatalogue
{
    public partial class frmJewelMasterDetails : BaseFormControl
    {
        public frmJewelMasterDetails()
        {
            InitializeComponent();
        }

        public void BindForm(JewelMaster JewelMaster)
        {
            lblJewelNoValue.Text =  JewelMaster.JewelNo;
            lblStyleNoValue.Text = JewelMaster.StyleNo;
            //lblJewelDescValue.Text = jewelStockLedger.JewelDescription;
            //lblMetalColorValue.Text = Convert.ToString(jewelStockLedger.MetalColor);
            lblDiamondPcsValue.Text = Convert.ToString(JewelMaster.DiamondPcs);
            lblDiamondWtValue.Text = Convert.ToString(JewelMaster.DiamondWt);
            lblGrsWtValue.Text = Convert.ToString(JewelMaster.GrsWt);
            lblNetWtValue.Text = Convert.ToString(JewelMaster.NetWt);

            pictureBox.Image = ImageExtension.ResolveImage(JewelMaster.StyleNo);
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

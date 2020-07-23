using System;
using System.Drawing;
using JetCoders.Forms.UI.GenCode128;

namespace JetCoders.Forms.UI
{
	public class BarcodeUtility
	{
		public const int BARWEIGHT = 1;
		public Image MakeBarcodeImage(String barcodeTest)
		{
			Image myimg = Code128Rendering.MakeBarcodeImage(barcodeTest, BARWEIGHT, true);
			return myimg;
		}		
	}
}

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace JetCoders.Forms.UI
{
	public static class FormExtension
	{
		[DllImport("gdi32.dll")]
		public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

		public static Bitmap CaptureScreen(this Form form)
		{
		    Form formvar;

			if (form.IsMdiContainer && form.ActiveMdiChild != null)
			{
				formvar = form.ActiveMdiChild;
			}
			else
			{
				formvar = form;
			}

			Graphics mygraphics = formvar.CreateGraphics();
			Size s = formvar.Size;
			var memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
			Graphics memoryGraphics = Graphics.FromImage(memoryImage);
			IntPtr dc1 = mygraphics.GetHdc();
			IntPtr dc2 = memoryGraphics.GetHdc();
			BitBlt(dc2, 0, 0, formvar.ClientRectangle.Width, formvar.ClientRectangle.Height, dc1, 0, 0, 13369376);
			mygraphics.ReleaseHdc(dc1);
			memoryGraphics.ReleaseHdc(dc2);

			return memoryImage;
		}
	}
}

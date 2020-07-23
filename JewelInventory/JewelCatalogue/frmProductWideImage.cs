using System.Windows.Forms;

namespace JewelCatalogue
{
    public partial class frmProductWideImage : BaseFormControl
	{
		public frmProductWideImage()
		{
			InitializeComponent();
		}

		private void frmProductWideImage_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Hide();
			}
		}
	}
}

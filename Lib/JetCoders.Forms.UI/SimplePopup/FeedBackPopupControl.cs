using System.Windows.Forms;
using PopupControl;

namespace JetCoders.Forms.UI
{
    public partial class FeedBackPopupControl : UserControl
    {
		public FeedBackPopupControl()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            var popup = Parent as Popup;
            if (popup != null && popup.ProcessResizing(ref m))
            {
                return;
            }
            base.WndProc(ref m);
        }
    }
}

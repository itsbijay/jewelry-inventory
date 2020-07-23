using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace JetCoders.Forms.UI
{
    public partial class CustomToolTip : UserControl
    {
        public CustomToolTip()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Brush b = new LinearGradientBrush(ClientRectangle, Color.White, BackColor, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(b, ClientRectangle);
            }
            using (var p = new Pen(Color.FromArgb(118, 118, 118)))
            {
                Rectangle rect = ClientRectangle;
                rect.Width--;
                rect.Height--;
                e.Graphics.DrawRectangle(p, rect);
            }
        }
    }
}

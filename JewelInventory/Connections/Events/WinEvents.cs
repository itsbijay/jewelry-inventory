using System.Windows.Forms;

namespace Connections
{
    public class WinEvents
    {
        public static void AllowNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && ((TextBox) sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        public static void AllowNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || char.IsControl(e.KeyChar))
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }
    }
}

using System;
using System.Windows.Forms;
using JewelCatalogue.Properties;

namespace JewelCatalogue
{
	public partial class frmDataEntry : BaseFormControl
	{
		public frmDataEntry()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
			MDIAction();
		}

		private void frmDataEntry_FormClosing(object sender, FormClosingEventArgs e)
		{
            if (IsEdited)
            {
                DialogResult dr = MessageBox.Show(Resources.frmDataEntry_frmDataEntry_FormClosing_You_haven_t_saved_your_data_, Resources.frmDataEntry_frmDataEntry_FormClosing_Are_you_sure_you_want_to_Exit_, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr != DialogResult.Yes)
                {
                    IsEdited = false;
                    e.Cancel = true;
                }
            }	
		}

		public virtual void ToolStripItems_Clicked(object sender, ToolStripItemClickedEventArgs e)
		{
			//do nothing
		}

		private void frmDataEntry_FormClosed(object sender, FormClosedEventArgs e)
		{
			MDIAction();
		}

        public bool IsEdited { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IsEdited = false;
        }
	}
}
using System;

namespace JewelInventory
{
    public partial class frmCostingValuation : frmDataEntry
    {
        public frmCostingValuation()
        {
            InitializeComponent();
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today.AddYears(-1);
        }
    }
}

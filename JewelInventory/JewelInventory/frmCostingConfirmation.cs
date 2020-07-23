using Connections;
using System;
using System.Linq;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmCostingConfirmation : BaseFormControl
    {
        private readonly IReportUtility _reportUitility;

        public frmCostingConfirmation()
        {
            InitializeComponent();
        }

        public frmCostingConfirmation(IReportUtility reportUitility)
            : this()
        {
            _reportUitility = reportUitility;
        }

        private void frmContingConfirmation_Load(object sender, EventArgs e)
        {
            var jewelTransactions = FormData as TransactionLookup;
            label1.Text = jewelTransactions.TransactionType.GetDescription() + Resources.frmCostingConfirmation_frmContingConfirmation_Load__Data_Saved_Successfuly;
            btnPrintTag.Click += delegate { ShowManagedModalForm<frmBarcodePrinter>(this, jewelTransactions); };
            btnPrintSticker.Click += delegate { _reportUitility.ShowStickerReport(jewelTransactions.JewelTransactions.Select(x => x.JewelNumber).ToArray()); };
            btnCostingSheet.Click += delegate { _reportUitility.ShowCostingReport(jewelTransactions.JewelTransactions.Select(x => x.JewelTransactionId).ToList()); };
            btnClose.Click += delegate { Close(); };
        }
    }
}

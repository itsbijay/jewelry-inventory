using System;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmMasterMaintenance : frmDataEntry
    {
        private readonly ITransactionService _transactionService;

        public frmMasterMaintenance()
        {
            InitializeComponent();
        }

        public frmMasterMaintenance(ITransactionService transactionService)
            : this()
        {
            _transactionService = transactionService;
            BindFormData();
        }

        private void BindFormData()
        {
            cboJewelNumber.SelectedIndexChanged -= cboJewelNumber_SelectedIndexChanged;
            cboJewelNumber.SelectedIndexChanged += cboJewelNumber_SelectedIndexChanged;

            cboHeads.SelectedIndexChanged -= cboHeads_SelectedIndexChanged;
            cboHeads.SelectedIndexChanged += cboHeads_SelectedIndexChanged;
            cboJewelNumber.DataSource = null;
            cboJewelNumber.DataSource = _transactionService.GetJewelStockLedgers()
                                        .Where(x => x.StockStatus_Enum == (short)StockStatus.ItemIsInStock && x.JewelState_Enum == (short)JewelState.NotSet);

            cboJewelNumber.SelectedIndex = -1;
            cboHeads.SelectedIndex = -1;
        }

        private void cboJewelNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboJewelNumber.SelectedIndex == -1)
            {
                grpEditor.Enabled = true;
            }
        }

        private void cboHeads_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboJewelNumber.SelectedIndex == -1 || cboHeads.SelectedIndex == -1)
                return;

            var ledger = cboJewelNumber.SelectedValue as JewelStockLedger;

            switch (cboHeads.SelectedItem.ToString())
            {
                case "CertificateNumber":
                    txtOldValue.Text = ledger.CertificateNumber;
                    txtNewValue.Text = string.Empty;
                    break;
                case "DesignCode":
                    txtOldValue.Text = ledger.DesignCode;
                    txtNewValue.Text = string.Empty;
                    break;
                case "Cancel Transactoion":
                    txtOldValue.Text = ledger.StockStatus.GetDescription();
                    txtNewValue.Text = TransactionType.CancelledTransaction.GetDescription();
                    break;
                case "MetalColor":
                    txtOldValue.Text = ledger.MetalColor;
                    txtNewValue.Text = string.Empty;
                    break;
                default:
                    txtOldValue.Text = string.Empty;
                    txtNewValue.Text = string.Empty;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            if (cboJewelNumber.SelectedIndex == -1)
                return;

            var ledger = (JewelStockLedger)cboJewelNumber.SelectedValue;
            var request = new JewelUpdateRequest(ledger.JewelNumber)
            {
                CertificateNumber = ledger.CertificateNumber,
                DesignCode = ledger.DesignCode,
                MetalColor = ledger.MetalColor
            };

            switch (cboHeads.SelectedItem.ToString())
            {
                case "CertificateNumber":
                    request.CertificateNumber = txtNewValue.Text;
                    break;
                case "DesignCode":
                    request.DesignCode = txtNewValue.Text;
                    break;
                case "Cancel Transactoion":
                    request.IsCancelled = true;
                    break;
                case "MetalColor":
                    request.MetalColor = txtNewValue.Text;
                    break;
            }

            _transactionService.UpdateJewelDetail(request);
            MessageBox.Show(Resources.frmMasterMaintenance_btnSave_Click_);
            BindFormData();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JetCoders.Shared;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmJewelHistory : frmDataEntry
    {
        private readonly ITransactionService _transactionService;

        public frmJewelHistory()
        {
            InitializeComponent();
        }

        public frmJewelHistory(ITransactionService transactionService)
            : this()
        {
            _transactionService = transactionService;
            txtJewelNumber.KeyPress += delegate { txtDesignCode.Text = string.Empty; txtCertiNo.Text = string.Empty; };
            txtDesignCode.KeyPress += delegate { txtJewelNumber.Text = string.Empty; txtCertiNo.Text = string.Empty; };
            txtCertiNo.KeyPress += delegate { txtJewelNumber.Text = string.Empty; txtDesignCode.Text = string.Empty; };

        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            if (txtJewelNumber.Text.IsEmpty() && txtDesignCode.Text.IsEmpty() && txtCertiNo.Text.IsEmpty())
            {
                MessageBox.Show(Resources.frmJewelHistory_btnShowHistory_Click_Please_enter_jewelnumber_or_design_code_);
                return;
            }
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }
            List<JewelTransaction> table = null;
            if (!txtJewelNumber.Text.IsEmpty())
            {
              table =  _transactionService.GetJewelTransactions().Where(x => x.JewelNumber.ToLower() == txtJewelNumber.Text.ToLower()).OrderByDescending(x => x.AccessedDate).ToList();
            }
            else if (!txtDesignCode.Text.IsEmpty())
            {
                table =_transactionService.GetJewelTransactions().Where(x => x.DesignCode.ToLower() == txtDesignCode.Text.ToLower()).OrderByDescending(x => x.AccessedDate).ToList();
            }
            else if (!txtCertiNo.Text.IsEmpty())
            {
                table=_transactionService.GetJewelTransactions().Where(x => x.CertificateNumber.ToLower() == txtCertiNo.Text.ToLower()).OrderByDescending(x => x.AccessedDate).ToList();
            }

            if (!table.Any())
            {
                MessageBox.Show(Resources.frmJewelHistory_btnShowHistory_Click_No_transaction_found_, Constants.ALERTMESSAGEHEADER);
                return;
            }
            FindTransaction(table);
        }

        private void btnShowHistoryRecords()
        {
            if (txtJewelNumber.Text.IsEmpty() && txtDesignCode.Text.IsEmpty() && txtCertiNo.Text.IsEmpty())
            {
                MessageBox.Show(Resources.frmJewelHistory_btnShowHistory_Click_Please_enter_jewelnumber_or_design_code_);
                return;
            }
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }
            List<JewelTransaction> table = null;
            if (!txtJewelNumber.Text.IsEmpty())
            {
                table = _transactionService.GetJewelTransactions().Where(x => x.JewelNumber.ToLower() == txtJewelNumber.Text.ToLower()).OrderByDescending(x => x.AccessedDate).ToList();
            }
            else if (!txtDesignCode.Text.IsEmpty())
            {
                table = _transactionService.GetJewelTransactions().Where(x => x.DesignCode.ToLower() == txtDesignCode.Text.ToLower()).OrderByDescending(x => x.AccessedDate).ToList();
            }
            else if (!txtCertiNo.Text.IsEmpty())
            {
                table = _transactionService.GetJewelTransactions().Where(x => x.CertificateNumber.ToLower() == txtCertiNo.Text.ToLower()).OrderByDescending(x => x.AccessedDate).ToList();
            }

            if (!table.Any())
            {
                MessageBox.Show(Resources.frmJewelHistory_btnShowHistory_Click_No_transaction_found_, Constants.ALERTMESSAGEHEADER);
                return;
            }
            FindTransaction(table);
        }
        private void FindTransaction(IEnumerable<JewelTransaction> table)
        {
            var ds = table.Select(j =>
                new
                {
                    j.TransactionDate,
                    TransactionType = j.TransactionType.GetDescription(),
                    PartyCode = j.TransactionPartyRef,
                    j.JewelType,
                    j.JewelNumber,
                    j.CertificateNumber,
                    j.DesignCode,
                    MetalType = j.JewelItemCategory.ToString(),
                    j.KT,
                    GrossWeight = j.TotalWeight,
                    NetWeight = j.MetalWeight,
                    j.MetalColor,
                    DiaPcs = j.StonePcs,
                    DiaWt = j.StoneWeight,
                    CSStonePcs = j.CStonePcs,
                    CSStoneWt = j.CStoneWeight,
                    j.TotalAmount
                }).ToList();
            dgvJewel.DataSource = ds;

            dgvJewel.ReadOnly = true;

            // Resize the DataGridView columns to fit the newly loaded content.
            dgvJewel.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCells);

            foreach (DataGridViewColumn column in dgvJewel.Columns)
            {
                var dataGridViewColumn = dgvJewel.Columns[column.Name];

                if (dataGridViewColumn != null)
                    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void txtJewelNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void ondgDataControlKeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Test");

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnShowHistoryRecords();
            }
        }
    }
}

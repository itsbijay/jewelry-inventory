using Connections;
using System;
using System.Linq;
using System.Windows.Forms;

namespace JewelInventory
{
    public partial class frmLookupDetails : frmDataEntry
    {
        public frmLookupDetails()
        {
            InitializeComponent();
        }

        private void BindTransaction()
        {

            var jewels = (TransactionLookup) FormData;
            var ds = jewels.JewelTransactions.Select(j =>
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
                dgvJewel.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void frmLookupDetails_Load(object sender, EventArgs e)
        {
            BindTransaction();
        }
    }
}

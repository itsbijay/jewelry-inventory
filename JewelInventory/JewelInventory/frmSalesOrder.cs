using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JetCoders.Forms.UI;
using JetCoders.Shared;
using JewelInventory.Properties;
using outlook = Microsoft.Office.Interop.Outlook;

namespace JewelInventory
{
    public partial class frmSalesOrder : frmDataEntry
    {
        private const string _columnselectchk = "SELECT";
        private const string _columnimage = "IMAGE";
        private const string _columnjewelnumber = "JEWEL NUMBER";
        private const string _columntype = "PRODUCTSNAME";
        private const string _columndesigncode = "DESIGN CODE";
        private const string _columngoldkt = "KT";
        private const string _columntotalwt = "TOTAL WEIGHT";
        private const string _columnmetalweight = "METAL WEIGHT";
        private const string _columndiamondweight = "DIAMOND.WT";
        private const string _columndiapcs = "DIAMOND.PCS";
        private const string _columncolwt = "COL.WEIGHT";
        private const string _columncolpcs = "COL.PCS";

        private const string _columntotalAmount = "TOTALAMOUNT";

        readonly ITransactionService _transactionServices;
        readonly ICustomerService _customerServices;
        readonly IFirmService _firmServices;

        public frmSalesOrder()
        {
            InitializeComponent();
        }

        public frmSalesOrder(ITransactionService transactionServices, ICustomerService customerServices,
                             IFirmService firmServices)
            : this()
        {
            _transactionServices = transactionServices;
            _customerServices = customerServices;
            _firmServices = firmServices;
            dtSalesDt.Value = DateTime.Today;
            { ConfigDataGridView(dgvJewel); }
            BindMemoForm();
        }

        #region GridFormaing
        public void ConfigDataGridView(DataGridView mapGrid)
        {
            mapGrid.Columns.Add(GridExtension.GetCheckBxColumn(_columnselectchk));
            mapGrid.Columns.Add(GridExtension.GetImageColumn(_columnimage));
            GridExtension.FormatImageCell(mapGrid, _columnimage.ToLowerCaseColumnName());

            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntype, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnjewelnumber, true));

            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columndesigncode, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columngoldkt, true));

            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntotalwt, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnmetalweight, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columndiamondweight, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columndiapcs, true));

            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columncolwt, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columncolpcs, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntotalAmount, true));
        }
        #endregion

        private void BindMemoForm()
        {
            cboCustomer.DataSource = _customerServices.GetActiveCustomers();
            cboCustomer.SelectedIndex = -1;

            btnPrev.Visible = btnNext.Visible = false;
            btnSave.Click += OnbtnSaveClick;
            txtNetAmount.TextChanged += OnNetAmttextChanged;
        }

        void CalculateTotal()
        {
            lblTotal.Text = Convert.ToString(TotalRows);
            lblGrossWeight.Text = Convert.ToString(GrossWeight);
            lblNetWeight.Text = Convert.ToString(NetWeight);
            lblDiamondWeight.Text = Convert.ToString(DiamondWeight);
            lblDiamondPieces.Text = Convert.ToString(DiamondPieces);
            txtNetAmount.Text = TotalAmount.ToString(CultureInfo.InvariantCulture);
        }

        #region GridTotalRowsCalculation
        private decimal GetTotal(string colname)
        {
            var value = default(decimal);

            foreach (DataGridViewRow dgvr in dgvJewel.Rows)
            {
                if ((bool)dgvr.Cells[_columnselectchk.ToLowerCaseColumnName()].EditedFormattedValue)
                {
                    value = value + Convert.ToDecimal(dgvr.Cells[colname].Value);
                }
            }
            return value;
        }

        public int TotalRows
        {
            get
            {
                int i = 0;
                foreach (DataGridViewRow dgvr in dgvJewel.Rows)
                {
                    if ((bool)dgvr.Cells[_columnselectchk.ToLowerCaseColumnName()].EditedFormattedValue)
                    {
                        i = i + 1;
                    }
                }
                return i;
            }
        }

        decimal GrossWeight { get { return GetTotal(_columntotalwt.ToLowerCaseColumnName()); } }
        decimal NetWeight { get { return GetTotal(_columnmetalweight.ToLowerCaseColumnName()); } }
        decimal DiamondWeight { get { return GetTotal(_columndiamondweight.ToLowerCaseColumnName()); } }
        decimal DiamondPieces { get { return GetTotal(_columndiapcs.ToLowerCaseColumnName()); } }
        decimal TotalAmount { get { return GetTotal(_columntotalAmount.ToLowerCaseColumnName()); } }
        #endregion

        void OnbtnSaveClick(object sender, EventArgs e)
        {
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }
            if (TotalRows == 0)
            {
                MessageBox.Show(Resources.frmSalesOrder_OnbtnSaveClick_Please_select_jewels_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            var request = new SalesTransactionRequest();
            var lookup = new TransactionLookup
            {
                ContactName = txtContactName.Text,
                Remarks = txtRemarks.Text,
                TransactionPartyRef = ((Customer)cboCustomer.SelectedItem).CustomersCode,
                TransactionType = TransactionType.SalesInTransaction
            };
            var tranLookupKey = Guid.NewGuid();
            foreach (DataGridViewRow row in dgvJewel.Rows)
            {
                var chk = (DataGridViewCheckBoxCell)row.Cells[_columnselectchk.ToLowerCaseColumnName()];
                if ((bool)chk.Value)
                {
                    var trno = (int)row.Cells[_columnselectchk.ToLowerCaseColumnName()].Tag;
                    var jewelTran = _transactionServices.GetJewelTransactionsById(trno);
                    var tran = new JewelTransaction
                    {
                        JewelTransactionRowId = tranLookupKey,
                        TransactionType = TransactionType.SalesInTransaction,
                        CostingDetail = jewelTran.CostingDetail,
                        CertificateNumber = jewelTran.CertificateNumber,
                        CStonePcs = jewelTran.CStonePcs,
                        CStoneWeight = jewelTran.CStoneWeight,
                        DesignCode = jewelTran.DesignCode,
                        JewelNumber = jewelTran.JewelNumber,
                        JewelType = jewelTran.JewelType,
                        KT = jewelTran.KT,
                        MetalColor = jewelTran.MetalColor,
                        JewelItemCategory = jewelTran.JewelItemCategory,
                        MetalWeight = jewelTran.MetalWeight,
                        Properties = jewelTran.Properties,
                        StonePcs = jewelTran.StonePcs,
                        StoneWeight = jewelTran.StoneWeight,
                        TotalAmount = jewelTran.TotalAmount,
                        TotalWeight = jewelTran.TotalWeight,
                        TransactionDate = dtSalesDt.Value, 
                        TransactionPartyRef = ((Customer)cboCustomer.SelectedItem).CustomersCode,
                    };

                    lookup.JewelTransactions.Add(tran);
                }
            }

            request.TransactionLookup = lookup;

            var invoice = new TransactionInvoices
            {
                InvoiceDate = dtSalesDt.Value,
                NetAmount = Convert.ToDecimal(txtTotalAmount.Text),
                PaymentTerm = cboPaymentTerm.SelectedText,
                Remarks = txtRemarks.Text
            };

            var customer = cboCustomer.SelectedValue as Customer;
            invoice.TransactionPartyRef = customer.CustomersCode;
            request.TransactionInvoice = invoice;

            var response = _transactionServices.CreateSalesTransaction(request);
            if (response.IsValid == false)
            {
                MessageBox.Show(response.AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            btnGo.Enabled = false;
            btnSave.Enabled = false;
            btnInvoice.Enabled = true;

            ShowManagedModalForm<frmCostingConfirmation>(Owner as frmMDIParent, response.TransactionLookup);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            var customer = (Customer)cboCustomer.SelectedValue;
            var ledger = _transactionServices.GetJewelStockLedgers();
            dgvJewel.Rows.Clear();

            var jewelTransactions = from tran in _transactionServices.GetJewelTransactions()
                                    join lg in ledger on tran.JewelNumber equals lg.JewelNumber
                                    where lg.JewelState_Enum == (short)JewelState.OnApproval
                                    && lg.StockStatus_Enum == (short)StockStatus.ItemOutOfStock
                                    && tran.TransactionLookup.TransactionPartyRef == customer.CustomersCode
                                    && tran.TransactionType_Enum == (short)TransactionType.ApprovalTransaction
                                    && tran.UpdatedTransactionBy == null
                                    select tran;

            foreach (var tran in jewelTransactions)
            {
                var _newRowNumber = dgvJewel.RowCount;
                dgvJewel.Rows.Add(1);
                dgvJewel.Rows[_newRowNumber].Height = 50;

                dgvJewel.Rows[_newRowNumber].Cells[_columnselectchk.ToLowerCaseColumnName()].Value = false;
                dgvJewel.Rows[_newRowNumber].Cells[_columnselectchk.ToLowerCaseColumnName()].Tag = tran.JewelTransactionId;
                dgvJewel.Rows[_newRowNumber].Cells[_columnjewelnumber.ToLowerCaseColumnName()].Value = tran.JewelNumber;
                dgvJewel.Rows[_newRowNumber].Cells[_columndesigncode.ToLowerCaseColumnName()].Value = tran.DesignCode;
                dgvJewel.Rows[_newRowNumber].Cells[_columntype.ToLowerCaseColumnName()].Value = tran.JewelItemCategory;
                dgvJewel.Rows[_newRowNumber].Cells[_columngoldkt.ToLowerCaseColumnName()].Value = tran.KT;
                dgvJewel.Rows[_newRowNumber].Cells[_columntotalwt.ToLowerCaseColumnName()].Value = tran.TotalWeight;
                dgvJewel.Rows[_newRowNumber].Cells[_columnmetalweight.ToLowerCaseColumnName()].Value = tran.MetalWeight;
                dgvJewel.Rows[_newRowNumber].Cells[_columndiamondweight.ToLowerCaseColumnName()].Value = tran.StoneWeight;
                dgvJewel.Rows[_newRowNumber].Cells[_columndiapcs.ToLowerCaseColumnName()].Value = tran.StonePcs;
                dgvJewel.Rows[_newRowNumber].Cells[_columncolwt.ToLowerCaseColumnName()].Value = tran.CStoneWeight;
                dgvJewel.Rows[_newRowNumber].Cells[_columncolpcs.ToLowerCaseColumnName()].Value = tran.CStonePcs;
                dgvJewel.Rows[_newRowNumber].Cells[_columntotalAmount.ToLowerCaseColumnName()].Value = tran.TotalAmount;
                dgvJewel[_columnimage.ToLowerCaseColumnName(), _newRowNumber].Value = ImageExtension.ResolveImage(tran.DesignCode);

                dgvJewel.FirstDisplayedScrollingRowIndex = dgvJewel.RowCount - 1;
            }
        }

        public void OnNetAmttextChanged(object sender, EventArgs e)
        {
            var setting = _firmServices.GetFrimMaster();

            txtVat.Text = (Convert.ToDecimal(txtNetAmount.Text) * (setting.Tax / 100)).ToString();
            txtOC.Text = (Convert.ToDecimal(txtNetAmount.Text) * (setting.OtherTax / 100)).ToString();

            txtTotalAmount.Text = Math.Max(Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtVat.Text) + Convert.ToDecimal(txtOC.Text), 0).ToString();
        }

        private void dgvJewel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvJewel[e.ColumnIndex, e.RowIndex] is DataGridViewCheckBoxCell)
                CalculateTotal();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            //var oApp = new outlook.Application();
            //var oMailItem = (outlook._MailItem)oApp.CreateItem(outlook.OlItemType.olMailItem);
            //oMailItem.Display(true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JetCoders.Forms.UI;
using JetCoders.Shared;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmManageTransaction : frmDataEntry
    {
        private const string _columntrno = "TRNO";
        private const string _columnselectchk = "SELECT";
        private const string _columnimage = "IMAGE";
        private const string _columnjewelnumber = "JEWEL NUMBER";
        private const string _columndesigncode = "DESIGN CODE";
        private const string _columntotalwt = "TOTAL WEIGHT";
        private const string _columnmetalweight = "METAL WEIGHT";
        private const string _columnmetalcolor = "METAL COLOR";
        private const string _columnstoneweight = "DIAMOND.WT";
        private const string _columnstonepcs = "DIAMOND .PCS";
        private const string _columncstoneweight = "COL.WT";
        private const string _columncstonepcs = "COL.PCS";
        private const string _columndetails = "DETAILS";
        private const string _columnstate = "STATE";

        readonly ITransactionService _transactionServices;
        readonly ICustomerService _customerServices;
        readonly IReportUtility _reportUitility;
        readonly ISupplierService _supplierService;

        TransactionType TransactionType { get; set; }

        public frmManageTransaction()
        {
            InitializeComponent();
        }

        public frmManageTransaction(ITransactionService transactionServices, ICustomerService customerServices, ISupplierService supplierService, IReportUtility reportUitility)
            : this()
        {
            _transactionServices = transactionServices;
            _customerServices = customerServices;
            _reportUitility = reportUitility;
            _supplierService = supplierService;

            { ConfigDataGridView(dgvJewel); }

            { BindMemoForm(); }
        }

        private void BindMemoForm()
        {
            cboTranType.SelectedIndexChanged += oncboTranTypeChanged;
            cboTranType.DataSource = Enum.GetNames(typeof(TransactionType));

            cboCustomer.DataSource = _customerServices.GetActiveCustomers();
            cboSupplier.DataSource = _supplierService.GetActiveSuppliers();

            cboCustomer.SelectedIndexChanged += oncboPartyChanged;
            cboSupplier.SelectedIndexChanged += oncboPartyChanged;

            cboCustomer.SelectedIndex = cboSupplier.SelectedIndex = -1;

            lnkRTS.Visible = false;

            btnSave.Enabled = false;
        }

        void oncboPartyChanged(object sender, EventArgs e)
        {
            var cbo = (ComboBox)sender;

            if (cboTranType.SelectedIndex == -1 || cbo.SelectedItem == null)
                return;

            TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), cboTranType.SelectedItem.ToString());

            var partyRef = TransactionType == TransactionType.PurchaseTransaction ? ((Supplier)cbo.SelectedItem).SupplierCode : ((Customer)cbo.SelectedItem).CustomersCode;

            cboTran.DataSource = _transactionServices
                .GetJewelTransactionsLookUp(TransactionType).Where(x => x.TransactionPartyRef == partyRef);

            cboTran.SelectedIndex = -1;
        }

        void oncboTranTypeChanged(object sender, EventArgs e)
        {
            if (cboTranType.SelectedIndex == -1)
                return;
            cboTran.DataSource = null;

            TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), cboTranType.SelectedItem.ToString());

            if (TransactionType == TransactionType.PurchaseTransaction)
            {
                grpCustomer.SendToBack();
                grpSupplier.BringToFront();
            }
            else
            {
                grpCustomer.BringToFront();
                grpSupplier.SendToBack();
            }
        }

        public void ConfigDataGridView(DataGridView mapGrid)
        {
            mapGrid.Columns.Add(GridExtension.GetCheckBxColumn(_columnselectchk, true));
            mapGrid.Columns.Add(GridExtension.GetImageColumn(_columnimage));
            GridExtension.FormatImageCell(mapGrid, _columnimage.ToLowerCaseColumnName());

            mapGrid.Columns.Add(GridExtension.GetButtonColumn(_columndetails));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnjewelnumber, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columndesigncode, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntotalwt, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnmetalweight, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnmetalcolor, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnstoneweight, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnstonepcs, true));

            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columncstoneweight, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columncstonepcs, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnstate, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntrno, true, true));

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (cboTran.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.frmManageTransaction_btnGo_Click_Please_select_transaction, Constants.ALERTMESSAGEHEADER);
                return;
            }

            var lookup = (TransactionLookup)cboTran.SelectedItem;
            dgvJewel.Rows.Clear();

            FindJewelByJewelNo(lookup);
            chkSelectAll.Checked = true;
            if (TransactionType == TransactionType.MarketingTransaction || TransactionType == TransactionType.ApprovalTransaction)
            {
                lnkRTS.Visible = true;
            }
        }

        private void FindJewelByJewelNo(TransactionLookup lookup)
        {
            int _newRowNumber = dgvJewel.RowCount;

            foreach (var Jeweldetail in lookup.JewelTransactions)
            {
                dgvJewel.Rows.Add(1);
                dgvJewel.Rows[_newRowNumber].Height = 50;

                dgvJewel.Rows[_newRowNumber].Cells[_columnselectchk.ToLowerCaseColumnName()].Value = true;

                dgvJewel.Rows[_newRowNumber].Cells[_columnjewelnumber.ToLowerCaseColumnName()].Value = Jeweldetail.JewelNumber;
                dgvJewel.Rows[_newRowNumber].Cells[_columndesigncode.ToLowerCaseColumnName()].Value = Jeweldetail.DesignCode;
                dgvJewel.Rows[_newRowNumber].Cells[_columntotalwt.ToLowerCaseColumnName()].Value = Jeweldetail.TotalWeight;
                dgvJewel.Rows[_newRowNumber].Cells[_columnmetalweight.ToLowerCaseColumnName()].Value = Jeweldetail.MetalWeight;
                dgvJewel.Rows[_newRowNumber].Cells[_columnmetalcolor.ToLowerCaseColumnName()].Value = Jeweldetail.MetalColor;
                dgvJewel.Rows[_newRowNumber].Cells[_columnstoneweight.ToLowerCaseColumnName()].Value = Jeweldetail.StoneWeight;
                dgvJewel.Rows[_newRowNumber].Cells[_columndesigncode.ToLowerCaseColumnName()].Value = Jeweldetail.DesignCode;
                dgvJewel.Rows[_newRowNumber].Cells[_columnstonepcs.ToLowerCaseColumnName()].Value = Jeweldetail.StonePcs;
                dgvJewel.Rows[_newRowNumber].Cells[_columncstoneweight.ToLowerCaseColumnName()].Value = Jeweldetail.CStoneWeight;
                dgvJewel.Rows[_newRowNumber].Cells[_columncstonepcs.ToLowerCaseColumnName()].Value = Jeweldetail.CStonePcs;
                dgvJewel.Rows[_newRowNumber].Cells[_columntrno.ToLowerCaseColumnName()].Value = Jeweldetail.JewelTransactionId;

                var state = _transactionServices.GetJewelStockByJewelNo(Jeweldetail.JewelNumber);
                dgvJewel.Rows[_newRowNumber].Cells[_columnstate.ToLowerCaseColumnName()].Value = state.StockStatus.GetDescription();

                dgvJewel.Rows[_newRowNumber].Cells[_columndetails.ToLowerCaseColumnName()].Value = "Details";
                dgvJewel.Rows[_newRowNumber].Cells[_columndetails.ToLowerCaseColumnName()].Tag = Jeweldetail.JewelTransactionId;
                dgvJewel[_columnimage.ToLowerCaseColumnName(), _newRowNumber].Value = ImageExtension.ResolveImage(Jeweldetail.DesignCode);

                _newRowNumber = _newRowNumber + 1;

                dgvJewel.FirstDisplayedScrollingRowIndex = dgvJewel.RowCount - 1;
            }
        }

        private void dgvJewel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var value = dgvJewel[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (value == "Details")
            {
                var transactionId = (int)dgvJewel[e.ColumnIndex, e.RowIndex].Tag;
                var item = _transactionServices.GetJewelTransactionsById(transactionId);
                var detail = new frmItemDetail();
                detail.BindForm(item.Properties.ItemDetails);
                detail.Show();
            }
        }

        private void dgvJewel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1)
            {
                var ImageWide = new frmProductWideImage
                {
                    pbProductImage = {Image = (Image) dgvJewel[_columnimage.ToLowerCaseColumnName(), e.RowIndex].Value},
                    lblStyleName =
                    {
                        Text = Convert.ToString(dgvJewel[_columndesigncode.ToLowerCaseColumnName(), e.RowIndex].Value)
                    },
                    Text = Convert.ToString(dgvJewel[_columndesigncode.ToLowerCaseColumnName(), e.RowIndex].Value),
                    lblColor =
                    {
                        Text = Convert.ToString(dgvJewel[_columnmetalcolor.ToLowerCaseColumnName(), e.RowIndex].Value)
                    },
                    lblGoldWt =
                    {
                        Text = Convert.ToString(dgvJewel[_columnmetalweight.ToLowerCaseColumnName(), e.RowIndex].Value)
                    },
                    lblDiWt =
                    {
                        Text = Convert.ToString(dgvJewel[_columncstoneweight.ToLowerCaseColumnName(), e.RowIndex].Value)
                    },
                    lblDiPcs =
                    {
                        Text = Convert.ToString(dgvJewel[_columnstonepcs.ToLowerCaseColumnName(), e.RowIndex].Value)
                    }
                };
                ImageWide.Show();
            }
        }

        private void lnkRTS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var isYes = MessageBox.Show(Resources.frmManageTransaction_lnkRTS_LinkClicked_Are_you_sure_want_to_return_stock_into_account, Resources.frmManageTransaction_lnkRTS_LinkClicked_Return_To_Stock, MessageBoxButtons.OKCancel) == DialogResult.OK;

            if (isYes)
            {
                var transactionType = (TransactionType == TransactionType.MarketingTransaction) ? TransactionType.MarketingInReturnTransaction :
                                      (TransactionType == TransactionType.ApprovalTransaction ? TransactionType.ApprovalInReturnTransaction : TransactionType.NotSet);

                var request = new JewelTransactionRequest();
                var memoNumber = (cboTran.SelectedValue as TransactionLookup).MemoNumber;

                var lookup = _transactionServices.GetJewelTransactionsLookUp().Single(x => x.MemoNumber == memoNumber);
                var clookup = new TransactionLookup
                {
                    Remarks = lookup.Remarks,
                    TransactionPartyRef = lookup.TransactionPartyRef,
                    ContactName = lookup.ContactName,
                    DocNumber = lookup.DocNumber,
                    TransactionLookupId = 0,
                    TransactionDate = DateTime.Now,
                    TransactionType = transactionType
                };

                foreach (object row in dgvJewel.Rows)
                {
                    var current = ((DataGridViewRow) (row));
                    if ((bool) current.Cells[_columnselectchk.ToLowerCaseColumnName()].Value)
                    {
                        var jewelno = current.Cells[_columnjewelnumber.ToLowerCaseColumnName()].Value;
                        var tran = current.Cells[_columntrno.ToLowerCaseColumnName()].Value;
                        var jewel = _transactionServices.GetJewelStockByJewelNo(jewelno.ToString());
                        var trans = _transactionServices.GetJewelTransactionsById((Int32) tran);
                        if ((jewel.StockStatus == StockStatus.ItemLockedInStock && jewel.JewelState == JewelState.OnMarketing)
                            || jewel.StockStatus == StockStatus.ItemOutOfStock && jewel.JewelState == JewelState.OnApproval)
                        {
                            var item = new JewelTransaction
                            {
                                CostingDetail = trans.CostingDetail,
                                TransactionType = transactionType,
                                MetalColor = trans.MetalColor,
                                CStonePcs = trans.CStonePcs,
                                CStoneWeight = trans.CStoneWeight,
                                CertificateNumber = trans.CertificateNumber,
                                DesignCode = trans.DesignCode,
                                StonePcs = trans.StonePcs,
                                KT = trans.KT,
                                JewelItemCategory = trans.JewelItemCategory,
                                JewelNumber = trans.JewelNumber,
                                JewelType = trans.JewelType,
                                TotalWeight = trans.TotalWeight,
                                MetalWeight = trans.MetalWeight,
                                StoneWeight = trans.StoneWeight,
                                Properties = trans.Properties,
                                TransactionPartyRef = trans.TransactionPartyRef,
                                TransactionDate = DateTime.Today,
                                TotalAmount = trans.TotalAmount
                            };
                            clookup.JewelTransactions.Add(item);
                        }
                    }
                }
                if (clookup.JewelTransactions.Any())
                {
                    request.TransactionLookup = clookup;
                    var response = _transactionServices.CreateJewelTransaction(request);
                    ShowManagedModalForm<frmCostingConfirmation>(Owner as frmMDIParent, response.TransactionLookup);
                }
                else
                {
                    MessageBox.Show(Resources.frmManageTransaction_lnkRTS_LinkClicked_no_item_available_to_be_returned_);
                    return;
                }

                btnGo_Click(new Object(), new EventArgs());
            }
        }

        private void lblCostingChart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var item = new List<Int32>();
            foreach (var row in dgvJewel.Rows)
            {
                var current = ((DataGridViewRow)(row));
                var chk = (DataGridViewCheckBoxCell)current.Cells[_columnselectchk.ToLowerCaseColumnName()];
                if ((bool)chk.Value)
                {
                    var tran = (Int32)current.Cells[_columntrno.ToLowerCaseColumnName()].Value;
                    item.Add(tran);
                }
            }
            if (item.Any())
                _reportUitility.ShowCostingReport(item);
        }

        private void lnkExportTag_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var item = new List<String>();
            foreach (var row in dgvJewel.Rows)
            {
                var current = ((DataGridViewRow)(row));
                var chk = (DataGridViewCheckBoxCell)current.Cells[_columnselectchk.ToLowerCaseColumnName()];
                if ((bool)chk.Value)
                {
                    var tran = current.Cells[_columnjewelnumber.ToLowerCaseColumnName()].Value;
                    item.Add(tran.ToString());
                }
            }
            if (item.Any())
                _reportUitility.ShowBarcodeTag(item);
        }

        private void lnkExportSticker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var item = new List<String>();
            foreach (var row in dgvJewel.Rows)
            {
                var current = ((DataGridViewRow)(row));
                var chk = (DataGridViewCheckBoxCell)current.Cells[_columnselectchk.ToLowerCaseColumnName()];
                if ((bool)chk.Value)
                {
                    var tran = current.Cells[_columnjewelnumber.ToLowerCaseColumnName()].Value;
                    item.Add(tran.ToString());
                }

            }
            if (item.Any())
                _reportUitility.ShowStickerReport(item);
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvJewel.Rows)
            {
                var chk = (DataGridViewCheckBoxCell)row.Cells[_columnselectchk.ToLowerCaseColumnName()];
                chk.Value = chkSelectAll.Checked;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}

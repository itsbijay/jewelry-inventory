using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JetCoders.Forms.UI;
using JetCoders.Shared;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmMemoOrder : frmDataEntry
    {
        // MEMO Grid creation
        private const string _columnimage = "IMAGE";
        private const string _columnjewelnumber = "JEWEL NUMBER";
        private const string _columntype = "PRODUCTSNAME";
        private const string _columndesigncode = "DESIGN CODE";
        private const string _columngoldkt = "KT";
        private const string _columntotalwt = "GR WT";
        private const string _columnmetalweight = "NET WT";
        private const string _columndiamondweight = "DIAMOND.WT";
        private const string _columndiapcs = "DIAMOND.PCS";
        private const string _columncolwt = "COL.WEIGHT";
        private const string _columncolpcs = "COL.PCS";

        private const string _columnCategory = "CATEGORY";
        private const string _columndgPartticulatrs = "DGPARTICULARS";
        private const string _columndgType = "DGTYPE";
        private const string _columndgAmount = "DGAMOUNT";
        private const string _columndgMinimumAmount = "DGMINIMUMAMOUNT";
        private const string _columndgRemoveItem = "REMOVE";

        readonly ITransactionService _transactionServices;
        readonly ICustomerService _customerServices;
        readonly IJewelCalculation _jewelCalculation;

        public static bool ApprovalSelection { get; set; }

        public frmMemoOrder()
        {
            InitializeComponent();
        }

        public frmMemoOrder(ITransactionService transactionServices, ICustomerService customerServices,
                             IJewelCalculation jewelCalculation)
            : this()
        {
            _transactionServices = transactionServices;
            _customerServices = customerServices;
            _jewelCalculation = jewelCalculation;

            { ConfigDataGridView(dgvJewel); }

            BindMemoForm();

            // Assign Events
            dgvJewel.RowsAdded += delegate { CalculateTotal(); };

            dgDataControl.KeyDown += ondgDataControlKeyDown;
            dgDataControl.CellValidating += ondgDataControlCellValidating;
            dgDataControl.CellEndEdit += ondgDataControlCellEndEdit;
            txtStamping.KeyPress += WinEvents.AllowNumeric_KeyPress;

            dgCertificatesCostingRates.CellValidating += onCertificatesCostingRatesCellValidating;
            
            txtBarCode.KeyPress += ontxtBarCodeKeyPress;

            btnNext.Click += onbtnNextClick;
            btnSave.Click += onbtnSaveClick;

            rdoApprovalMemo.Checked = ApprovalSelection;
            rdoMarketingMemo.Checked = !ApprovalSelection;
        }

        #region GridFormaing
        public void ConfigDataGridView(DataGridView mapGrid)
        {
            mapGrid.Columns.Add(GridExtension.GetImageColumn(_columnimage));

            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntype, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnjewelnumber, true));

            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columndesigncode, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columngoldkt, true));

            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columntotalwt, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columnmetalweight, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columndiapcs, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columndiamondweight, true));

            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columncolpcs, true));
            mapGrid.Columns.Add(GridExtension.GetDescriptionColumn(_columncolwt, true));
            mapGrid.Columns.Add(GridExtension.GetButtonColumn(_columndgRemoveItem));

            mapGrid.CellContentClick += dgvJewel_CellContentClick;
        }
        #endregion

        private void BindMemoForm()
        {
            btnPrev.Enabled = false;
            btnNext.Enabled = true;

            grpStep1.Visible = true;
            grpStep2.Visible = false;
            { grpStep2.SendToBack(); grpStep1.BringToFront(); }
            { btnSave.Enabled = false; }

            cboCustomer.DataSource = _customerServices.GetActiveCustomers();
            cboCustomer.SelectedIndex = -1;
            dtCosting.Value = DateTime.Now;

            { txtContactName.Text = txtRemarks.Text = txtDocNo.Text = String.Empty; }

            dgCertificatesCostingRates.Rows.Clear();
            dgCertificatesCostingRates.Rows.Add(1, 0, 0.00, 000.00);
            dgCertificatesCostingRates.Rows.Add(2, 0, 0.00, 000.00);
            dgCertificatesCostingRates.Rows.Add(3, 0, 99999999, 000.00);
        }

        enum FindJewelBy { JewelNo }

        void onCertificatesCostingRatesCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal val = 0.00M;
            if (dgCertificatesCostingRates.Columns[e.ColumnIndex].Name == "dgCertificateAmount" ||
                dgCertificatesCostingRates.Columns[e.ColumnIndex].Name == "dgCertificateRangeTo")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false && Decimal.TryParse(e.FormattedValue.ToString(), out val) == false)
                    errorProvider.SetError(dgCertificatesCostingRates, "Invalid amount field.");
            }

            if (dgCertificatesCostingRates.Columns[e.ColumnIndex].Name == "dgCertificateRangeTo")
            {
                if (dgCertificatesCostingRates.RowCount > e.RowIndex + 1)
                    dgCertificatesCostingRates["dgCertificateRangeFrom", e.RowIndex + 1].Value = val + 0.01M;

                decimal fromval;
                Decimal.TryParse(dgCertificatesCostingRates["dgCertificateRangeFrom", e.RowIndex].Value.ToString(), out fromval);
                if (fromval >= val)
                    errorProvider.SetError(dgCertificatesCostingRates, "Invalid range to field.");
            }
        }

        void ontxtBarCodeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
                e.Handled = true;

            if (e.KeyChar == 13 && String.IsNullOrEmpty(txtBarCode.Text) == false)
            {
                FindJewelByJewelNo(FindJewelBy.JewelNo);
                txtBarCode.Text = String.Empty;
            }
        }

        private void FindJewelByJewelNo(FindJewelBy findParam)
        {
            foreach (DataGridViewRow dgvr in dgvJewel.Rows)
            {
                var findCode = String.Empty;
                var code = String.Empty;
                if (findParam == FindJewelBy.JewelNo)
                {
                    findCode = dgvr.Cells[_columnjewelnumber.ToLowerCaseColumnName()].Value.ToString();
                    code = txtBarCode.Text;
                }

                if (String.Compare(findCode, code, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    MessageBox.Show(findParam + Resources.frmMemoOrder_FindJewelByJewelNo__already_exists__Please_search_for_new_record_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBarCode.Text = String.Empty;
                    return;
                }
            }

            JewelStockLedger JewelData = null;
            if (findParam == FindJewelBy.JewelNo)
            {
                JewelData = _transactionServices.GetJewelStockByJewelNo(txtBarCode.Text);
            }

            if (!(JewelData != null && JewelData.StockStatus == StockStatus.ItemIsInStock))
            {
                MessageBox.Show(Resources.frmMemoOrder_FindJewelByJewelNo_Records_Not_found__);
                txtBarCode.Text = String.Empty;
                return;
            }

            int _newRowNumber = dgvJewel.RowCount;

            dgvJewel.Rows.Add(1);
            dgvJewel.Rows[_newRowNumber].Height = 50;

            dgvJewel.Rows[_newRowNumber].Cells[_columnjewelnumber.ToLowerCaseColumnName()].Value = JewelData.JewelNumber;
            dgvJewel.Rows[_newRowNumber].Cells[_columndesigncode.ToLowerCaseColumnName()].Value = JewelData.DesignCode;
            dgvJewel.Rows[_newRowNumber].Cells[_columntype.ToLowerCaseColumnName()].Value = JewelData.JewelItemCategory;
            dgvJewel.Rows[_newRowNumber].Cells[_columngoldkt.ToLowerCaseColumnName()].Value = JewelData.KT;
            dgvJewel.Rows[_newRowNumber].Cells[_columntotalwt.ToLowerCaseColumnName()].Value = JewelData.TotalWeight;
            dgvJewel.Rows[_newRowNumber].Cells[_columnmetalweight.ToLowerCaseColumnName()].Value = JewelData.MetalWeight;
            dgvJewel.Rows[_newRowNumber].Cells[_columndiamondweight.ToLowerCaseColumnName()].Value = JewelData.StoneWeight;
            dgvJewel.Rows[_newRowNumber].Cells[_columndiapcs.ToLowerCaseColumnName()].Value = JewelData.StonePcs;
            dgvJewel.Rows[_newRowNumber].Cells[_columncolwt.ToLowerCaseColumnName()].Value = JewelData.CStoneWeight;
            dgvJewel.Rows[_newRowNumber].Cells[_columncolpcs.ToLowerCaseColumnName()].Value = JewelData.CStonePcs;

            dgvJewel[_columnimage.ToLowerCaseColumnName(), _newRowNumber].Value = ImageExtension.ResolveImage(JewelData.DesignCode);
            dgvJewel.Rows[_newRowNumber].Cells[_columndgRemoveItem.ToLowerCaseColumnName()].Value = "Remove";

            dgvJewel.FirstDisplayedScrollingRowIndex = dgvJewel.RowCount - 1;
            CalculateTotal();
        }

        void CalculateTotal()
        {
            txtBarCode.Text = String.Empty;
            lblTotal.Text = Convert.ToString(TotalRows);
            lblGrossWeight.Text = Convert.ToString(GrossWeight);
            lblNetWeight.Text = Convert.ToString(NetWeight);
            lblDiamondWeight.Text = Convert.ToString(DiamondWeight);
            lblDiamondPieces.Text = Convert.ToString(DiamondPieces);
        }

        #region GridTotalRowsCalculation
        private decimal GetTotal(string colname)
        {
            decimal value = default(decimal);

            foreach (DataGridViewRow dgvr in dgvJewel.Rows)
            {
                value = value + Convert.ToDecimal(dgvr.Cells[colname].Value);
            }
            return value;
        }

        public int TotalRows
        {
            get
            {
                return dgvJewel.Rows.Count;
            }
        }

        decimal GrossWeight { get { return GetTotal(_columntotalwt.ToLowerCaseColumnName()); } }
        decimal NetWeight { get { return GetTotal(_columnmetalweight.ToLowerCaseColumnName()); } }
        decimal DiamondWeight { get { return GetTotal(_columndiamondweight.ToLowerCaseColumnName()); } }
        decimal DiamondPieces { get { return GetTotal(_columndiapcs.ToLowerCaseColumnName()); } }
        #endregion

        void onbtnNextClick(object sender, EventArgs e)
        {
            if (dgvJewel.Rows.Count <= 0)
            {
                MessageBox.Show(Resources.frmMemoOrder_onbtnNextClick_Please_select_record_to_create_memo__);
                return;
            }

            btnPrev.Enabled = true;
            btnNext.Enabled = false;

            dgDataControl.Rows.Clear();
            var CostingRate = new CostingRates();

            dgDataControl.Rows.Clear();

            foreach (DataGridViewRow dgvr in dgvJewel.Rows)
            {
                var JewelNumber = dgvr.GetCellValue(_columnjewelnumber);
                var Jewel = _transactionServices.GetJewelTransactionsByJewelNo(JewelNumber);
                if (Jewel != null)
                {
                    var costingProperties = Jewel.CostingDetail.Properties.CostingItems;

                    var metalItem = Jewel.Properties.ItemDetails.MetalDetail;
                    var metalcostingItem = costingProperties.Where(r => r.ProductCategory == ProductCategory.Metal && r.Particulars == metalItem.MetalType);
                    CostingRate.CostingItems.AddRange(metalcostingItem);

                    var stoneItem = Jewel.Properties.ItemDetails.StoneDetail;
                    var stonecostingItem = costingProperties
                    .Where(r => r.ProductCategory == ProductCategory.Stone &&
                        stoneItem.StoneType == r.Particulars &&
                        stoneItem.StoneChart.StoneMetaDetailList.Any(c => c.StoneSieveSz == r.ConfigurationValue)
                    );

                    CostingRate.CostingItems.AddRange(stonecostingItem);

                    var csItem = Jewel.Properties.ItemDetails.ColorStoneDetail;
                    var cscostingItem = costingProperties.Where(r => r.ProductCategory == ProductCategory.ColorStone && r.Particulars == csItem.ColorStoneType);
                    CostingRate.CostingItems.AddRange(cscostingItem);

                    var laborItem = Jewel.JewelType;
                    var laborcostingItem = costingProperties.Where(r => r.ProductCategory == ProductCategory.Labour && r.Particulars == laborItem);
                    CostingRate.CostingItems.AddRange(laborcostingItem);
                }
            }

            { grpStep1.Visible = false; grpStep2.Visible = true; }
            { grpStep1.SendToBack(); grpStep2.BringToFront(); }

            var bindingObject = (from list in CostingRate.CostingItems
                                 orderby list.ProductCategory
                                 select new
                                 {
                                     Category = list.ProductCategory,
                                     Product = list.ProductCategory,
                                     Description = list.Particulars,
                                     list.ConfigurationValue
                                 }).Distinct();

            foreach (var item in bindingObject)
                dgDataControl.Rows.Add(item.Category, item.Product, item.Description, item.ConfigurationValue, 0.000, 0.000);

            dgCertificatesCostingRates.Rows.Clear();
            dgCertificatesCostingRates.Rows.Add(1, 0, 0.00, 000.00);
            dgCertificatesCostingRates.Rows.Add(2, 0, 0.00, 000.00);
            dgCertificatesCostingRates.Rows.Add(3, 0, 99999999, 000.00);

            { dgDataControl.ReadOnly = false; btnSave.Enabled = true; }
        }

        void onbtnSaveClick(object sender, EventArgs e)
        {
            TransactionLookup lookup;
            if (TryCreateJewelLookup(out lookup))
            {
                var request = new JewelTransactionRequest { TransactionLookup = lookup };
                var response = _transactionServices.CreateJewelTransaction(request);

                ShowManagedModalForm<frmCostingConfirmation>(Owner as frmMDIParent, response.TransactionLookup);
                Close();
            }
        }

        private bool TryCreateJewelLookup(out TransactionLookup lookup)
        {
            lookup = null;
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return false;
            }

            CostingRates costingRates;
            if (VALIDATEDATAGRID(out costingRates) == false)
                return false;

            List<JewelTransaction> jewelTransaction;
            Calculate(dgvJewel, costingRates, out jewelTransaction);

            lookup = new TransactionLookup
            {
                ContactName = txtContactName.Text,
                DocNumber = txtDocNo.Text,
                Remarks = txtRemarks.Text,
                TransactionDate = dtCosting.Value,
                TransactionPartyRef = ((Customer)cboCustomer.SelectedItem).CustomersCode,
                TransactionType = rdoApprovalMemo.Checked ? TransactionType.ApprovalTransaction : TransactionType.MarketingTransaction,
                JewelTransactions = jewelTransaction
            };
            return true;
        }

        void ondgDataControlKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                if(dgDataControl.CurrentCell == null) return;

                int iColumn = dgDataControl.CurrentCell.ColumnIndex;
                int iRow = dgDataControl.CurrentCell.RowIndex;
                dgDataControl.CurrentCell = iColumn == dgDataControl.Columns.Count - 1 ? dgDataControl[0, iRow + 1] : dgDataControl[iColumn + 1, iRow];
            }
        }

        void Calculate(DataGridView mapGrid, CostingRates costingRates, out List<JewelTransaction> jewelTransaction)
        {
            jewelTransaction = new List<JewelTransaction>();
            var tranLookupKey = Guid.NewGuid();
            foreach (var item in mapGrid.Rows)
            {
                var row = (DataGridViewRow)item;
                var jewelNo = row.GetCellValue(_columnjewelnumber);

                var tranDetails = _transactionServices.GetJewelTransactionsByJewelNo(jewelNo);
                var tran = new JewelTransaction
                {
                    JewelTransactionRowId = tranLookupKey,
                    TransactionType = ApprovalSelection ? TransactionType.ApprovalTransaction : TransactionType.MarketingTransaction,
                    CostingDetail = new CostingDetail { Properties = costingRates },
                    CertificateNumber = tranDetails.CertificateNumber,
                    CStonePcs = tranDetails.CStonePcs,
                    CStoneWeight = tranDetails.CStoneWeight,
                    DesignCode = tranDetails.DesignCode,
                    JewelNumber = tranDetails.JewelNumber,
                    JewelTransactionId = tranDetails.JewelTransactionId,
                    JewelType = tranDetails.JewelType,
                    KT = tranDetails.KT,
                    MetalColor = tranDetails.MetalColor,
                    JewelItemCategory = tranDetails.JewelItemCategory,
                    MetalWeight = tranDetails.MetalWeight,
                    Properties = tranDetails.Properties,
                    StonePcs = tranDetails.StonePcs,
                    StoneWeight = tranDetails.StoneWeight,
                    TotalAmount = tranDetails.TotalAmount,
                    TotalWeight = tranDetails.TotalWeight,
                    TransactionDate = dtCosting.Value,
                    TransactionPartyRef = ((Customer)cboCustomer.SelectedItem).CustomersCode,
                };

                jewelTransaction.Add(tran);
            }
            _jewelCalculation.Calculate(costingRates, jewelTransaction);
        }

        void ondgDataControlCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgDataControl.Columns[e.ColumnIndex].Name == _columndgAmount.ToLowerCaseColumnName())
            {
                decimal val;
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false && Decimal.TryParse(e.FormattedValue.ToString(), out val) == false)
                {
                    errorProvider.SetError(dgDataControl, "Invalid amount field.");
                    e.Cancel = true;
                }
            }

            if (dgDataControl.Columns[e.ColumnIndex].Name == _columndgMinimumAmount.ToLowerCaseColumnName())
            {
                decimal val;
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false && Decimal.TryParse(e.FormattedValue.ToString(), out val) == false)
                {
                    errorProvider.SetError(dgDataControl, "Invalid amount field.");
                    e.Cancel = true;
                }
            }
        }

        void ondgDataControlCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgDataControl.Rows[e.RowIndex].ErrorText = String.Empty;
            errorProvider.Clear();
        }

        void btnPrev_Click(object sender, EventArgs e)
        {
            BindMemoForm();
        }

        bool VALIDATEDATAGRID(out CostingRates costingRates)
        {
            costingRates = new CostingRates();

            decimal amount;
            if (Decimal.TryParse(txtStamping.Text, out amount) == false)
            {
                errorProvider.SetError(txtStamping, Resources.frmMemoOrder_VALIDATEDATAGRID_The_stamping_charges_is_invalid_);
                MessageBox.Show(Resources.frmMemoOrder_VALIDATEDATAGRID_The_stamping_charges_is_invalid_, Constants.ALERTMESSAGEHEADER);
                return false;
            }
            AllErrors.Clear();

            // Validate grid and form CostingRates
            foreach (var item in dgDataControl.Rows)
            {
                var row = (DataGridViewRow)item;

                decimal AmountValue;
                var IsAmount = Decimal.TryParse(row.GetCellValue(_columndgAmount), out AmountValue);
                var colName = row.GetCellValue(_columnCategory) + " " + row.GetCellValue(_columndgPartticulatrs) + row.GetCellValue(_columndgType);
                var msg = String.Format("Amount field is required for item '{0}'", colName);

                if (!IsAmount || AmountValue == 0.0M)
                    AllErrors.Add("InValisAmount" + Guid.NewGuid(), msg);

                if (row.GetCellValue(_columnCategory) == ProductCategory.Labour.ToString())
                {
                    if (row.ValidateDependentProperties(_columndgMinimumAmount) == false)
                        AllErrors.Add("MinimumAmount" + Guid.NewGuid(), msg);

                    decimal MinAmountValue;
                    Decimal.TryParse(row.GetCellValue(_columndgMinimumAmount), out MinAmountValue);
                }
            }

            if (AllErrors.Count > 0)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return false;
            }

            // Create CostingRates Chart
            foreach (var item in dgDataControl.Rows)
            {
                var row = (DataGridViewRow)item;
                costingRates.CostingItems.Add(new CostingDetails
                {
                    ProductCategory = row.GetParsedCellValue<ProductCategory>(_columnCategory),
                    Particulars = row.GetCellValue(_columndgPartticulatrs),
                    ConfigurationValue = row.GetCellValue(_columndgType),
                    Amount = Decimal.Parse(row.GetCellValue(_columndgAmount)),
                    MinimumAmount = row.GetParsedCellValue(_columndgMinimumAmount, defaultValue: 0.0M)
                });
                costingRates.StampingRates = Convert.ToDecimal(txtStamping.Text);
            }

            CertificateRates certificateRate;
            dgCertificatesCostingRates.CreateCertificateRate(out certificateRate);
            costingRates.CertificateRate = certificateRate;

            return true;
        }

        void btnShowMemo_Click(object sender, EventArgs e)
        {
            TransactionLookup lookup;
            if (TryCreateJewelLookup(out lookup))
                ShowManagedModalForm<frmLookupDetails>(this, lookup);
        }

        private void dgvJewel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var value = dgvJewel[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (value == "Remove")
            {
                dgvJewel.Rows.RemoveAt(e.RowIndex);
                CalculateTotal();
            }
        }
    }
}
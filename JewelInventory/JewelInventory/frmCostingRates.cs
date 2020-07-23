using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmCostingRates : frmDataEntry, ICostingMultiMode
    {
        private readonly IConfigurationService _configurationService;
        private readonly IWinSettingProvider _winSettingProvider;
        private readonly ITransactionService _transactionService;
        private readonly IJewelCalculation _jewelCalculation;

        IList<ConfigurationMaster> Collection { get; set; }
        IList<JewelTransaction> PurchaseTransactionItems { get; set; }

        public static JewelItemCategory ItemCategory { get; set; }
        CostingRates CostingRate { get; set; }

        public frmCostingRates()
        {
            InitializeComponent();
        }

        public frmCostingRates(ISupplierService supplierService,
                               IConfigurationService configurationService, IWinSettingProvider winSettingProvider,
                               ITransactionService costingServices, IJewelCalculation jewelCalculation)
            : this()
        {
            _configurationService = configurationService;
            _winSettingProvider = winSettingProvider;
            _transactionService = costingServices;
            _jewelCalculation = jewelCalculation;

            PurchaseTransactionItems = new List<JewelTransaction>();

            cboCustomer.DataSource = supplierService.GetActiveSuppliers();
            cboCustomer.SelectedIndex = -1;
            dtCosting.Value = DateTime.Now;
        }

        private void frmCostingRates_Load(object sender, EventArgs e)
        {
            #region Costing Form
            dgCostingFormat.EditingControlShowing += CostingGridEditingControlShowing;
            dgCostingFormat.CellValidated += OnCostingFormatCellValidated;
            dgCostingFormat.CellEndEdit += OnCostingFormatCellEndEdit;
            dgCostingFormat.CellValidating += OnCostingFormatCellValidating;
            dgCostingFormat.CellEnter += OnCostingFormatCellEnter;
            #endregion

            btnPrev.Click += OnPrevClick;
            btnSave.Click += onSaveClick;
            btnAddtoList.Click += OnAddtoListClick;
            btnClearGrid.Click += OnClearGridClick;
            btnClearAllItems.Click += OnClearAllItemsClick;
            CostingRate = (CostingRates)FormData;

            Collection = _configurationService.GetAllConfigurations(ItemCategory);

            // Configure and add a default row in the Consting grid; this is the ConsignementIn grid
            { ConfigDataGridView(dgCostingFormat); ResetDataGridView(dgCostingFormat); }
        }

        void OnPrevClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.frmCostingRates_OnPrevClick_Your_current_form_details_will_be_cleared_out__Are_you_sure_want_to_go_back__, Constants.ALERTMESSAGEHEADER, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        void onSaveClick(object sender, EventArgs e)
        {
            if (_validateForm(this) == false)
            {
                MessageBox.Show(Resources.frmCostingRates_onSaveClick_Incomplete_information_provided_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            if (PurchaseTransactionItems.Any())
            {
                _jewelCalculation.Calculate(CostingRate, PurchaseTransactionItems);

                var lookup = new TransactionLookup
                {
                    ContactName = txtContactName.Text,
                    DocNumber = txtDocNo.Text,
                    Remarks = txtRemarks.Text,
                    TransactionDate = dtCosting.Value,
                    TransactionPartyRef = ((Supplier)cboCustomer.SelectedItem).SupplierCode,
                    TransactionType = TransactionType.PurchaseTransaction,
                    JewelTransactions = PurchaseTransactionItems
                };

                var request = new JewelTransactionRequest
                    {
                        TransactionLookup = lookup,
                    };
                var response = _transactionService.CreateJewelTransaction(request);

                if (response.IsValid == false)
                {
                    MessageBox.Show(response.AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                    return;
                }
                Close();

                ShowManagedModalForm<frmCostingConfirmation>(Owner as frmCostingBase, response.TransactionLookup);
            }
        }

        void btnCosting_Click(object sender, EventArgs e)
        {
            if (false == (CostingRate != null && CostingRate.CostingItems.Count > 0))
                return;

            var bindingObject = (from list in CostingRate.CostingItems
                                 orderby list.ProductCategory
                                 select new { Product = list.ProductCategory, Description = list.Particulars, list.ConfigurationValue, Amount = list.Amount.ToString("C"), MinimumAmount = list.MinimumAmount.ToString("C") }).ToList();

            var frm = new frmObjectBinder();
            frm.BindForm(bindingObject, "Costing Rates");
            frm.Show();
        }


        public bool IsStockUploadManulMode
        {
            get
            {
                return _winSettingProvider.StockUploadManulMode;
            }
        }
    }
}
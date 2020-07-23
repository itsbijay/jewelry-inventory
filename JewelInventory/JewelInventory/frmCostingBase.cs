using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JetCoders.Forms.UI;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmCostingBase : frmDataEntry
    {
        private readonly IConfigurationService _configurationService;
        private readonly IWinSettingProvider _winSettingProvider;

        public static JewelItemCategory MetalType { get; set; }
        CostingRates CostingRate { get; set; }

        public frmCostingBase()
        {
            InitializeComponent();
        }

        public frmCostingBase(IConfigurationService configurationService, IWinSettingProvider winSettingProvider)
            : this()
        {
            _configurationService = configurationService;
            _winSettingProvider = winSettingProvider;

            CostingRate = new CostingRates();
        }

        private void frmCostingBase_Load(object sender, EventArgs e)
        {
            BindCostingForm();

            #region Costing Form Setup Region
            #region Events Gold Costing Grid
            dgGoldCostingRates.KeyDown += OnGoldCostingKeyDown;
            dgGoldCostingRates.CellValidating += OnGoldCostingCellValidating;
            dgGoldCostingRates.CellEndEdit += OnGoldCostingCellEndEdit;
            #endregion

            #region Events Diamond Costing Grid
            dgDiamondCostingRates.KeyDown += OnDiamondCostingKeyDown;
            dgDiamondCostingRates.CellValidating += OnDiamondCostingCellValidating;
            dgDiamondCostingRates.CellEndEdit += OnDiamondCostingCellEndEdit;
            #endregion

            #region Events labour Costing Grid
            dgLabourCostingRates.KeyDown += OnLabourCostingKeyDown;
            dgLabourCostingRates.CellValidating += OnLabourCostingCellValidating;
            dgLabourCostingRates.CellEndEdit += OnLabourCostingCellEndEdit;
            #endregion

            #region Events Certificate Costing Grid
            dgCertificatesCostingRates.CellValidating += OnCertificatesCostingRatesCellValidating;
            #endregion
            #endregion Costing Form Setup Region

            if (MetalType == JewelItemCategory.Gold)
            {
                lblbuggets.Visible = lblchoki.Visible = lblmarquis.Visible =
                lblpriancess.Visible = lblround.Visible = lbltappers.Visible = true;

                lblbuggets.Click += lblDiamondSort_Click;
                lblchoki.Click += lblDiamondSort_Click;
                lblmarquis.Click += lblDiamondSort_Click;
                lblpriancess.Click += lblDiamondSort_Click;
                lblround.Click += lblDiamondSort_Click;
                lbltappers.Click += lblDiamondSort_Click;

                //TODO: Enable cache to retrive costing data frequently
                //grpCache.Visible = true;
            }
            lblHeader.Text = Resources.frmCostingBase_frmCostingBase_Load________Costing_Rates_ + MetalType;
            btnNext.Click += OnNextClick;

        }

        void OnCertificatesCostingRatesCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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

        void lblDiamondSort_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var row = dgDiamondCostingRates.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["dgDiamondPartticulatrs"].Value.ToString().Contains(label.Text));
            if (row == null) return;

            dgDiamondCostingRates.FirstDisplayedScrollingRowIndex = row.Index;
        }

        void OnNextClick(object sender, EventArgs e)
        {
            if (!TryParseCostingData) return;

            if (_winSettingProvider.StockUploadManulMode)
            {
                bool isAlreadyOpen = MdiChildren.Any(x => x.Name == typeof(frmCostingRates).Name);
                if (isAlreadyOpen)
                {
                    MdiChildren.Single(x => x.Name == typeof(frmCostingRates).Name).Activate();
                    return;
                }
                frmCostingRates.ItemCategory = MetalType;
                ShowManagedModalForm<frmCostingRates>(this, CostingRate);
            }
            else
            {
                bool isAlreadyOpen = MdiChildren.Any(x => x.Name == typeof(frmExcelCostingRates).Name);
                if (isAlreadyOpen)
                {
                    MdiChildren.Single(x => x.Name == typeof(frmExcelCostingRates).Name).Activate();
                    return;
                }
                frmExcelCostingRates.MetalType = MetalType;
                ShowManagedModalForm<frmExcelCostingRates>(this, CostingRate);
            }
        }

        bool TryParseCostingData
        {
            get
            {
                if (!IsValid)
                {
                    MessageBox.Show(Resources.frmCostingBase_TryParseCostingData_Incomplete_information_provided_, Constants.ALERTMESSAGEHEADER);
                    return false;
                }

                decimal amount;
                if (Decimal.TryParse(txtStamping.Text, out amount) == false)
                {
                    errorProvider.SetError(txtStamping, Resources.frmCostingBase_TryParseCostingData_The_stamping_charges_is_invalid_);
                    MessageBox.Show(Resources.frmCostingBase_TryParseCostingData_The_stamping_charges_is_invalid_, Constants.ALERTMESSAGEHEADER);
                    return false;
                }

                CostingRate.CostingItems.Clear();

                List<CostingDetails> configCollection;

                dgGoldCostingRates.CreateCostingRates(out configCollection);
                if (configCollection.Count > 0)
                    CostingRate.CostingItems.AddRange(configCollection);

                dgDiamondCostingRates.CreateCostingRates(out configCollection);
                if (configCollection.Count > 0)
                    CostingRate.CostingItems.AddRange(configCollection);

                dgLabourCostingRates.CreateCostingRates(out configCollection);
                if (configCollection.Count > 0)
                    CostingRate.CostingItems.AddRange(configCollection);

                CertificateRates certificateRate;
                dgCertificatesCostingRates.CreateCertificateRate(out certificateRate);
                CostingRate.CertificateRate = certificateRate;

                CostingRate.StampingRates = Convert.ToDecimal(txtStamping.Text);

                if (CostingRate.HasCostingItems == false)
                {
                    MessageBox.Show(Resources.frmCostingBase_TryParseCostingData_No_costing_details_found__Please_fill_costing_chart_completly_, Constants.ALERTMESSAGEHEADER);
                    return false;
                }
                return true;
            }
        }

        #region Costing Form SetUp Region
        private void BindCostingForm()
        {
            if (MetalType != JewelItemCategory.Gold)
            {
                grpCertCosting.Enabled = false;
            }

            dgGoldCostingRates.Rows.Clear();
            dgDiamondCostingRates.Rows.Clear();
            dgLabourCostingRates.Rows.Clear();

            // set the button visibility
            { btnSave.Enabled = false; btnNext.Enabled = true; btnPrev.Enabled = false; }

            { groupCosting.Visible = true; }

            var Collection = _configurationService.GetAllConfigurations(MetalType);

            var metalItems = Collection.Where(x => x.ProductCategory == ProductCategory.Metal).ToList();
            var stoneItems = Collection.Where(x => x.ProductCategory == ProductCategory.Stone || x.ProductCategory == ProductCategory.ColorStone).ToList();
            var labourItems = Collection.Where(x => x.ProductCategory == ProductCategory.Labour).ToList();

            foreach (var item in metalItems)
                dgGoldCostingRates.Rows.Add(item.ConfigurationId, item.Particulars, item.ConfigurationValue);

            foreach (var item in stoneItems)
                dgDiamondCostingRates.Rows.Add(item.ConfigurationId, item.Particulars, item.ConfigurationValue);

            foreach (var item in labourItems)
                dgLabourCostingRates.Rows.Add(item.ConfigurationId, item.Particulars, item.ConfigurationValue, item.Remarks);

            dgCertificatesCostingRates.Rows.Clear();
            dgCertificatesCostingRates.Rows.Add(1, 0, 0.00, 000.00);
            dgCertificatesCostingRates.Rows.Add(2, 0, 0.00, 000.00);
            dgCertificatesCostingRates.Rows.Add(3, 0, 99999999, 000.00);
        }

        #region Metal Costing Grid
        void OnGoldCostingKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                var iColumn = dgGoldCostingRates.CurrentCell.ColumnIndex;
                var iRow = dgGoldCostingRates.CurrentCell.RowIndex;
                dgGoldCostingRates.CurrentCell = iColumn == dgGoldCostingRates.Columns.Count - 1 ? dgGoldCostingRates[0, iRow + 1] : dgGoldCostingRates[iColumn + 1, iRow];
            }
        }
        void OnGoldCostingCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgGoldCostingRates.Columns[e.ColumnIndex].Name == "dgGoldAmount")
            {
                decimal val;
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false && Decimal.TryParse(e.FormattedValue.ToString(), out val) == false)
                {
                    errorProvider.SetError(dgGoldCostingRates, "Invalid amount field.");
                    e.Cancel = true;
                }
            }
        }
        void OnGoldCostingCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgGoldCostingRates.Rows[e.RowIndex].ErrorText = String.Empty;
            errorProvider.Clear();
        }
        #endregion

        #region Stone Costing Grid
        void OnDiamondCostingKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                var iColumn = dgDiamondCostingRates.CurrentCell.ColumnIndex;
                var iRow = dgDiamondCostingRates.CurrentCell.RowIndex;
                dgDiamondCostingRates.CurrentCell = iColumn == dgDiamondCostingRates.Columns.Count - 1 ? dgDiamondCostingRates[0, iRow + 1] : dgDiamondCostingRates[iColumn + 1, iRow];

            }
        }
        void OnDiamondCostingCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgDiamondCostingRates.Columns[e.ColumnIndex].Name == "dgDiamondAmount")
            {
                decimal val;
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false && Decimal.TryParse(e.FormattedValue.ToString(), out val) == false)
                {
                    errorProvider.SetError(dgDiamondCostingRates, "Invalid amount field.");
                    e.Cancel = true;
                }
            }
        }
        void OnDiamondCostingCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgDiamondCostingRates.Rows[e.RowIndex].ErrorText = String.Empty;
            errorProvider.Clear();
        }
        #endregion

        #region LabourCostingRates
        void OnLabourCostingKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                    e.SuppressKeyPress = true;
                var iColumn = dgLabourCostingRates.CurrentCell.ColumnIndex;
                var iRow = dgLabourCostingRates.CurrentCell.RowIndex;
                dgLabourCostingRates.CurrentCell =
                        iColumn == dgLabourCostingRates.Columns.Count - 1 ?
                        dgLabourCostingRates[0, iRow + 1] :
                        dgLabourCostingRates[iColumn + 1, iRow];

            }
        }
        void OnLabourCostingCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgLabourCostingRates.Columns[e.ColumnIndex].Name == "dgLabourAmount")
            {
                decimal val;
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false && Decimal.TryParse(e.FormattedValue.ToString(), out val) == false)
                {
                    errorProvider.SetError(dgLabourCostingRates, "Invalid amount field.");
                    e.Cancel = true;
                }
            }

            if (dgLabourCostingRates.Columns[e.ColumnIndex].Name == "dgLabourMinimumAmount")
            {
                decimal val;
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false && Decimal.TryParse(e.FormattedValue.ToString(), out val) == false)
                {
                    errorProvider.SetError(dgLabourCostingRates, "Invalid amount field.");
                    e.Cancel = true;
                }
            }
        }
        void OnLabourCostingCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgLabourCostingRates.Rows[e.RowIndex].ErrorText = String.Empty;
            errorProvider.Clear();
        }
        #endregion

        private void grpCertCosting_Enter(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
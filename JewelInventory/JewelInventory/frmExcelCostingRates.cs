using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JetCoders.Shared;
using JewelInventory.Properties;
using LinqToExcel;
using System.IO;

namespace JewelInventory
{
    public partial class frmExcelCostingRates : frmDataEntry, ICostingMultiMode
    {
        private readonly IWinSettingProvider _winSettingProvider;
        private readonly ITransactionService _costingServices;
        private readonly IJewelCalculation _jewelCalculation;

        IList<ConfigurationMaster> Collection { get; set; }
        CostingRates CostingRate { get; set; }
        public static JewelItemCategory MetalType { get; set; }
        IList<JewelTransaction> PurchaseTransactionItems { get; set; }

        readonly CostingDetail _costingDetails;

        public frmExcelCostingRates()
        {
            InitializeComponent();
        }

        public frmExcelCostingRates(ISupplierService supplierService, IWinSettingProvider winSettingProvider
                                 , ITransactionService costingServices, IJewelCalculation jewelCalculation)
            : this()
        {
            _winSettingProvider = winSettingProvider;
            _costingServices = costingServices;
            _jewelCalculation = jewelCalculation;

            Collection = new List<ConfigurationMaster>();
            CostingRate = new CostingRates();
            PurchaseTransactionItems = new List<JewelTransaction>();

            _costingDetails = new CostingDetail();

            cboCustomer.DataSource = supplierService.GetActiveSuppliers();
            cboCustomer.SelectedIndex = -1;
            dtCosting.Value = DateTime.Now;
        }

        private void frmCostingRates_Load(object sender, EventArgs e)
        {
            btnNext.Click += OnNextClick;
            btnPrev.Click += OnPrevClick;
            btnSave.Click += OnSaveClick;
            CostingRate = (CostingRates)FormData;
        }

        void OnNextClick(object sender, EventArgs e)
        {
            //TODO:
            _costingDetails.Properties = CostingRate;
        }

        void OnPrevClick(object sender, EventArgs e)
        {
            // just that
            if (MessageBox.Show(Resources.frmExcelCostingRates_OnPrevClick_Your_current_form_details_will_be_cleared_out__Are_you_sure_want_to_go_back__, Constants.ALERTMESSAGEHEADER, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // set the button visibility
                { btnSave.Enabled = false; }

                PurchaseTransactionItems = new List<JewelTransaction>();

                txtUploadError.Text = String.Empty;

                txtUploadError.Height = 1;

                dgvJewel.Rows.Clear();
            }
            // Hide next button and show prev & save button.
            { btnNext.Enabled = true; }
        }

        void OnSaveClick(object sender, EventArgs e)
        {
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
                var response = _costingServices.CreateJewelTransaction(request);

                if (response.IsValid == false)
                {
                    MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                    return;
                }

                ShowManagedModalForm<frmCostingConfirmation>(Owner as frmCostingBase, response.TransactionLookup);
                Close();
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            PurchaseTransactionItems = new List<JewelTransaction>();
            txtUploadError.Text = String.Empty;
            txtUploadError.Height = 1;
            dgvJewel.Rows.Clear();

            txtUploadError.Text = Resources.frmExcelCostingRates_openFileDialog1_FileOk_Following_error_s__occoured_while_processing_your_excel + Environment.NewLine + Resources.frmExcelCostingRates_openFileDialog1_FileOk_ + Environment.NewLine + Environment.NewLine;

            var excel = new ExcelQueryFactory(openFileDialog1.FileName);
            var uploadData = excel.Worksheet<ExcelData>("COSTING FORMAT");

            try { Queryable.Count(uploadData); }
            catch (Exception ex) { MessageBox.Show(Resources.frmExcelCostingRates_openFileDialog1_FileOk_ + "\n" + ex.Message); return; }

            var allRows = ProcessExcelData(uploadData.ToList());

            var rows = new JewelData { Items = allRows.Items.Where(x => x.IsValid).ToList() };

            if (allRows.Items.Count() != allRows.Items.Select(x => x.SRNO).Distinct().Count())
            {
                MessageBox.Show(Resources.frmExcelCostingRates_openFileDialog1_FileOk_Please_ensure_excel_file_is_numbered_correctly_); return;
            }

            foreach (var row in rows.Items)
            {
                var item = new ItemDetail
                {
                    TotalWeight = row.GRWT,
                    CertificateNumber = row.CERTNO,
                    DesignCode = row.DESIGNNO,
                    ItemCategory = row.TYPE,
                    ItemDescription = row.TYPE
                };

                var metalRate = CostingRate.CostingItems.Single(x => x.ProductCategory == ProductCategory.Metal && x.Particulars == row.KT);

                var labour = CostingRate.CostingItems.FirstOrDefault(x => x.Particulars == row.TYPE && x.ProductCategory == ProductCategory.Labour);

                if (labour == null)
                {
                    row.ErrorMessage = String.Format("Invalid metal type, for record {0}", row.SRNO);
                    continue;
                }

                decimal labourCharges;
                var labourCost = labour.Amount;
                var minlabourCost = labour.MinimumAmount;
                var netMetalWt = Math.Max(row.GRWT - row.TOTALDIAWT / 5, 0);
                if (netMetalWt * labourCost <= minlabourCost)
                {
                    labourCharges = Math.Max(minlabourCost, 0);
                }
                else
                {
                    labourCharges = netMetalWt * labourCost;
                }

                item.LabourCharges = labourCharges;
                item.MetalDetail = new MetalDetail
                    {
                        MetalNetWt = netMetalWt,
                        MetalType = row.KT,
                        MetalNetAmount = Math.Max(row.GRWT - row.TOTALDIAWT / 5, 0) * Math.Max(metalRate.Amount, 0),
                        MetalKT = row.KT
                    };

                if (row.HasDiamond)
                {
                    var diawt = row.TOTALDIAWT;

                    var tempstncnt = row.DIAPCSDETAIL.Sum();
                    if (tempstncnt != row.TOTALDIAPCS)
                    {
                        row.ErrorMessage = String.Format("Invalid diamond pcs count for type {0}, for record {1}", row.TYPE, row.SRNO);
                        continue;
                    }

                    var tempstnwt = row.DIAWTDETAIL.Sum();
                    if (tempstnwt != row.TOTALDIAWT)
                    {
                        row.ErrorMessage = String.Format("Invalid diamond pcs wt for type {0}, for record {1}", row.TYPE, row.SRNO);
                        continue;
                    }

                    var metailDetail = new List<StoneMetaDetail>();

                    var tempflg = false;
                    for (int i = 0; i < row.SIEVESIZE.Count; i++)
                    {
                        var svSize = row.SIEVESIZE[i];

                        if (CostingRate.CostingItems.Any(x =>
                            x.ProductCategory == ProductCategory.Stone
                            && x.Particulars == row.STONETYPE
                            && x.ConfigurationValue == svSize) == false)
                        {
                            row.ErrorMessage = String.Format("SeiveSize {0} is not defined for record {1}", row.TYPE, row.SRNO);
                            tempflg = true;
                            break;
                        }
                        var stonePcs = row.DIAPCSDETAIL[i];
                        var stoneWt = row.DIAWTDETAIL[i];

                        var price = CostingRate.CostingItems.Single(x => x.ProductCategory == ProductCategory.Stone
                                                                         && x.Particulars == row.STONETYPE && x.ConfigurationValue == svSize);
                        var stoneValue = Math.Max((stoneWt / stoneWt) * price.Amount, 0);
                        metailDetail.Add(new StoneMetaDetail { StoneSieveSz = svSize, StonePcs = stonePcs, StoneWt = stoneWt, StoneValue = stoneValue });
                    }
                    if (tempflg) continue;
                    var stoneChart = new StoneChart { StoneMetaDetailList = metailDetail };

                    var cost = CostingRate.CertificateRate.Items.SingleOrDefault(x => x.RangeMinValue <= diawt && x.RangeMaxValue >= diawt);
                    if (cost == null) // for out of scope
                    {
                        item.CertificateCharges = Math.Max(CostingRate.CertificateRate.Items.Max(x => x.Amount) * diawt, 0);
                    }
                    else if (cost.RangeMinValue == CostingRate.CertificateRate.Items.Min(x => x.RangeMinValue))
                    {
                        item.CertificateCharges = Math.Max(cost.Amount, 0);
                    }
                    else
                    {
                        item.CertificateCharges = Math.Max(cost.Amount * diawt, 0);
                    }

                    item.StoneDetail = new StoneDetail
                    {
                        StoneType = row.STONETYPE,
                        StoneNetWt = row.TOTALDIAWT,
                        TotalStonePcs = row.TOTALDIAPCS,
                        StoneChart = stoneChart,
                        StoneNetAmount = metailDetail.Any() ? Math.Max(metailDetail.Sum(x => x.StoneValue) * row.TOTALDIAWT, 0) : 0
                    };

                }
                item.StampingCharges = Math.Max(row.STAMP, 0);

                var totalPrice = Math.Max(item.StoneDetail.StoneNetAmount + item.CertificateCharges
                                            + item.MetalDetail.MetalNetAmount + labourCharges + item.StampingCharges
                                        , 0);

                var jewelTran = new JewelTransaction
                    {
                        CostingDetail = _costingDetails,
                        TransactionType = TransactionType.PurchaseTransaction,
                        KT = row.KT,
                        CertificateNumber = row.CERTNO,
                        DesignCode = row.DESIGNNO,
                        StonePcs = row.HasDiamond ? row.TOTALDIAPCS : 0,
                        StoneWeight = row.HasDiamond ? row.TOTALDIAWT : 0,
                        //CStonePcs = HasStoneMode && IsColorStoneMode ? Convert.ToInt32(row.GetCellValue(_columncstonepcs)) : 0,
                        //CStoneWeight = HasStoneMode && IsColorStoneMode ? Convert.ToDecimal(row.GetCellValue(_columncstonewt)) : 0,
                        JewelType = row.TYPE,
                        JewelItemCategory = MetalType,
                        MetalWeight = netMetalWt,
                        //MetalColor = row.MetalColor,
                        TotalWeight = row.GRWT,
                        Properties = new TransactionDetails { ItemDetails = item },
                        TransactionPartyRef = ((Supplier)cboCustomer.SelectedItem).SupplierCode,
                        TransactionDate = dtCosting.Value,
                        TotalAmount = totalPrice
                    };
                PurchaseTransactionItems.Add(jewelTran);
            }

            if (allRows.Items.Any(x => !x.IsValid))
            {
                txtUploadError.Height = 55;
                foreach (var row in allRows.Items.Where(x => x.IsValid == false))
                    txtUploadError.Text = txtUploadError.Text + row.ErrorMessage + Environment.NewLine;
            }
            else
            {
                txtUploadError.Height = 1;
            }

            //Bind to grid
            BindToGrid();
        }

        private void BindToGrid()
        {
            var gridRow = 0;
            foreach (var jewel in PurchaseTransactionItems)
            {
                dgvJewel.Rows.Add(1);
                dgvJewel.Rows[gridRow].Height = 40;
                dgvJewel.Rows[gridRow].Cells["CERTNO"].Value = jewel.CertificateNumber;
                dgvJewel.Rows[gridRow].Cells["DesignCode"].Value = jewel.DesignCode;
                dgvJewel.Rows[gridRow].Cells["KT"].Value = jewel.JewelType + "/" + jewel.Properties.ItemDetails.MetalDetail.MetalKT;
                dgvJewel.Rows[gridRow].Cells["GrWt"].Value = jewel.TotalWeight;
                dgvJewel.Rows[gridRow].Cells["NetWt"].Value = jewel.MetalWeight;
                dgvJewel.Rows[gridRow].Cells["DiaWt"].Value = jewel.StoneWeight;
                dgvJewel.Rows[gridRow].Cells["DiaPcs"].Value = jewel.StonePcs;
                dgvJewel.Rows[gridRow].Cells["ColMetalCharges"].Value = jewel.Properties.ItemDetails.MetalDetail.MetalNetAmount;
                dgvJewel.Rows[gridRow].Cells["ColStoneCharges"].Value = jewel.Properties.ItemDetails.StoneDetail.StoneNetAmount;
                dgvJewel.Rows[gridRow].Cells["ColStampCharges"].Value = jewel.Properties.ItemDetails.StampingCharges;
                dgvJewel.Rows[gridRow].Cells["ColLbrCharges"].Value = jewel.Properties.ItemDetails.LabourCharges;
                dgvJewel.Rows[gridRow].Cells["Colcertprice"].Value = jewel.Properties.ItemDetails.CertificateCharges;
                dgvJewel.Rows[gridRow].Cells["ColTotalCharges"].Value = jewel.TotalAmount;

                gridRow = gridRow + 1;
                dgvJewel.FirstDisplayedScrollingRowIndex = dgvJewel.RowCount - 1;
            }
        }

        private void btnDownloadSample_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments),
                Filter = @"Excel (*.xlsx)|*.xlsx|All Files (*.*)|*.*",
                FileName = "COSTING_FORMAT.xlsx"
            };
            dialog.ShowDialog();

            using (var stream = (FileStream)dialog.OpenFile())
            {
                var fs = File.Open(Application.StartupPath + "\\Resource\\COSTING_FORMAT.xlsx", FileMode.OpenOrCreate);
                fs.WriteTo(stream);
                fs.Close();
            }
        }

        private void btnCosting_Click(object sender, LinkLabelLinkClickedEventArgs e)
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

        private JewelData ProcessExcelData(IList<ExcelData> rows)
        {
            var data = new JewelData();
            if (rows.Count == 0) return data;

            for (int i = 0; i < rows.Count(); i++)
            {
                var row = rows[i];
                var item = new JewelData.Item();

                if (row.SRNO == 0)
                {
                    var prev = data.Items.LastOrDefault();
                    if (prev != null)
                    {
                        if (CostingRate.CostingItems.Any(x => x.ProductCategory == ProductCategory.Stone && x.Particulars == prev.STONETYPE) == false)
                        {
                            prev.ErrorMessage = String.Format(@"Costing is not defined for stone type {0}, for record {1}", row.STONETYPE, row.SRNO);
                            continue;
                        }
                        prev.SIEVESIZE.Add(row.SIEVESIZE);
                        prev.DIAPCSDETAIL.Add(row.DIAPCSDETAIL);
                        prev.DIAWTDETAIL.Add(row.DIAWTDETAIL);
                        continue;
                    }
                    item.ErrorMessage = "SrNo no is missing for record " + row.SRNO;
                    data.Items.Add(item);
                    continue;
                }

                // Validation Check Start
                if (row.SRNO != 0)
                {
                    if (row.TYPE.IsEmpty()) { item.ErrorMessage = "Metal type is missing for record " + row.SRNO; data.Items.Add(item); continue; }
                    if (row.GRWT == 0.0M) { item.ErrorMessage = "Total weight is missing for record " + row.SRNO; data.Items.Add(item); continue; }
                    if (row.KT.IsEmpty()) { item.ErrorMessage = "KT detail is missing for record" + row.SRNO; data.Items.Add(item); continue; }
                }

                item.SRNO = row.SRNO;
                item.CERTNO = row.CERTNO;
                item.DESIGNNO = row.DESIGNNO;
                item.GRWT = row.GRWT;
                if (CostingRate.CostingItems.Any(x => x.ProductCategory == ProductCategory.Labour && x.Particulars == row.TYPE) == false)
                {
                    item.ErrorMessage = String.Format("Costing is not defined for type {0}, for record {1}", row.TYPE, row.SRNO);
                    data.Items.Add(item);
                    continue;
                }
                item.TYPE = row.TYPE;

                if (CostingRate.CostingItems.Any(x => x.ProductCategory == ProductCategory.Metal && x.Particulars == row.KT) == false)
                {
                    item.ErrorMessage = String.Format("Costing is not defined for Metal type {0}, for record {1}", row.KT, row.SRNO);
                    data.Items.Add(item);
                    continue;
                }
                item.KT = row.KT;

                if (row.STONETYPE.IsEmpty() == false)
                {
                    item.STONETYPE = row.STONETYPE;
                    if (CostingRate.CostingItems.Any(x => x.ProductCategory == ProductCategory.Stone && x.Particulars == row.STONETYPE) == false)
                    {
                        item.ErrorMessage = String.Format(@"Costing is not defined for stone type {0}, for record {1}
															", row.STONETYPE, row.SRNO);
                        data.Items.Add(item);
                        continue;
                    }

                    item.TOTALDIAPCS = row.TOTALDIAPCS;
                    item.TOTALDIAWT = row.TOTALDIAWT;

                    if (row.TOTALDIAPCS == 00)
                    {
                        item.ErrorMessage = String.Format(@"Invalid dia pcs for stone type {0}, for record {1}
															", row.STONETYPE, row.SRNO);
                        data.Items.Add(item);
                        continue;
                    }

                    if (row.TOTALDIAWT == 00M)
                    {
                        item.ErrorMessage = String.Format(@"Invalid dia pcs for stone type {0}, for record {1}
															", row.STONETYPE, row.SRNO);
                        data.Items.Add(item);
                        continue;
                    }

                    if (row.DIAPCSDETAIL == 00)
                    {
                        item.ErrorMessage = String.Format(@"Invalid dia pcs for stone type {0}, for record {1}
															", row.STONETYPE, row.SRNO);
                        data.Items.Add(item);
                        continue;
                    }

                    if (row.DIAWTDETAIL == 00M)
                    {
                        item.ErrorMessage = String.Format(@"Invalid dia pcs for stone type {0}, for record {1}
															", row.STONETYPE, row.SRNO);
                        data.Items.Add(item);
                        continue;
                    }

                    if (row.SIEVESIZE.IsEmpty() == false && CostingRate.CostingItems.Any(x => x.ProductCategory == ProductCategory.Stone
                            && x.Particulars == row.STONETYPE && x.ConfigurationValue == row.SIEVESIZE) == false)
                    {
                        item.ErrorMessage = String.Format(@"Costing is not defined for stone type {0} with sieve group {1}, for record {2}
															", row.STONETYPE, row.SIEVESIZE, row.SRNO);
                        data.Items.Add(item);
                        continue;
                    }

                    item.SIEVESIZE.Add(row.SIEVESIZE);
                    item.DIAPCSDETAIL.Add(row.DIAPCSDETAIL);
                    item.DIAWTDETAIL.Add(row.DIAWTDETAIL);
                }

                item.CPCS = row.CPCS;
                item.CWT = row.CWT;
                item.STAMP = row.STAMP;
                item.BRAND = row.BRAND;

                data.Items.Add(item);
            }

            // Fill sieve group data to the list
            var correctData = data.Items.Where(x => x.IsValid);
            foreach (var item in correctData)
            {
                if (!item.HasDiamond) continue;
                var tmpFlag = false;

                for (int i = 0; i < item.SIEVESIZE.Count; i++)
                {
                    var sievesz = item.SIEVESIZE[i];
                    var diapcs = item.DIAPCSDETAIL[i];
                    var diawt = item.DIAWTDETAIL[i];
                    if(diapcs == 0) continue;
                    var perpcsrate = diawt / diapcs;
                    var sieveGroups = LocalStore.SieveGroups.GetSieveGroupName(perpcsrate);

                    if (sievesz.IsEmpty()) item.SIEVESIZE[i] = sieveGroups;

                    if (item.SIEVESIZE[i].IsEmpty())
                    {
                        item.ErrorMessage = String.Format(@"Costing is not defined for stone type {0}, for record {1}
															", item.STONETYPE, item.SRNO);
                        tmpFlag = true;
                        break;
                    }

                }

                // ReSharper disable RedundantJumpStatement
                if (tmpFlag) continue;
                // ReSharper restore RedundantJumpStatement
            }

            return data;
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
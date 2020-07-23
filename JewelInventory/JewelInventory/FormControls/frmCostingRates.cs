using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Connections;
using System.Drawing;
using JetCoders.Forms.UI;
using System.Reflection;
using JetCoders.Shared;
using JewelInventory.Properties;

namespace JewelInventory
{
    /// <summary>
    /// http://codemumbler.blogspot.in/2011/02/one-aspect-of-datagridviews-that-you.html
    /// </summary>
    [Obfuscation]
    public partial class frmCostingRates
    {
        private const string _columnSrNo = "No";
        private const string _columncerno = "CER.NO";
        private const string _columntype = "PRODUCTSNAME";
        private const string _columnjewelnumber = "JEWEL NUMBER";
        private const string _columndesignno = "DESIGN NO";
        private const string _columnmetaltype = "METAL TYPE";
        private const string _columnmetalcolor = "METAL COLOR";
        private const string _columngrwt = "GR.WT";
        private const string _columnntwt = "NT.WT";
        private const string _columngamt = "G.AMT";
        private const string _columncsstonetype = "CSSTONE TYPE";
        private const string _columncstonepcs = "COL.PCS";
        private const string _columncstonewt = "COL.WT";

        private const string _columnstonetype = "STONE TYPE";
        private const string _columndiapcs = "DIA.PCS";
        private const string _columndiawt = "DIA.WT";
        private const string _columnsievsz = "SIEV.SZ";
        private const string _columndiapcsdetails = "DIA PCS Details";
        private const string _columndiawtdetails = "DIA.WT Details";
        private const string _columnavrdia = "AVR.DIA";
        private const string _columndiapr = "DIA.PR";
        private const string _columndiaval = "DIA.VAL";
        private const string _columndiavalsum = "DIA.VAL SUM";
        private const string _columnlabr = "LABR";

        private const string _columncert = "CERT";
        private const string _columnstamp = "STAMPING";
        private const string _columnamount = "AMOUNT";

        private bool JewelHasStone { get { return IsStoneMode || IsColorStoneMode; } }

        public string SelectedDiaValue { get; set; }
        public string SelectedCSStoneValue { get; set; }

        bool IsStoneMode { get { return Collection.Any(x => x.Particulars == SelectedDiaValue && x.ProductCategory == ProductCategory.Stone && x.JewelItemCategory == ItemCategory); } }
        bool IsColorStoneMode
        {
            get
            {
                return Collection.Any(x => x.Particulars == SelectedCSStoneValue
                  && x.ProductCategory == ProductCategory.ColorStone
                  && x.JewelItemCategory == ItemCategory);
            }
        }

        public void ClearDataGridView(DataGridView mapGrid)
        {
            mapGrid.Rows.Clear();
            mapGrid.Columns.Clear();
        }

        void CostingGridEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var grid = (sender as DataGridView);

            if (grid == null)
                return;

            if (e.Control is DataGridViewTextBoxEditingControl)
                if (grid.CurrentCell.OwningColumn.Name == _columndiapcsdetails.ToLowerCaseColumnName() || grid.CurrentCell.OwningColumn.Name == _columndiawtdetails.ToLowerCaseColumnName())
                {
                    (e.Control as DataGridViewTextBoxEditingControl).KeyDown -= DIAPCS_ENTERKEY;
                    (e.Control as DataGridViewTextBoxEditingControl).KeyDown += DIAPCS_ENTERKEY;
                }

            if (grid.CurrentRow.Index >= 1)
                return;

            e.Control.LostFocus += null;

            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                if (grid.CurrentCell.OwningColumn.Name == _columnstonetype.ToLowerCaseColumnName())
                {
                    e.Control.LostFocus -= DIA_ENABLE_MODE;
                    e.Control.LostFocus -= CSTONE_ENABLE_MODE;
                    e.Control.LostFocus += DIA_ENABLE_MODE;
                }
                else if (grid.CurrentCell.OwningColumn.Name == _columncsstonetype.ToLowerCaseColumnName())
                {
                    e.Control.LostFocus -= CSTONE_ENABLE_MODE;
                    e.Control.LostFocus -= DIA_ENABLE_MODE;
                    e.Control.LostFocus += CSTONE_ENABLE_MODE;
                }
            }
        }

        void CSTONE_ENABLE_MODE(object sender, EventArgs e)
        {
            if (sender is DataGridViewComboBoxEditingControl)
            {
                var gridCombo = (sender as DataGridViewComboBoxEditingControl);

                SelectedCSStoneValue = gridCombo.SelectedItem.ToString();

                RefreshCSStoneGrid(gridCombo.EditingControlRowIndex);
                if (SelectedCSStoneValue != "None")
                {
                    var currRow = dgCostingFormat.Rows[gridCombo.EditingControlRowIndex];
                    dgCostingFormat[_columncstonepcs.ToLowerCaseColumnName(), currRow.Index].ReadOnly = false;
                    dgCostingFormat[_columncstonewt.ToLowerCaseColumnName(), currRow.Index].ReadOnly = false;
                }
            }
        }

        void DIA_ENABLE_MODE(object sender, EventArgs e)
        {
            if (sender is DataGridViewComboBoxEditingControl)
            {
                var gridCombo = (sender as DataGridViewComboBoxEditingControl);

                SelectedDiaValue = gridCombo.SelectedItem.ToString();

                RefreshStoneGrid(gridCombo.EditingControlRowIndex);
                if (SelectedDiaValue != "None")
                {
                    var currRow = dgCostingFormat.Rows[gridCombo.EditingControlRowIndex];
                    dgCostingFormat[_columndiapcs.ToLowerCaseColumnName(), currRow.Index].ReadOnly = false;
                    dgCostingFormat[_columndiawt.ToLowerCaseColumnName(), currRow.Index].ReadOnly = false;
                    dgCostingFormat[_columndiapcsdetails.ToLowerCaseColumnName(), currRow.Index].ReadOnly = false;
                    dgCostingFormat[_columndiawtdetails.ToLowerCaseColumnName(), currRow.Index].ReadOnly = false;
                }
            }
        }

        void RefreshCSStoneGrid(int index)
        {
            var gridRows = dgCostingFormat.Rows;
            var rowList = new List<DataGridViewRow>();
            foreach (var row in gridRows)
            {
                var currRow = (DataGridViewRow)row;
                if (index == currRow.Index)
                {
                    var columncstonepcs = dgCostingFormat[_columncstonepcs.ToLowerCaseColumnName(), currRow.Index];
                    {
                        columncstonepcs.ReadOnly = true;
                        columncstonepcs.Value = String.Empty;
                    }

                    var columncstonewt = dgCostingFormat[_columncstonewt.ToLowerCaseColumnName(), currRow.Index];
                    {
                        columncstonewt.ReadOnly = true;
                        columncstonewt.Value = String.Empty;
                    }
                    continue;
                }
                rowList.Add(currRow);
            }
            foreach (var row in rowList)
            {
                dgCostingFormat.Rows.Remove(row);
            }
        }

        void RefreshStoneGrid(int index)
        {
            var gridRows = dgCostingFormat.Rows;
            var rowList = new List<DataGridViewRow>();
            foreach (var row in gridRows)
            {
                var currRow = row as DataGridViewRow;
                if (index == currRow.Index)
                {
                    var columndiapcs = dgCostingFormat[_columndiapcs.ToLowerCaseColumnName(), currRow.Index];
                    {
                        columndiapcs.ReadOnly = true;
                        columndiapcs.Value = String.Empty;
                    }

                    var columndiawt = dgCostingFormat[_columndiawt.ToLowerCaseColumnName(), currRow.Index];
                    {
                        columndiawt.ReadOnly = true;
                        columndiawt.Value = String.Empty;
                    }

                    var columndiapcsdetails = dgCostingFormat[_columndiapcsdetails.ToLowerCaseColumnName(), currRow.Index];
                    {
                        columndiapcsdetails.ReadOnly = true;
                        columndiapcsdetails.Value = String.Empty;
                    }

                    var columndiawtdetails = dgCostingFormat[_columndiawtdetails.ToLowerCaseColumnName(), currRow.Index];
                    {
                        columndiawtdetails.ReadOnly = true;
                        columndiawtdetails.Value = String.Empty;
                    }

                    var columnsievsz = dgCostingFormat[_columnsievsz.ToLowerCaseColumnName(), currRow.Index];
                    {
                        columnsievsz.ReadOnly = true;
                        columnsievsz.Value = String.Empty;
                    }

                    var columnavrdia = dgCostingFormat[_columnavrdia.ToLowerCaseColumnName(), currRow.Index];
                    {
                        columnavrdia.ReadOnly = true;
                        columnavrdia.Value = String.Empty;
                    }

                    var columndiaval = dgCostingFormat[_columndiaval.ToLowerCaseColumnName(), currRow.Index];
                    {
                        columndiaval.ReadOnly = true;
                        columndiaval.Value = String.Empty;
                    }
                }
                else
                {
                    rowList.Add(currRow);
                }
            }
            foreach (var row in rowList)
            {
                dgCostingFormat.Rows.Remove(row);
            }
        }

        void OnAddtoListClick(object sender, EventArgs e)
        {
            if (_validateForm(this) == false)
            {
                MessageBox.Show(Resources.frmCostingRates_OnAddtoListClick_Incomplete_information_provided_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            ItemDetail transactionDetails;

            if (!_validateDataGrid(dgCostingFormat, out transactionDetails))
                return;

            // Create a local collection of costing rates
            DataGridViewRow row = dgCostingFormat.Rows[0];

            // make a list of purchaseJewelsRequest and save it to database.
            var item = new JewelTransaction
            {
                JewelItemCategory = ItemCategory,
                CostingDetail = new CostingDetail { Properties = CostingRate },
                TransactionType = TransactionType.PurchaseTransaction,
                KT = row.GetCellValue(_columnmetaltype),
                CertificateNumber = row.GetCellValue(_columncerno),
                DesignCode = row.GetCellValue(_columndesignno),
                StonePcs = JewelHasStone ? row.GetParsedCellValue<int>(_columndiapcs) : 0,
                StoneWeight = JewelHasStone ? row.GetParsedCellValue<decimal>(_columndiawt) : 0,
                CStonePcs = JewelHasStone ? row.GetParsedCellValue<int>(_columncstonepcs) : 0,
                CStoneWeight = JewelHasStone ? row.GetParsedCellValue<decimal>(_columncstonewt) : 0,
                JewelType = row.GetCellValue(_columntype),
                TotalWeight = Convert.ToDecimal(row.GetCellValue(_columngrwt)),
                MetalWeight = Convert.ToDecimal(row.GetCellValue(_columnntwt)),
                MetalColor = row.GetCellValue(_columnmetalcolor),
                Properties = new TransactionDetails { ItemDetails = transactionDetails },
                TransactionPartyRef = ((Supplier)cboCustomer.SelectedItem).SupplierCode,
                TransactionDate = dtCosting.Value,
                JewelTransactionRowId = Guid.NewGuid(),
            };

            PurchaseTransactionItems.Add(item);

            _addtoPanel(item);

            ResetDataGridView(dgCostingFormat);
        }

        void _addtoPanel(JewelTransaction item)
        {
            var panel = new Panel { Tag = item.JewelTransactionRowId };

            panel.MouseClick += JewelItemClick;
            var menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem("Remove Item", _itemremovefromPanel));
            panel.ContextMenu = menu;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Cursor = Cursors.Hand;
            panel.BackgroundImageLayout = ImageLayout.Stretch;
            panel.Size = new Size(71, 46);
            panel.BackgroundImage = ImageExtension.ResolveImage(item.DesignCode);
            flowLayout.Controls.Add(panel);
        }

        void JewelItemClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var panel = sender as Panel;
            if (panel == null) return;

            var item = PurchaseTransactionItems.SingleOrDefault(x => x.JewelTransactionRowId == (Guid)panel.Tag);

            if (item != null)
            {
                var frm = new frmItemDetail();
                frm.BindForm(item.Properties.ItemDetails);
                frm.Show();
            }
        }

        void _itemremovefromPanel(object sender, EventArgs e)
        {
            var mnuItem = sender as MenuItem;
            if (mnuItem == null) return;

            var panel = mnuItem.GetContextMenu().SourceControl;
            //get a item
            var item = PurchaseTransactionItems.SingleOrDefault(x => x.JewelTransactionRowId == (Guid)panel.Tag);
            if (item != null)
            {
                PurchaseTransactionItems.Remove(item);
                flowLayout.Controls.Remove(panel);
                flowLayout.PerformLayout();
            }
        }


        void OnClearAllItemsClick(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Resources.frmCostingRates_OnClearAllItemsClick_Are_you_sure_want_to_clear_out_all_records_, Constants.ALERTMESSAGEHEADER, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            PurchaseTransactionItems = new List<JewelTransaction>();

            flowLayout.Controls.Clear();
            ResetDataGridView(dgCostingFormat);
        }

        void OnClearGridClick(object sender, EventArgs e)
        {
            ResetDataGridView(dgCostingFormat);
        }

        void OnCostingFormatCellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Calculate(dgCostingFormat, e.RowIndex);
            }
        }

        void OnCostingFormatCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgCostingFormat.Rows[e.RowIndex].ErrorText = String.Empty;
            errorProvider.Clear();

            foreach (DataGridViewRow row in dgCostingFormat.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style = cell.ReadOnly ? new DataGridViewCellStyle { BackColor = Color.LightGray } : new DataGridViewCellStyle { BackColor = Color.White };
                }
            }
        }

        void OnCostingFormatCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgCostingFormat.Columns[e.ColumnIndex].Name == _columngrwt.ToLowerCaseColumnName() ||
                dgCostingFormat.Columns[e.ColumnIndex].Name == _columndiawt.ToLowerCaseColumnName() ||
                dgCostingFormat.Columns[e.ColumnIndex].Name == _columndiawtdetails.ToLowerCaseColumnName() ||
                dgCostingFormat.Columns[e.ColumnIndex].Name == _columnamount.ToLowerCaseColumnName() ||
                dgCostingFormat.Columns[e.ColumnIndex].Name == _columncstonewt.ToLowerCaseColumnName() ||
                dgCostingFormat.Columns[e.ColumnIndex].Name == _columnstamp.ToLowerCaseColumnName() ||
                dgCostingFormat.Columns[e.ColumnIndex].Name == _columncert.ToLowerCaseColumnName()
                )
            {
                decimal val;
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false && Decimal.TryParse(e.FormattedValue.ToString(), out val) == false)
                {
                    errorProvider.SetError(dgCostingFormat, "Invalid amount field.");
                    e.Cancel = true;
                }
            }
            else if (dgCostingFormat.Columns[e.ColumnIndex].Name == _columndiapcs.ToLowerCaseColumnName()
                                || dgCostingFormat.Columns[e.ColumnIndex].Name == _columndiapcsdetails.ToLowerCaseColumnName()
                                || dgCostingFormat.Columns[e.ColumnIndex].Name == _columncstonepcs.ToLowerCaseColumnName())
            {
                Int32 val;
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false && Int32.TryParse(e.FormattedValue.ToString(), out val) == false)
                {
                    errorProvider.SetError(dgCostingFormat, "Invalid amount field.");
                    e.Cancel = true;
                }
            }
        }

        void OnCostingFormatCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView)
            {
                var grid = (DataGridView)sender;

                if (grid.CurrentRow.Index > 0)
                {
                    if (!(grid.CurrentCell.OwningColumn.Name == _columndiapcsdetails.ToLowerCaseColumnName() ||
                        grid.CurrentCell.OwningColumn.Name == _columndiawtdetails.ToLowerCaseColumnName()))
                    {
                        var colindex = grid.Columns[_columndiapcsdetails.ToLowerCaseColumnName()].Index;
                        if (!setNextTabableCell(grid, colindex, e.RowIndex))
                        {
                            setNextTabableControl();
                        }
                    }
                }

                if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
                {
                    //this cell is readonly, find the next tabable cell
                    if (!setNextTabableCell(grid, e.ColumnIndex, e.RowIndex))
                    {
                        //or tab to the next control
                        setNextTabableControl();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("this method can only be applied to controls of type DataGridView");
            }
        }

        #region CONFIGDATAGRIDVIEW
        public void ConfigDataGridView(DataGridView mapGrid)
        {
            mapGrid.Columns.Add(GetDescriptionColumn(_columnSrNo, true));
            mapGrid.Columns.Add(GetDescriptionColumn(_columncerno, false));
            GridExtension.FormatToUpperCaseTextBox(mapGrid, _columncerno.ToLowerCaseColumnName());

            mapGrid.Columns.Add(GetListColumn(_columntype,
                CostingRate.CostingItems.Where(x => x.ProductCategory == ProductCategory.Labour).Select(x => x.Particulars).Distinct().ToList(), null));

            mapGrid.Columns.Add(GetDescriptionColumn(_columnjewelnumber, true));
            mapGrid.Columns.Add(GetDescriptionColumn(_columndesignno, false));
            GridExtension.FormatToUpperCaseTextBox(mapGrid, _columndesignno.ToLowerCaseColumnName());

            mapGrid.Columns.Add(GetListColumn(_columnmetaltype,
                CostingRate.CostingItems.Where(x => x.ProductCategory == ProductCategory.Metal).Select(x => x.Particulars).Distinct().ToList(), null));
            mapGrid.Columns.Add(GetDescriptionColumn(_columnmetalcolor, false));
            GridExtension.FormatToUpperCaseTextBox(mapGrid, _columnmetalcolor.ToLowerCaseColumnName());

            mapGrid.Columns.Add(GetDescriptionColumn(_columngrwt, false));
            mapGrid.Columns.Add(GetDescriptionColumn(_columnntwt, true));	// total dia wt(e22-i22/5)
            mapGrid.Columns.Add(GetDescriptionColumn(_columngamt, true));	// costing slab for gold rate date wise for client wise

            var CSStoneItmes = new List<String> { "None" };

            CSStoneItmes.AddRange(CostingRate.CostingItems.Where(x => x.ProductCategory == ProductCategory.ColorStone).Select(x => x.Particulars).Distinct());
            mapGrid.Columns.Add(GetListColumn(_columncsstonetype, CSStoneItmes, null));

            mapGrid.Columns.Add(GetDescriptionColumn(_columncstonepcs, true));
            mapGrid.Columns.Add(GetDescriptionColumn(_columncstonewt, true));

            var StoneItmes = new List<String> { "None" };
            StoneItmes.AddRange(CostingRate.CostingItems.Where(x => x.ProductCategory == ProductCategory.Stone).Select(x => x.Particulars).Distinct());
            mapGrid.Columns.Add(GetListColumn(_columnstonetype, StoneItmes, null));

            mapGrid.Columns.Add(GetDescriptionColumn(_columndiapcs, true)); //to get total dia pcs it requires costing sheet as bifercation of total pcs according to there sieve size and it should be date wise and client wise
            mapGrid.Columns.Add(GetDescriptionColumn(_columndiawt, true));
            mapGrid.Columns.Add(GetDescriptionColumn(_columnsievsz, true));	//PICK UP FROM COSTING CHART
            mapGrid.Columns.Add(GetDescriptionColumn(_columndiapcsdetails, true));
            mapGrid.Columns.Add(GetDescriptionColumn(_columndiawtdetails, true));
            mapGrid.Columns.Add(GetDescriptionColumn(_columnavrdia, true));

            mapGrid.Columns.Add(GetDescriptionColumn(_columndiapr, true));

            mapGrid.Columns.Add(GetDescriptionColumn(_columndiaval, true));
            mapGrid.Columns.Add(GetDescriptionColumn(_columndiavalsum, true));

            mapGrid.Columns.Add(GetDescriptionColumn(_columnlabr, true));

            mapGrid.Columns.Add(GetDescriptionColumn(_columncert, true));
            mapGrid.Columns.Add(GetDescriptionColumn(_columnstamp, false));
            mapGrid.Columns.Add(GetDescriptionColumn(_columnamount, true));
        }

        private DataGridViewTextBoxColumn GetDescriptionColumn(string column, bool isReadlyOnly, object value = null)
        {
            var columnForDescription = new DataGridViewTextBoxColumn
            {
                Name = column.ToLowerCaseColumnName(),
                HeaderText = column,
                ReadOnly = isReadlyOnly
            };

            if (value != null)
                columnForDescription.CellTemplate.Value = value;
            columnForDescription.Width = 250;

            if (isReadlyOnly)
                columnForDescription.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightGray };

            columnForDescription.SortMode = DataGridViewColumnSortMode.NotSortable;

            return columnForDescription;
        }

        void DIAPCS_ENTERKEY(object sender, KeyEventArgs e)
        {
            if (sender is DataGridViewTextBoxEditingControl)
            {
                var grid = dgCostingFormat;
                if ((grid.CurrentCell.RowIndex + 1) == grid.RowCount)
                {
                    AddDataRowGridView(dgCostingFormat);
                }
            }
        }

        void ResetDataGridView(DataGridView mapGrid)
        {
            SelectedDiaValue = SelectedCSStoneValue = null;
            ClearDataGridView(mapGrid);
            ConfigDataGridView(mapGrid);
            AddDataRowGridView(mapGrid);
        }

        void AddDataRowGridView(DataGridView mapGrid)
        {
            if (mapGrid.Rows.Count > 0 == false)
            {
                mapGrid.Rows.Add(mapGrid.Rows.Count + 1, "",
                            CostingRate.CostingItems.First(x => x.ProductCategory == ProductCategory.Labour).Particulars,
                            "Auto Number", "",
                            CostingRate.CostingItems.First(x => x.ProductCategory == ProductCategory.Metal).Particulars,
                            "", "", "", "",
                            "None"
                            , "", "", "None", "", "", "", "", "", "", "", "", "", "", "", CostingRate.StampingRates, "");

                return;
            }

            mapGrid.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
        }

        private DataGridViewComboBoxColumn GetListColumn(string column, object dataSource, EventArgs e)
        {
            var columnForDescription = new DataGridViewComboBoxColumn
            {
                Name = column.ToLowerCaseColumnName(),
                HeaderText = column
            };

            foreach (var perticular in (List<String>)dataSource)
            {
                columnForDescription.Items.Add(perticular);
            }

            return columnForDescription;
        }
        #endregion

        #region GridviewUtiliy
        private delegate void SetColumnAndRowOnGrid(DataGridView grid, int i, int o);

        private bool setNextTabableCell(DataGridView grid, int nextColumn, int nextRow)
        {
            do
            {
                if (nextColumn == grid.Columns.Count - 1)
                {
                    nextColumn = 0;
                    if (nextRow == grid.Rows.Count - 1)
                    {
                        return false;
                    }
                    nextRow = Math.Min(grid.Rows.Count - 1, nextRow + 1);
                }
                else
                {
                    nextColumn = Math.Min(grid.Columns.Count - 1, nextColumn + 1);
                }
            }
            while (grid.Rows[nextRow].Cells[nextColumn].ReadOnly ||
                        grid.Rows[nextRow].Cells[nextColumn].Visible == false);

            SetColumnAndRowOnGrid method = setGridCell;
            grid.BeginInvoke(method, grid, nextColumn, nextRow);
            return true;
        }

        private void setGridCell(DataGridView grid, int columnIndex, int rowIndex)
        {
            grid.CurrentCell = grid.Rows[rowIndex].Cells[columnIndex];
            grid.BeginEdit(true);
        }

        private void setNextTabableControl()
        {
            SelectNextControl(this, true, true, true, true);
        }

        #endregion

        #region CALCULATE
        private void Calculate(DataGridView mapGrid, Int32 RowIndex)
        {
            CalculateNetMetalWeight(mapGrid, RowIndex);
            CalculateNetMetalAmount(mapGrid, RowIndex);

            if (JewelHasStone)
            {
                if (IsStoneMode)
                {
                    CalculateAverageDiamondWeigth(mapGrid, RowIndex);
                    CalculateSievesizeAndAvgDiamondPrize(mapGrid, RowIndex);
                    CalculateNetStoneAmount(mapGrid);
                    CalculateCertificateAmount(mapGrid, RowIndex);
                }
                else if (IsColorStoneMode)
                {
                    CalculateNetStoneAmount(mapGrid);
                }
            }

            CalculateLabourAmount(mapGrid, RowIndex);
            CalculateFinalAmount(mapGrid, RowIndex);
        }

        private void CalculateCertificateAmount(DataGridView mapGrid, int RowIndex)
        {
            var returnVal = default(Decimal);
            DataGridViewRow row = mapGrid.Rows[RowIndex];

            if (row.ValidateDependentProperties(_columndiawt))
            {
                if (CostingRate.CertificateRate == null)
                    return;

                var diawt = row.GetParsedCellValue<decimal>(_columndiawt);
                var cost = CostingRate.CertificateRate.Items.SingleOrDefault(x => x.RangeMinValue <= diawt && x.RangeMaxValue >= diawt);

                if (cost != null) // for out of scope
                    returnVal = cost.Amount * diawt;
            }

            row.Cells[_columncert.ToLowerCaseColumnName()].Value = returnVal;
        }

        private void CalculateLabourAmount(DataGridView mapGrid, int RowIndex)
        {
            var returnVal = default(Decimal);
            DataGridViewRow row = mapGrid.Rows[RowIndex];

            if (row.ValidateDependentProperties(_columnntwt, _columntype))
            {
                var prodType = row.GetCellValue(_columntype);

                var labour = CostingRate.CostingItems.SingleOrDefault(x => x.Particulars == prodType && x.ProductCategory == ProductCategory.Labour);

                if (labour == null)
                    return;

                var labourCost = labour.Amount;
                var minlabourCost = labour.MinimumAmount;

                if (Convert.ToDecimal(row.GetCellValue(_columnntwt)) * labourCost <= minlabourCost)
                {
                    returnVal = Math.Max(minlabourCost, 0);
                }
                else
                {
                    returnVal = Convert.ToDecimal(row.GetCellValue(_columnntwt)) * labourCost;
                }
            }

            row.Cells[_columnlabr.ToLowerCaseColumnName()].Value = returnVal;

        }

        private void CalculateNetStoneAmount(DataGridView mapGrid)
        {
            //cs stone
            Decimal returnVal = default(decimal);
            DataGridViewRow mainRow = mapGrid.Rows[0];
            if (IsColorStoneMode)
            {
                if (mainRow.ValidateDependentProperties(_columncstonepcs, _columncstonewt))
                {
                    var diaPerticulars = mapGrid.Rows[0].GetCellValue(_columncsstonetype);
                    var costing = CostingRate.CostingItems.SingleOrDefault(x => x.Particulars == diaPerticulars && x.ProductCategory == ProductCategory.ColorStone);

                    if (costing == null)
                        return;

                    returnVal = costing.Particulars == ColorStones.CubicZirconia ? Math.Max(Convert.ToDecimal(mainRow.Cells[_columncstonepcs.ToLowerCaseColumnName()].Value) * costing.Amount, 0) : Math.Max(Convert.ToDecimal(mainRow.Cells[_columncstonewt.ToLowerCaseColumnName()].Value) * costing.Amount, 0);
                }
            }

            //diamond
            if (IsStoneMode)
            {
                returnVal += (from DataGridViewRow row in mapGrid.Rows where row.ValidateDependentProperties(_columndiaval) select (decimal)row.Cells[_columndiaval.ToLowerCaseColumnName()].Value).Sum();
            }

            mainRow.Cells[_columndiavalsum.ToLowerCaseColumnName()].Value = returnVal;
        }


        private void CalculateFinalAmount(DataGridView mapGrid, int rowIndex)
        {
            var returnVal = default(decimal);
            DataGridViewRow row = mapGrid.Rows[rowIndex];

            if (JewelHasStone)
            {
                decimal stamp;
                Decimal.TryParse(row.GetCellValue(_columnstamp, true), out stamp);

                if (row.ValidateDependentProperties(_columngamt, _columndiavalsum, _columnlabr))
                {
                    returnVal = Math.Max(
                              Convert.ToDecimal(row.GetCellValue(_columngamt))
                            + Convert.ToDecimal(row.GetCellValue(_columndiavalsum))
                            + Convert.ToDecimal(row.GetCellValue(_columnlabr))
                            + stamp, 0);

                    if (row.ValidateDependentProperties(_columncert))
                    {
                        returnVal += Math.Max(Convert.ToDecimal(row.GetCellValue(_columncert)), 0);
                    }
                }
            }
            else
            {
                if (row.ValidateDependentProperties(_columngamt, _columnlabr))
                {
                    returnVal = Math.Max(Convert.ToDecimal(row.GetCellValue(_columngamt))
                            + Convert.ToDecimal(row.GetCellValue(_columnlabr))
                            , 0);
                }
            }

            row.Cells[_columnamount.ToLowerCaseColumnName()].Value = returnVal;
        }

        private void CalculateSievesizeAndAvgDiamondPrize(DataGridView mapGrid, int rowIndex)
        {
            var avgDiaPrize = default(decimal);
            var DiaPrize = default(decimal);
            var sieveSize = String.Empty;
            var diaPerticulars = mapGrid.Rows[0].GetCellValue(_columnstonetype);

            DataGridViewRow row = mapGrid.Rows[rowIndex];

            if (row.ValidateDependentProperties(_columndiawtdetails, _columnavrdia))
            {
                var avgDiamondvalue = Convert.ToDecimal(row.GetCellValue(_columnavrdia));
                var Diamondvalue = Convert.ToDecimal(row.GetCellValue(_columndiawtdetails));
                sieveSize = LocalStore.SieveGroups.GetSieveGroupName(avgDiamondvalue);

                var item = CostingRate.CostingItems.FirstOrDefault(x => x.Particulars == diaPerticulars && x.ConfigurationValue == sieveSize && x.ProductCategory == ProductCategory.Stone);

                avgDiaPrize = item == null ? default(decimal) : item.Amount;
                DiaPrize = Diamondvalue * avgDiaPrize;
            }

            row.Cells[_columnsievsz.ToLowerCaseColumnName()].Value = sieveSize;
            row.Cells[_columndiapr.ToLowerCaseColumnName()].Value = avgDiaPrize;
            row.Cells[_columndiaval.ToLowerCaseColumnName()].Value = DiaPrize;
        }

        private void CalculateAverageDiamondWeigth(DataGridView mapGrid, int rowIndex)
        {
            var returnVal = default(decimal);
            DataGridViewRow row = mapGrid.Rows[rowIndex];

            if (row.ValidateDependentProperties(_columndiapcsdetails, _columndiawtdetails))
            {
                if (Convert.ToDecimal(row.GetCellValue(_columndiapcsdetails)) != 0)
                {
                    returnVal = Math.Max(Convert.ToDecimal(row.GetCellValue(_columndiawtdetails))
                            / Convert.ToDecimal(row.GetCellValue(_columndiapcsdetails)), 0);
                }
            }

            row.Cells[_columnavrdia.ToLowerCaseColumnName()].Value = returnVal;
        }

        private void CalculateNetMetalAmount(DataGridView mapGrid, int rowIndex)
        {
            var returnVal = default(decimal);
            DataGridViewRow row = mapGrid.Rows[rowIndex];

            if (row.ValidateDependentProperties(_columnmetaltype, _columnntwt))
            {
                var metalType = row.GetCellValue(_columnmetaltype);
                var rate = CostingRate.CostingItems.FirstOrDefault(x => x.ProductCategory == ProductCategory.Metal && x.Particulars == metalType);


                returnVal = Math.Max(Convert.ToDecimal(row.GetCellValue(_columnntwt))
                            * Convert.ToDecimal(rate.Amount), 0);
            }

            row.Cells[_columngamt.ToLowerCaseColumnName()].Value = returnVal;
        }

        public void CalculateNetMetalWeight(DataGridView mapGrid, Int32 rowIndex)
        {
            var returnVal = default(decimal);
            DataGridViewRow row = mapGrid.Rows[rowIndex];

            if (JewelHasStone)
            {
                if (row.ValidateDependentProperties(_columngrwt, _columndiawt))
                {
                    if (returnVal > 0)
                        returnVal = Math.Max(returnVal
                                - (Convert.ToDecimal(row.GetCellValue(_columndiawt)) / 5), 0);
                    else
                        returnVal = Math.Max(Convert.ToDecimal(row.GetCellValue(_columngrwt))
                                                          - (Convert.ToDecimal(row.GetCellValue(_columndiawt)) / 5), 0);
                }
                if (row.ValidateDependentProperties(_columngrwt, _columncstonewt))
                {
                    returnVal = returnVal > 0 ? Math.Max(returnVal - Convert.ToDecimal(row.GetCellValue(_columncstonewt)), 0) : Math.Max(Convert.ToDecimal(row.GetCellValue(_columngrwt)) - Convert.ToDecimal(row.GetCellValue(_columncstonewt)), 0);
                }
            }
            else
            {
                if (row.ValidateDependentProperties(_columngrwt))
                {
                    returnVal = Math.Max(Convert.ToDecimal(row.GetCellValue(_columngrwt)), 0);
                }
            }

            row.Cells[_columnntwt.ToLowerCaseColumnName()].Value = returnVal;
        }

        private bool _validateDataGrid(DataGridView mapGrid, out ItemDetail itemDetail)
        {
            itemDetail = new ItemDetail();

            DataGridViewRow row = mapGrid.Rows[0];

            if (row == null) throw new IndexOutOfRangeException("No rows found");

            // Validate inline row details
            AllErrors.Clear();
            if (row.ValidateDependentProperties(_columntype) == false)
                AllErrors.Add("JewelType", "JewelType is required.");

            if (row.ValidateDependentProperties(_columnjewelnumber) == false)
                AllErrors.Add("JewelNumber", "JewelNumber is required.");

            if (row.ValidateDependentProperties(_columnntwt) == false)
                AllErrors.Add("MetalWeight", "Total MetalWeight is required.");

            if (JewelHasStone)
            {
                if (IsStoneMode)
                {
                    if (row.ValidateDependentProperties(_columndiawt) == false)
                        AllErrors.Add("DiamondWeight", "Total Diamond Weight is required.");

                    if (row.ValidateDependentProperties(_columndiapcs) == false)
                        AllErrors.Add("DiamondPcs", "Total Diamond Pcs required.");

                    if (row.ValidateDependentProperties(_columngrwt, _columndiawt))
                        if (row.GetParsedCellValue<decimal>(_columngrwt) - row.GetParsedCellValue<decimal>(_columndiawt) < 0)
                        {
                            AllErrors.Add("InvalidDiamondWeight", "Invalid diamond weight.");
                        }
                }
                else if (IsColorStoneMode)
                {
                    if (row.ValidateDependentProperties(_columncstonewt) == false)
                        AllErrors.Add("ColorStoneWeight", "Total ColorStone Weight is required.");

                    if (row.ValidateDependentProperties(_columncstonepcs) == false)
                        AllErrors.Add("ColorStonePcs", "Total ColorStone Pcs is required.");

                    if (row.ValidateDependentProperties(_columngrwt, _columncstonewt))
                        if (row.GetParsedCellValue<decimal>(_columngrwt) - row.GetParsedCellValue<decimal>(_columncstonewt) < 0)
                        {
                            AllErrors.Add("InvalidColorStoneWeight", "Invalid ColorStone weight.");
                        }
                }

                if (row.ValidateDependentProperties(_columngrwt, _columndiawt, _columncstonewt))
                    if (row.GetParsedCellValue<decimal>(_columngrwt) - (row.GetParsedCellValue<decimal>(_columndiawt) + row.GetParsedCellValue<decimal>(_columncstonewt)) < 0)
                    {
                        AllErrors.Add("InvalidTotalWeight", "Invalid total stone weights.");
                    }
            }

            if (row.ValidateDependentProperties(_columnamount) == false)
                AllErrors.Add("TotalAmount", "TotalAmount is required.");

            if (AllErrors.Count > 0)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return false;
            }

            if (JewelHasStone)
            {
                if (IsStoneMode)
                {
                    // Validate DiamondPcs with the bifercation row details
                    Int32 returnValdiaPcs = default(Int32);
                    Decimal returnValdiaWt = default(decimal);
                    var diaPcs = Convert.ToInt32(row.GetCellValue(_columndiapcs));
                    var diaWt = Convert.ToDecimal(row.GetCellValue(_columndiawt));

                    foreach (DataGridViewRow curRow in mapGrid.Rows)
                    {
                        if (curRow.ValidateDependentProperties(_columndiapcsdetails) && curRow.ValidateDependentProperties(_columndiawtdetails))
                        {
                            returnValdiaPcs += Convert.ToInt32(curRow.Cells[_columndiapcsdetails.ToLowerCaseColumnName()].Value);
                        }
                        if (curRow.ValidateDependentProperties(_columndiawtdetails) && curRow.ValidateDependentProperties(_columndiapcsdetails))
                        {
                            returnValdiaWt += Convert.ToDecimal(curRow.Cells[_columndiawtdetails.ToLowerCaseColumnName()].Value);
                        }
                    }

                    if (returnValdiaPcs != diaPcs)
                        AllErrors.Add("InvalidDiamondPcs", "Invalid diamond pcs count.");

                    if (returnValdiaWt != diaWt)
                        AllErrors.Add("TotalDiamondPcs", "Total diamond weight must match with sum of diamonds weight.");

                    if (mapGrid.Rows.Cast<DataGridViewRow>().Where(curRow => curRow.ValidateDependentProperties(_columnavrdia)).Any(curRow => row.ValidateDependentProperties(_columndiapr) == false))
                    {
                        AllErrors.Add("TotalDiamondPrices", "Invalid diamond prices, please define costing.");
                    }

                    if (ItemCategory == JewelItemCategory.Gold && false == CostingRate.CertificateRate.Items.Any(x => x.RangeMinValue <= diaWt && x.RangeMaxValue >= diaWt))
                    {
                        AllErrors.Add("CertificateCosting", "Certificate costing is not defined.");
                    }
                }
                else if (IsColorStoneMode)
                {
                    if (row.ValidateDependentProperties(_columncstonepcs) == false)
                    {
                        AllErrors.Add("ColorStonePices", "ColorStone pcs is required.");
                    }

                    if (row.ValidateDependentProperties(_columncstonewt) == false)
                    {
                        AllErrors.Add("ColorStoneWeight", "Total ColorStoneWeight is required.");
                    }
                    else
                    {
                        var grwt = Convert.ToDecimal(row.Cells[_columngrwt.ToLowerCaseColumnName()].Value);
                        var cstonewt = Convert.ToDecimal(row.Cells[_columncstonewt.ToLowerCaseColumnName()].Value);
                        if ((grwt - cstonewt) <= 0)
                        {
                            AllErrors.Add("ColorStoneWeight", "Invalid Total ColorStone Weight.");
                        }
                    }
                }
            }

            if (AllErrors.Count > 0)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return false;
            }

            itemDetail.ItemDescription = row.GetCellValue(_columntype);
            itemDetail.CertificateNumber = row.GetCellValue(_columncerno);
            itemDetail.DesignCode = row.GetCellValue(_columndesignno);
            itemDetail.ItemCategory = ItemCategory.ToString();
            itemDetail.TotalWeight = Convert.ToDecimal(row.GetCellValue(_columngrwt, true));
            itemDetail.StampingCharges = Convert.ToDecimal(row.GetCellValue(_columnstamp, true));
            itemDetail.LabourCharges = Convert.ToDecimal(row.GetCellValue(_columnlabr, true));

            row.GetCellValue(_columnmetaltype);

            itemDetail.MetalDetail = new MetalDetail
                {
                    MetalKT = row.GetCellValue(_columnmetaltype),
                    MetalNetAmount = Convert.ToDecimal(row.GetCellValue(_columngamt)),
                    MetalNetWt = Convert.ToDecimal(row.GetCellValue(_columnntwt)),
                    MetalType = row.GetCellValue(_columnmetaltype)
                };

            if (JewelHasStone)
            {
                var stoneAmount = 0M;
                if (IsStoneMode)
                {
                    itemDetail.CertificateCharges = Convert.ToDecimal(row.GetCellValue(_columncert));
                    // I am unknown
                    Func<List<StoneMetaDetail>> getMetaData = () => (from DataGridViewRow gridRow in mapGrid.Rows
                                                                     where
                                                                         gridRow.ValidateDependentProperties(_columnavrdia) &&
                                                                         gridRow.ValidateDependentProperties(_columndiapr)
                                                                     select new StoneMetaDetail
                                                                     {
                                                                         StoneSieveSz = gridRow.GetCellValue(_columnsievsz),
                                                                         StoneWt = Convert.ToDecimal(gridRow.GetCellValue(_columndiawtdetails)),
                                                                         StonePcs = Convert.ToInt32(gridRow.GetCellValue(_columndiapcsdetails)),
                                                                         StoneValue = Convert.ToDecimal(gridRow.GetCellValue(_columndiaval))
                                                                     }).ToList();

                    var detail = new StoneDetail
                        {
                            StoneType = row.GetCellValue(_columnstonetype),
                            StoneNetWt = Convert.ToDecimal(row.GetCellValue(_columndiawt)),
                            TotalStonePcs = Convert.ToInt32(row.GetCellValue(_columndiapcs)),
                            StoneChart = new StoneChart
                                {
                                    StoneMetaDetailList = getMetaData.Invoke()
                                }
                        };

                    stoneAmount = detail.StoneChart.StoneMetaDetailList.Sum(x => x.StoneValue);
                    detail.StoneNetAmount = stoneAmount;
                    itemDetail.StoneDetail = detail;
                }
                if (IsColorStoneMode)
                {
                    itemDetail.ColorStoneDetail = new ColorStoneDetail
                    {
                        ColorStoneType = row.GetCellValue(_columncsstonetype),
                        ColorStoneNetWt = Convert.ToDecimal(row.GetCellValue(_columncstonewt)),
                        ColorStoneNetAmount = Convert.ToDecimal(row.GetCellValue(_columndiavalsum)) - stoneAmount,
                        ColorTotalStonePcs = Convert.ToInt32(row.GetCellValue(_columncstonepcs))
                    };
                }
            }

            return true;
        }
        #endregion
    }
}
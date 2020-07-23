using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JetCoders.Shared;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmLooseDiamonds :
#if ENABLE_RUNTIMEMODE
 frmNavigableForm<LooseDiamondTransaction>,
#elif ENABLE_DESIGNMODE
 frmDataEntry,
#endif
 INavigable
    {
        private readonly ISupplierService _supplierService;
        private readonly ILooseDiamondService _looseDiamondService;
        private readonly IConfigurationService _iconfigurationService;

        private const string _columnSrNo = "No";
        private const string _columnszsize = "SEV.SZ";
        private const string _columndiawt = "DIAMONDWEIGHT";
        private const string _columnamount = "AMOUNT";

        public frmLooseDiamonds()
        {
            InitializeComponent();
        }

        public frmLooseDiamonds(ISupplierService supplierService, ILooseDiamondService looseDiamondService, IConfigurationService iconfigurationService)
            : this()
        {
            _supplierService = supplierService;
            _looseDiamondService = looseDiamondService;
            _iconfigurationService = iconfigurationService;

            BindForm();
        }

        private void BindForm()
        {
            #region Events
            dgvJewel.EditingControlShowing += CostingGridEditingControlShowing;
            dgvJewel.CellEndEdit += OnCostingFormatCellEndEdit;
            dgvJewel.CellValidating += OnCostingFormatCellValidating;
            dgvJewel.CellEnter += OnCostingFormatCellEnter;
            #endregion

            btnSave.Enabled = false;

            cboParty.DataSource = _supplierService.GetActiveSuppliers();
            cboType.DataSource = _iconfigurationService.LooseDiamondType();
            dtLooseDiamonds.Value = DateTime.Now;

            QueryableItems = _looseDiamondService.GetLooseDiamonds();
            ConfigDataGridView(dgvJewel);
            
            var diamondInfo = _looseDiamondService.GetLooseDiamonds().FirstOrDefault();

            if (diamondInfo == null)
                return;

            if (QueryableItems != null)
            {
                BindValues(CurrentItem.Entity);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (base.IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }
            BindForm();
            MessageBox.Show(Resources.frmLooseDiamonds_btnSave_Click_Record_saved_);
        }

        public override void ToolStripItems_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Add":
                    {
                        ClearFields();
                        MdiMode = FormMode.Add;
                        
                        break;
                    }
                case "Edit":
                    {
                        MdiMode = FormMode.Edit;
                        
                        break;
                    }
                case "Refresh":
                    {
                        
                        MdiMode = FormMode.Normal;
                        BindForm();
                        break;
                    }
            }

            MdiAction();
            base.ToolStripItems_Clicked(sender, e);
        }


        private void ClearFields()
        {
            cboParty.SelectedIndex = 0;
            cboType.SelectedIndex = 0;
            txtQuality.Text = "";
            dtLooseDiamonds.Value = DateTime.Today;
            dgvJewel.Rows.Clear();
        }

        #region INavigable

        public FormMode MdiMode { get; set; }

        public bool HasNext
        {
            get { return CurrentItem.HasNextRecord; }
        }

        public bool HasPrev
        {
            get { return CurrentItem.HasPreviousRecord; }
        }

        #endregion
        public override void BindValues(LooseDiamondTransaction looseDiamond)
        {
            if (looseDiamond == null)
                return;
            dtLooseDiamonds.Value = looseDiamond.TransactionDate;
            //cboParty.Text = looseDiamond.TransactionPartyRef;

            cboType.Text = looseDiamond.LooseDiamondType;
            txtQuality.Text = looseDiamond.Quality;
        }


        public void ConfigDataGridView(DataGridView mapGrid)
        {
            mapGrid.Columns.Add(GetDescriptionColumn(_columnSrNo, true));

            mapGrid.Columns.Add(GetListColumn(_columnszsize, _iconfigurationService.LooseDiamondType().ToList()));

            mapGrid.Columns.Add(GetDescriptionColumn(_columndiawt, false));
            mapGrid.Columns.Add(GetDescriptionColumn(_columnamount, false));
        }

        private DataGridViewTextBoxColumn GetDescriptionColumn(string column, bool isReadlyOnly)
        {
            var columnForDescription = new DataGridViewTextBoxColumn
            {
                Name = column.ToLowerCaseColumnName(),
                HeaderText = column,
                ReadOnly = isReadlyOnly,
                Width = 100
            };

            if (isReadlyOnly)
            {
                columnForDescription.Width = 0;
                columnForDescription.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightGray };
            }
                
            columnForDescription.SortMode = DataGridViewColumnSortMode.NotSortable;

            return columnForDescription;
        }


        private DataGridViewComboBoxColumn GetListColumn(string column, object dataSource)
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

        void AddrecordToGrid(DataGridView mapGrid, LooseDiamondTransaction data = null)
        {
            if (data == null)
            {
                mapGrid.Rows.Add(0, _iconfigurationService.LooseDiamondType(),
                            0.0, 0.0);

                return;
            }

            mapGrid.Rows.Add(data.LooseDiamondTransactionId, data.LooseDiamondType, data.DiamondWeight, data.Amount);
        }

        #region GridviewUtiliy
        private delegate void SetColumnAndRowOnGrid(DataGridView grid, int i, int o);

        private bool SetNextTabableCell(DataGridView grid, int nextColumn, int nextRow)
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

        private void SetNextTabableControl()
        {
            SelectNextControl(this, true, true, true, true);
        }

        void OnCostingFormatCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvJewel.Rows[e.RowIndex].ErrorText = String.Empty;
            errorProvider.Clear();

            foreach (DataGridViewRow row in dgvJewel.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style = cell.ReadOnly ? new DataGridViewCellStyle { BackColor = Color.LightGray } : new DataGridViewCellStyle { BackColor = Color.White };
                }
            }
        }

        void OnCostingFormatCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvJewel.Columns[e.ColumnIndex].Name == _columndiawt.ToLowerCaseColumnName() ||
                dgvJewel.Columns[e.ColumnIndex].Name == _columnamount.ToLowerCaseColumnName())
            {
                decimal val;
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false && Decimal.TryParse(e.FormattedValue.ToString(), out val) == false)
                {
                    errorProvider.SetError(dgvJewel, "Invalid amount field.");
                    e.Cancel = true;
                }
            }
            else if (dgvJewel.Columns[e.ColumnIndex].Name == _columnszsize.ToLowerCaseColumnName())
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()) == false)
                {
                    errorProvider.SetError(dgvJewel, "Please select seive size amount field.");
                    e.Cancel = true;
                }
            }
        }

        void OnCostingFormatCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView)
            {
                var grid = (DataGridView)sender;

                if (grid.CurrentRow != null && grid.CurrentRow.Index > 0)
                {
                    if (grid.CurrentCell.OwningColumn.Name != _columnamount.ToLowerCaseColumnName())
                    {
                        var dataGridViewColumn = grid.Columns[_columnamount.ToLowerCaseColumnName()];
                        if (dataGridViewColumn != null)
                        {
                            var colindex = dataGridViewColumn.Index;
                            if (!SetNextTabableCell(grid, colindex, e.RowIndex))
                            {
                                SetNextTabableControl();
                            }
                        }
                    }
                }

                if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
                {
                    //this cell is readonly, find the next tabable cell
                    if (!SetNextTabableCell(grid, e.ColumnIndex, e.RowIndex))
                    {
                        //or tab to the next control
                        SetNextTabableControl();
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("this method can only be applied to controls of type DataGridView");
            }
        }

        void CostingGridEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var grid = (sender as DataGridView);

            if (grid == null)
                return;

            if (e.Control is DataGridViewTextBoxEditingControl)
                if (grid.CurrentCell.OwningColumn.Name == _columnamount.ToLowerCaseColumnName())
                    (e.Control as DataGridViewTextBoxEditingControl).KeyDown += DIAPCS_ENTERKEY;

            if (grid.CurrentRow != null && grid.CurrentRow.Index >= 1)
                return;

            e.Control.LostFocus += null;
        }

        void DIAPCS_ENTERKEY(object sender, KeyEventArgs e)
        {
            if (sender is DataGridViewTextBoxEditingControl)
            {
                var grid = dgvJewel;
                if ((grid.CurrentCell.RowIndex + 1) == grid.RowCount)
                {
                    AddrecordToGrid(dgvJewel);
                }
            }
        }

        #endregion
    }
}
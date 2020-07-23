using System;
using System.Linq;
using System.Windows.Forms;
using Connections;
using JetCoders.Forms.UI.Input;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmFinancialYear :
#if ENABLE_RUNTIMEMODE
 frmNavigableForm<FinancialYearMaster>,
#elif ENABLE_DESIGNMODE
 frmDataEntry,
#endif
 INavigable
    {
        private readonly IConfigurationService _configurationService;

        public frmFinancialYear()
        {
            InitializeComponent();
        }

        public frmFinancialYear(IConfigurationService configurationService)
            : this()
        {
            _configurationService = configurationService;
            BindUserForm();
        }

        void BindUserForm()
        {
            ClearFields();
            btnSave.Enabled = false;
            grpFinYear.Enabled = false;
            chkActive.Enabled = false;
            chkActive.Checked = true;
            chkcancelled.Enabled = chkActive.Checked = false;
            MDIForm.autoComplete.Enabled = true;
            MDIForm.autoComplete.Items.Clear();

            QueryableItems = _configurationService.GetAllFinancialYears().OrderBy(x => x.FinancialYearMasterId);

            foreach (var obj in QueryableItems)
                MDIForm.autoComplete.Items.Add(new AutoCompleteEntry(obj.YearCode));

            if (QueryableItems != null)
                BindValues(CurrentItem.Entity);
        }

        void ClearFields()
        {
            txtYearCode.Text = String.Empty;
            dtFrom.Value = DateTime.Now.Date;
            dtTo.Value = DateTime.Now.Date;
        }

        public override void ToolStripItems_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Add":
                    {
                        ClearFields();
                        MdiMode = FormMode.Add;
                        grpFinYear.Enabled = chkActive.Enabled  = true;
                        
                        chkActive.Enabled = true;
                        break;
                    }
                case "Edit":
                    {
                        MdiMode = FormMode.Edit;
                        grpFinYear.Enabled = false;
                        

                        chkActive.Enabled = true;
                        chkcancelled.Enabled = true;
                        break;
                    }
                case "Refresh":
                    {
                        
                        MdiMode = FormMode.Normal;
                        BindUserForm();
                        break;
                    }
                case "Search":
                    {
                        //var search = MDIForm.autoComplete.Text;
                        //if (search.IsEmpty())
                        //    return;

                        //var record = QueryableItems.ToList().FirstOrDefault(x => x.YearCode == search);
                        //MDIForm.autoComplete.Text = String.Empty;
                        //if (record == null)
                        //{
                        //    MessageBox.Show("Records not found !", Constants.ALERTMESSAGEHEADER);
                        //    return;
                        //}

                        //var index = QueryableItems.IndexOf(record) + 1;
                        //var current = new PagedItem<FinancialYearMaster>(QueryableItems.AsQueryable(), index);
                        //CurrentItem = current;
                        //BindValues(current.FirstOrDefault());
                        break;
                    }
            }

            MdiAction();
            base.ToolStripItems_Clicked(sender, e);
        }

        override public void BindValues(FinancialYearMaster financialYearMaster)
        {
            if (financialYearMaster == null)
                return;

            var financialYearitem = financialYearMaster;
            txtYearCode.Text = financialYearitem.YearCode;
            dtFrom.Value = financialYearitem.DateFrom;
            dtTo.Value = financialYearitem.DateTo;
            chkActive.Checked = financialYearMaster.IsActive;
            chkcancelled.Checked = financialYearMaster.IsCancelled;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            if (chkcancelled.Checked)
            {
                if (MessageBox.Show(Resources.frmFinancialYear_btnSave_Click_, Constants.ALERTMESSAGEHEADER, MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            var request = new FinancialYearRequest {FinancialYearMaster = CurrentItem.Entity};

            if (MdiMode == FormMode.Add)
            {
                request.FinancialYearMaster = new FinancialYearMaster
                {
                    YearCode = txtYearCode.Text,
                    DateFrom = dtFrom.Value,
                    DateTo = dtTo.Value
                };
            }

            request.FinancialYearMaster.IsActive = chkActive.Checked;
            request.FinancialYearMaster.IsCancelled = chkcancelled.Checked;

            var response = _configurationService.CreateFinancialYear(request);
            if (false == response.IsValid)
            {
                MessageBox.Show(response.AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }
            grpFinYear.Enabled = chkActive.Enabled = chkcancelled.Enabled = btnSave.Enabled = false;
            

            MessageBox.Show(Resources.frmFinancialYear_btnSave_Click_Record_saved_);
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            dtTo.Value = dtFrom.Value.AddYears(1).AddDays(-1);
        }
    }
}

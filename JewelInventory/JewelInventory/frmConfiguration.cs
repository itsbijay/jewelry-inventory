using System;
using System.Windows.Forms;
using Connections;
using JetCoders.Forms.UI.Input;
using System.Linq;

// Metal Category can be added 
// Jewel Stype can be added
// Add Daimond type others 
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmConfiguration :
#if ENABLE_RUNTIMEMODE
 frmNavigableForm<ConfigurationMaster>,
#elif ENABLE_DESIGNMODE
 frmDataEntry,
#endif
 INavigable
    {
        private readonly IConfigurationService _configurationService;

        public frmConfiguration()
        {
            InitializeComponent();
        }

        public frmConfiguration(IConfigurationService configurationService)
            : this()
        {
            _configurationService = configurationService;
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            BindConfigForm();
        }

        public void ClearFields()
        {
            txtPerticulars.Text = String.Empty;
            txtValue.Text = String.Empty;
            cboCategory.Text = String.Empty;
            txtRemarks.Text = String.Empty;
        }

        public override void ToolStripItems_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Add":
                    {
                        ClearFields();
                        MdiMode = FormMode.Add;
                        groupBoxConfiguration.Enabled = true;
                        chkDisabled.Enabled = true;
                        break;
                    }
                case "Edit":
                    {
                        MdiMode = FormMode.Edit;
                        groupBoxConfiguration.Enabled = false;
                        chkDisabled.Enabled = true;
                        break;
                    }
                case "Refresh":
                    {
                        
                        MdiMode = FormMode.Normal;
                        BindConfigForm();
                        break;
                    }
                case "Search":
                    {
                        //var search = MDIForm.autoComplete.Text;
                        //if (search.IsEmpty())
                        //    return;

                        //var configuration = QueryableItems.ToList().FirstOrDefault(x => (x.ProductCategory.ToString() + ", " + x.ConfigurationValue) == search);
                        //MDIForm.autoComplete.Text = String.Empty;
                        //if (configuration == null)
                        //{
                        //    MessageBox.Show("Records not found !", Constants.ALERTMESSAGEHEADER);
                        //    return;
                        //}

                        //var index = QueryableItems.IndexOf(configuration) + 1;
                        //var current = new PagedItem<ConfigurationMaster>(QueryableItems.AsQueryable(), index);
                        //CurrentItem = current;
                        //BindValues(current.FirstOrDefault());
                        break;
                    }
            }

            MdiAction();
            base.ToolStripItems_Clicked(sender, e);
        }

        private void BindConfigForm()
        {
            ClearFields();

            btnSave.Enabled = false;
            groupBoxConfiguration.Enabled = false;

            cboCategory.DataSource = Enum.GetValues(typeof(ProductCategory));

            chkDisabled.Checked = true;
            chkDisabled.Enabled = false;

            QueryableItems = _configurationService.GetAllConfigurations(false).OrderBy(x=>x.ConfigurationId);

            if (QueryableItems != null)
            {
                BindValues(CurrentItem.Entity);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            if (cboCategory.SelectedValue.ToString() == ProductCategory.NotSet.ToString())
            {
                MessageBox.Show(Resources.frmConfiguration_btnSave_Click_Please_select_costing_category, Constants.ALERTMESSAGEHEADER);
                return;
            }

            var request = new ConfigMasterRequest {ConfigurationMaster = CurrentItem.Entity};
            if (MdiMode == FormMode.Add)
            {
                request.ConfigurationMaster = new ConfigurationMaster
                {
                    Particulars = txtPerticulars.Text,
                    ConfigurationValue = txtValue.Text,
                    Remarks = txtRemarks.Text,
                    ProductCategory_Enum = Convert.ToInt16(cboCategory.SelectedValue)
                };
            }

            request.ConfigurationMaster.JewelItemCategory = rdoStockTpeAlloy.Checked ? JewelItemCategory.Alloy :
                (rdoStockTpeGold.Checked ? JewelItemCategory.Gold : (rdoStockTpeSilver.Checked ? JewelItemCategory.Silver : JewelItemCategory.NotSet));

            request.ConfigurationMaster.Active = chkDisabled.Checked;
            

            var response = _configurationService.SaveConfiguration(request);

            if (false == response.IsValid)
            {
                MessageBox.Show(response.AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            MdiMode = FormMode.Normal;
            BindConfigForm();
        }

        override public void BindValues(ConfigurationMaster config)
        {
            if (config == null)
                return;

            var configuration = config;
            cboCategory.Text = configuration.ProductCategory.ToString();
            txtPerticulars.Text = configuration.Particulars;
            txtValue.Text = configuration.ConfigurationValue;
            rdoStockTpeAlloy.Checked = configuration.JewelItemCategory == JewelItemCategory.Alloy;
            rdoStockTpeGold.Checked = configuration.JewelItemCategory == JewelItemCategory.Gold;
            rdoStockTpeSilver.Checked = configuration.JewelItemCategory == JewelItemCategory.Silver;

            txtRemarks.Text = configuration.Remarks ?? String.Empty;
            chkDisabled.Checked = configuration.Active;
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
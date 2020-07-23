using System;
using System.Linq;
using System.Windows.Forms;
using Connections;
using System.Text.RegularExpressions;
using JetCoders.Forms.UI.Input;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmCustomerDataEntry :
#if ENABLE_RUNTIMEMODE
 frmNavigableForm<Customer>,
#elif ENABLE_DESIGNMODE
			frmDataEntry,
#endif
 INavigable
    {
        private readonly ICustomerService _customerService;

        public frmCustomerDataEntry()
        {
            InitializeComponent();
        }

        public frmCustomerDataEntry(ICustomerService customerService)
            : this()
        {
            _customerService = customerService;
        }

        private void frmCustomerDataEntry_Load(object sender, EventArgs e)
        {
            BindCustomerForm();
        }

        void BindCustomerForm()
        {
            ClearFields();

            dtDob.MaxDate = DateTime.Today;
            btnSave.Enabled = false;
            groupBox.Enabled = false;
            MDIForm.autoComplete.Enabled = true;
            MDIForm.autoComplete.Items.Clear();

            QueryableItems = _customerService.GetAllCustomers().OrderBy(x=>x.CustomersId);

            foreach (var obj in QueryableItems)
            {
                MDIForm.autoComplete.Items.Add(new AutoCompleteEntry(obj.CompanyName, obj.CustomersCode, obj.Properties.FullName(), obj.Properties.FirstName, obj.Properties.LastName));
            }

            cboState.DataSource = LocalStore.States.GetStates();
            cboCountry.DataSource = LocalStore.Countries.GetCountries();

            if (QueryableItems != null)
            {
                BindValues(CurrentItem.Entity);
            }
        }

        override public void BindValues(Customer customer)
        {
            if (customer == null)
                return;

            txtSupplierCode.Text = customer.CustomersCode;
            txtComapnyName.Text = customer.CompanyName;
            txtVatNumber.Text = customer.VATNumber;
            txtContactName.Text = customer.ContactName;
            txtFname.Text = customer.Properties.FirstName;
            txtMname.Text = customer.Properties.MiddleName;
            txtLname.Text = customer.Properties.LastName;
            txtCSTNumber.Text = customer.CSTNumber;
            txtPANWNumber.Text = customer.PANNumber;
            txtAddressL1.Text = customer.Address.AddressLine1;
            txtAddressL2.Text = customer.Address.AddressLine1;
            txtCity.Text = customer.Address.City;
            cboState.Text = customer.Address.State;
            cboCountry.Text = customer.Address.Country;
            txtbankNumber.Text = customer.Properties.BankName;
            txtacNumber.Text = customer.Properties.AccountNumber;
            txtPostalCode.Text = customer.Address.PostalCode;
            txtPhone.Text = customer.Address.Phone;
            txtFax.Text = customer.Address.Fax;
            txtWebsite.Text = customer.Properties.Website;

            txtEmail1.Text = customer.Properties.Email1;
            txtEmail2.Text = customer.Properties.Email2;
            dtDob.Value = customer.Properties.DOB;
            txtNote.Text = customer.Properties.Note;

            if (customer.CustomesStatus == CustomesStatus.Active)
            {
                rdoActive.Checked = true;
            }
            else
            {
                rdoInActive.Checked = true;
            }
        }

        public void ClearFields()
        {
            txtSupplierCode.Text = String.Empty;
            txtComapnyName.Text = String.Empty;
            txtVatNumber.Text = String.Empty;
            txtPANWNumber.Text = string.Empty;
            txtCSTNumber.Text = String.Empty;
            txtContactName.Text = String.Empty;
            txtFname.Text = String.Empty;
            txtMname.Text = String.Empty;
            txtLname.Text = String.Empty;
            txtAddressL1.Text = String.Empty;
            txtAddressL2.Text = String.Empty;
            txtCity.Text = String.Empty;
            cboState.SelectedIndex = -1;
            cboCountry.SelectedIndex = -1;
            txtPostalCode.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtFax.Text = String.Empty;
            txtWebsite.Text = String.Empty;
            txtbankNumber.Text = String.Empty;
            txtacNumber.Text = String.Empty;
            txtEmail1.Text = String.Empty;
            txtEmail2.Text = String.Empty;
            dtDob.Value = DateTime.Now.AddYears(-18);
            txtNote.Text = String.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid == false)
            {
                MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            if (txtEmail1.Text != String.Empty && !Regex.IsMatch(txtEmail1.Text, Constants.EMAILPATTERN))
            {
                txtEmail1.Focus();
                MessageBox.Show(Resources.frmCustomerDataEntry_btnSave_Click_Please_Enter_Valid_Email_Address_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            if (txtEmail2.Text != String.Empty && !Regex.IsMatch(txtEmail2.Text, Constants.EMAILPATTERN))
            {
                txtEmail2.Focus();
                MessageBox.Show(Resources.frmCustomerDataEntry_btnSave_Click_Please_Enter_Valid_Email_Address_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            var request = new CustomerRequest {Customer = CurrentItem.Entity};

            if (MdiMode == FormMode.Add)
            {
                request.Customer = new Customer {Address = new Address()};
            }

            request.Customer.Address.AddressLine1 = txtAddressL1.Text;
            request.Customer.Address.AddressLine2 = txtAddressL2.Text;
            request.Customer.Address.City = txtCity.Text;
            request.Customer.Address.Country = cboCountry.Text;
            request.Customer.Address.Fax = txtFax.Text;
            request.Customer.Address.Phone = txtPhone.Text;
            request.Customer.Address.PostalCode = txtPostalCode.Text;
            request.Customer.Address.State = cboState.Text;

            request.Customer.CompanyName = txtComapnyName.Text;
            request.Customer.VATNumber = txtVatNumber.Text;
            request.Customer.CSTNumber = txtCSTNumber.Text;
            request.Customer.PANNumber = txtPANWNumber.Text;
            request.Customer.ContactName = txtContactName.Text;
            request.Customer.CustomesStatus = rdoActive.Checked ? CustomesStatus.Active : CustomesStatus.InActive;

            request.Customer.Properties = new CustomerProperties
            {
                AccountNumber = txtacNumber.Text,
                BankName = txtbankNumber.Text,
                DOB = dtDob.Value,
                Email1 = txtEmail1.Text,
                Email2 = txtEmail2.Text,
                FirstName = txtFname.Text,
                LastName = txtLname.Text,
                MiddleName = txtMname.Text,
                Note = txtNote.Text,
                Website = txtWebsite.Text
            };

            var customerReponse = _customerService.SaveCustomer(request);

            if (false == customerReponse.IsValid)
            {
                MessageBox.Show(customerReponse.AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            groupBox.Enabled = groupBox1.Enabled = groupBox2.Enabled = btnSave.Enabled = false;
            MessageBox.Show(Resources.frmCustomerDataEntry_btnSave_Click_Record_saved_);
        }

        public override void ToolStripItems_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Add":
                    {
                        ClearFields();
                        MdiMode = FormMode.Add;
                        groupBox.Enabled = true;
                        
                        break;
                    }
                case "Edit":
                    {
                        MdiMode = FormMode.Edit;
                        groupBox.Enabled = true;
                        
                        break;
                    }
                case "Refresh":
                    {
                        
                        MdiMode = FormMode.Normal;
                        BindCustomerForm();
                        break;
                    }
                case "Search":
                    {
                        //var search = MDIForm.autoComplete.Text;
                        //if (search.IsEmpty())
                        //    return;

                        //var user = QueryableItems.ToList().FirstOrDefault(x => x.CompanyName == search);
                        //MDIForm.autoComplete.Text = String.Empty;
                        //if (user == null)
                        //{
                        //    MessageBox.Show("Records not found !", Constants.ALERTMESSAGEHEADER);
                        //    return;
                        //}

                        //var index = QueryableItems.IndexOf(user) + 1;
                        //var current = new PagedItem<Customer>(QueryableItems.AsQueryable(), index);
                        //CurrentItem = current;
                        //BindValues(current.FirstOrDefault());

                        break;
                    }
            }

            MdiAction();
            base.ToolStripItems_Clicked(sender, e);
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

        private void txtPostalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

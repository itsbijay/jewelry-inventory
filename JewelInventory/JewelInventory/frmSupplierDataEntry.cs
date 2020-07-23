using System;
using System.Windows.Forms;
using Connections;
using JetCoders.Forms.UI.Input;
using System.Linq;
using System.Text.RegularExpressions;
using JewelInventory.Properties;


namespace JewelInventory
{
	public partial class frmSupplierDataEntry :
#if ENABLE_RUNTIMEMODE
	 frmNavigableForm<Supplier>,
#elif ENABLE_DESIGNMODE
		frmDataEntry,
#endif
 INavigable
	{
		private readonly ISupplierService _supplierService;

		public frmSupplierDataEntry()
		{
			InitializeComponent();
		}

		public frmSupplierDataEntry(ISupplierService supplierService)
			: this()
		{
			_supplierService = supplierService;
		}

		private void frmSupplierDataEntry_Load(object sender, EventArgs e)
		{
			BindSupplierForm();
		}

		void BindSupplierForm()
		{
			ClearFields();

            dtDob.MaxDate = DateTime.Today;
			btnSave.Enabled = false;
			groupBox.Enabled = false;
			MDIForm.autoComplete.Enabled = true;
			MDIForm.autoComplete.Items.Clear();

			QueryableItems = _supplierService.GetAllSuppliers().OrderBy(x=>x.SupplierId);

			foreach (var obj in QueryableItems)
			{
				MDIForm.autoComplete.Items.Add(new AutoCompleteEntry(obj.CompanyName, obj.SupplierCode, obj.Properties.FullName(), obj.Properties.FirstName, obj.Properties.LastName));
			}

			cboState.DataSource = LocalStore.States.GetStates();
            cboCountry.DataSource = LocalStore.Countries.GetCountries();

            if (QueryableItems != null)
            {
                BindValues(CurrentItem.Entity);
            }
		}

		override public void BindValues(Supplier supplier)
		{
			if (supplier == null)
				return;

			var bindSupplier = supplier;
			txtSupplierCode.Text = supplier.SupplierCode;
			txtComapnyName.Text = supplier.CompanyName;
			txtVatNumber.Text = supplier.VATNumber;
            txtCSTNumber.Text = supplier.CSTNumber;
            txtPANWNumber.Text = supplier.PANNumber;
			txtContactName.Text = supplier.ContactName;
			txtFname.Text = supplier.Properties.FirstName;
			txtMname.Text = supplier.Properties.MiddleName;
			txtLname.Text = supplier.Properties.LastName;
			txtAddressL1.Text = supplier.Address.AddressLine1;
			txtAddressL2.Text = supplier.Address.AddressLine1;
			txtCity.Text = supplier.Address.City;
			cboState.Text = supplier.Address.State;
			cboCountry.Text = supplier.Address.Country;
			txtPostalCode.Text = supplier.Address.PostalCode;
			txtPhone.Text = supplier.Address.Phone;
			txtFax.Text = supplier.Address.Fax;
			txtWebsite.Text = supplier.Properties.Website;
            txtbankNumber.Text = supplier.Properties.BankName;
            txtacNumber.Text = supplier.Properties.AccountNumber;
            txtEmail1.Text = supplier.Properties.Email1;
			txtEmail2.Text = supplier.Properties.Email2;
            dtDob.Value = supplier.Properties.DOB;
			txtNote.Text = supplier.Properties.Note;
			if (bindSupplier.SupplierStatus == SupplierStatus.Active)
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
            txtCSTNumber.Text = String.Empty;
            txtPANWNumber.Text = String.Empty;
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
            txtacNumber.Text = String.Empty;
            txtbankNumber.Text = String.Empty;
			txtEmail1.Text = String.Empty;
			txtEmail2.Text = String.Empty;
            dtDob.Value = DateTime.Now.AddYears(-18);
			txtNote.Text = String.Empty;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (base.IsValid == false)
			{
				MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
				return;
			}

			if (txtEmail1.Text != String.Empty && !Regex.IsMatch(txtEmail1.Text, Constants.EMAILPATTERN))
			{
				txtEmail1.Focus();
				MessageBox.Show(Resources.frmSupplierDataEntry_btnSave_Click_Please_Enter_Valid_Email_Address_, Constants.ALERTMESSAGEHEADER);
				return;
			}

			if (txtEmail2.Text != String.Empty && !Regex.IsMatch(txtEmail2.Text, Constants.EMAILPATTERN))
			{
				txtEmail2.Focus();
				MessageBox.Show(Resources.frmSupplierDataEntry_btnSave_Click_Please_Enter_Valid_Email_Address_, Constants.ALERTMESSAGEHEADER);
				return;
			}

			var request = new SupplierRequest {Supplier = CurrentItem.Entity};

		    if (MdiMode == FormMode.Add)
			{
				request.Supplier = new Supplier {Address = new Address()};
			}
            request.Supplier.CSTNumber = txtCSTNumber.Text;
            request.Supplier.PANNumber = txtPANWNumber.Text;
			request.Supplier.Address.AddressLine1 = txtAddressL1.Text;
			request.Supplier.Address.AddressLine2 = txtAddressL2.Text;
			request.Supplier.Address.City = txtCity.Text;
			request.Supplier.Address.Country = cboCountry.Text;
			request.Supplier.Address.Fax = txtFax.Text;
			request.Supplier.Address.Phone = txtPhone.Text;
			request.Supplier.Address.PostalCode = txtPostalCode.Text;
			request.Supplier.Address.State = cboState.Text;
			
			request.Supplier.CompanyName = txtComapnyName.Text;
			request.Supplier.ContactName = txtContactName.Text;
			request.Supplier.SupplierStatus = rdoActive.Checked ? SupplierStatus.Active : SupplierStatus.InActive;

			request.Supplier.Properties = new SupplierProperties
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
			request.Supplier.VATNumber = txtVatNumber.Text;

			var supplierResponse = _supplierService.SaveSupplier(request);

			if (false == supplierResponse.IsValid)
			{
				MessageBox.Show(supplierResponse.AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
				return;
			}

            groupBox.Enabled = groupBox1.Enabled = groupBox2.Enabled = btnSave.Enabled = false;
            MessageBox.Show(Resources.frmSupplierDataEntry_btnSave_Click_Record_saved_);
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
						BindSupplierForm();
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
                        //var current = new PagedItem<Supplier>(QueryableItems.AsQueryable(), index);
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
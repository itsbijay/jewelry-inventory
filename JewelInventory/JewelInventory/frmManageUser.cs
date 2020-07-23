using System;
using System.Windows.Forms;
using Connections;
using System.Text.RegularExpressions;
using System.Linq;
using JetCoders.Forms.UI.Input;
using JewelInventory.Properties;

namespace JewelInventory
{
    public partial class frmManageUser :
#if ENABLE_RUNTIMEMODE
 frmNavigableForm<User>,
#elif ENABLE_DESIGNMODE
	 frmDataEntry,
#endif
 INavigable
    {
        private readonly IUserService _userService;

        public frmManageUser()
        {
            InitializeComponent();
            MdiMode = FormMode.Normal;
        }

        public frmManageUser(IUserService userService)
            : this()
        {
            _userService = userService;
        }

        private void frmManageUser_Load(object sender, EventArgs e)
        {
            BindUserForm();
        }

        void BindUserForm()
        {
            ClearFields();
            dateTimePicker1.MaxDate = DateTime.Today;
            btnSave.Enabled = false;
            groupBoxLoginInfo.Enabled = false;
            groupBoxUserInfo.Enabled = false;
            MDIForm.autoComplete.Enabled = true;
            MDIForm.autoComplete.Items.Clear();

            QueryableItems = _userService.GetAllUser().OrderBy(x => x.UserId);

            foreach (var obj in QueryableItems)
            {
                MDIForm.autoComplete.Items.Add(new AutoCompleteEntry(obj.Properties.FullName(), obj.UserId.ToString(), obj.Email, obj.Properties.FirstName, obj.Properties.LastName));
            }

            cbostate.DataSource = LocalStore.States.GetStates();
            cboCountry.DataSource = LocalStore.Countries.GetCountries();

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

            if (!Regex.IsMatch(email_textBox.Text, Constants.EMAILPATTERN))
            {
                email_textBox.Focus();
                MessageBox.Show(Resources.frmManageUser_btnSave_Click_Please_Enter_Valid_Email_Address_, Constants.ALERTMESSAGEHEADER);
                return;
            }

            var request = new UserRequest {User = CurrentItem.Entity};

            switch (MdiMode)
            {
                case FormMode.Normal:
                    break;
                case FormMode.Add:
                    request.User = new User();
                    var userLoginInfo = new LoginInformation
                        {
                            AccessedBy = 1,
                            IsActive = true,
                            Username = username_textBox.Text,
                            Password = password_textBox.Text,
                            UserType = UserType.User,
                        };
                    request.User.LoginInformations = userLoginInfo;

                    request.User.Address = new Address();
                    break;
                case FormMode.Edit:
                    request.User.LoginInformations.Password = password_textBox.Text;
                    break;
            }

            request.User.Address.AddressLine1 = address1_textBox.Text;
            request.User.Address.AddressLine2 = address2_textBox.Text;
            request.User.Address.City = city_textBox.Text;
            request.User.Address.Country = cboCountry.Text;
            request.User.Address.Fax = fax_textBox.Text;
            request.User.Address.Phone = phone_textBox.Text;
            request.User.Address.PostalCode = postalcode_textBox.Text;
            request.User.Address.State = cbostate.Text;

            request.User.Properties = new UserProperties
                {
                    Email = email_textBox.Text,
                    FirstName = txtFname.Text,
                    LastName = txtLname.Text,
                    MiddleName = txtMname.Text
                };

            request.User.Email = email_textBox.Text;
            request.User.UserStatus = (radioButton1.Checked) ? UserStatus.Active : UserStatus.InActive;

            var addUserResponse = _userService.SaveUser(request);

            if (false == addUserResponse.IsValid)
            {
                MessageBox.Show(addUserResponse.AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
                return;
            }

            groupBoxLoginInfo.Enabled = groupBoxUserInfo.Enabled = btnSave.Enabled = false;
            MessageBox.Show(Resources.frmManageUser_btnSave_Click_Record_saved_);
        }

        public override void ToolStripItems_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Add":
                    {
                        ClearFields();
                        MdiMode = FormMode.Add;
                        groupBoxLoginInfo.Enabled = true;
                        groupBoxUserInfo.Enabled = true;
                        
                        break;
                    }
                case "Edit":
                    {
                        MdiMode = FormMode.Edit;
                        groupBoxLoginInfo.Enabled = true;

                        username_textBox.Enabled = false;

                        password_textBox.Enabled = LocalStore.CurrentUser.LoginInformations.UserType == UserType.SuperUser;

                        groupBoxUserInfo.Enabled = true;
                        
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

                        //var user = QueryableItems.ToList().FirstOrDefault(x => x.Properties.FullName() == search);
                        //MDIForm.autoComplete.Text = String.Empty;
                        //if (user == null)
                        //{
                        //    MessageBox.Show("Records not found !", Constants.ALERTMESSAGEHEADER);
                        //    return;
                        //}

                        //var index = QueryableItems.IndexOf(user) + 1;
                        //var current = new PagedItem<User>(QueryableItems.AsQueryable(), index);
                        //CurrentItem = current;
                        //BindValues(current.FirstOrDefault());

                        //MdiAction();
                        //base.ToolStripItems_Clicked(sender, e);

                        break;
                    }
            }

            MdiAction();
            base.ToolStripItems_Clicked(sender, e);
        }

        override public void BindValues(User user)
        {
            if (user == null)
                return;

            username_textBox.Text = user.LoginInformations.Username;
            password_textBox.Text = user.LoginInformations.Password;
            txtFname.Text = user.Properties.FirstName;
            txtLname.Text = user.Properties.LastName;
            txtMname.Text = user.Properties.MiddleName;
            address1_textBox.Text = user.Address.AddressLine1;
            address2_textBox.Text = user.Address.AddressLine2;
            city_textBox.Text = user.Address.City;
            cbostate.Text = user.Address.State;
            cboCountry.Text = user.Address.Country;
            postalcode_textBox.Text = user.Address.PostalCode;
            phone_textBox.Text = user.Address.Phone;
            fax_textBox.Text = user.Address.Fax;
            dateTimePicker1.Value = DateTime.Now.AddYears(-18);
            email_textBox.Text = user.Email;
            if (user.UserStatus == UserStatus.Active)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        public void ClearFields()
        {
            txtFname.Text = String.Empty;
            txtMname.Text = String.Empty;
            txtLname.Text = String.Empty;
            username_textBox.Text = String.Empty;
            password_textBox.Text = String.Empty;
            address1_textBox.Text = String.Empty;
            address2_textBox.Text = String.Empty;
            city_textBox.Text = String.Empty;
            cbostate.SelectedIndex = -1;
            cboCountry.SelectedIndex = -1;
            postalcode_textBox.Text = String.Empty;
            phone_textBox.Text = String.Empty;
            fax_textBox.Text = String.Empty;
            email_textBox.Text = String.Empty;
        }

        #region KeyEvents
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
        #endregion

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

        private void txtLname_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
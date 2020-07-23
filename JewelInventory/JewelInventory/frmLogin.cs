using System;
using System.Windows.Forms;
using Connections;
using JewelInventory.Properties;

namespace JewelInventory
{
	public partial class frmLogin : BaseFormControl
	{

		private readonly IUserService _userService;

		public frmLogin()
		{
			InitializeComponent();
		}

		public frmLogin(IUserService userService)
			: this()
		{
			_userService = userService;
		}

		private void btnLOGIN_Click(object sender, EventArgs e)
		{
			if (IsValid == false)
			{
				MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
				return;
			}

			var request = new UserLoginRequest
			    {
				UserName = txtUsername.Text,
				Password = txtPassword.Text
			};
			var user = _userService.AuthenticateUser(request);
			if (user != null)
			{
				LocalStore.CurrentUser = user;
				ShowManagedForm<frmMDIParent>(null);
				Hide();
				return;
			}
			MessageBox.Show(Resources.frmLogin_btnLOGIN_Click_Invalid_username_or_password, Constants.ALERTMESSAGEHEADER);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

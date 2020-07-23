using System;
using System.Linq;
using System.Windows.Forms;
using Connections;
using System.Data.SqlClient;
using JewelInventory.Properties;

namespace JewelInventory
{
	public partial class frmConnection : BaseFormControl
	{
		public bool StartUpFlag = false;
		readonly ConnectionServices _connectionProvider;
		private const String DbName = "Inventory";
		public frmConnection()
		{
			InitializeComponent();
			cboAuthType.Items.Add("Windows Authentication");
			cboAuthType.Items.Add("SQL Server Authentication");
			_connectionProvider = new ConnectionServices();
			cboAuthType.SelectedIndex = (int)AuthType.Windows;
		}

		public frmConnection(ConnectionServices connectionProvider)
			: this()
		{
			_connectionProvider = connectionProvider;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (IsValid == false)
			{
				MessageBox.Show(AllErrors.ErrorMessageString(), Constants.ALERTMESSAGEHEADER);
				return;
			}

			var request = new SqlConnectionStringBuilder {DataSource = txtServerName.Text, InitialCatalog = DbName};
		    bool authType = (cboAuthType.SelectedIndex == (Int16)AuthType.Windows);

			request.IntegratedSecurity = authType;
			if (authType == false)
			{
				request.UserID = txtUserName.Text;
				request.Password = txtPassword.Text;
			}
			string connectionString = _connectionProvider.CreateConnectionString(request);

			Cursor = Cursors.WaitCursor;
			if (_connectionProvider.CheckConnection(connectionString) == false)
			{
				var error = String.Format("Cannot connect to {0} \n \n Additional Information \n \n {1}", txtServerName.Text, _connectionProvider.AllErrors.FirstOrDefault());
				MessageBox.Show(error, Resources.frmConnection_btnConnect_Click_Connection_to_server_failed_);
				Cursor = Cursors.Default;
				return;
			}
			Cursor = Cursors.Default;
			CoreSettings.UpdateAppSettings("appSettings", Constants.SQLCONNECTIONSTRING, connectionString);
			MessageBox.Show(Resources.frmConnection_btnConnect_Click_Connection_to_server_succeeded__Please_restart_your_application_, Resources.frmConnection_btnConnect_Click_Connection_to_server_succeeded_);
			Cursor = Cursors.Default;
			Application.Exit();
		}

	    private void cboAuthType_SelectedIndexChanged(object sender, EventArgs e)
	    {
	        panel1.Enabled = cboAuthType.SelectedIndex == (Int16)AuthType.SqlServer;
	    }

	    private void btnCancel_Click(object sender, EventArgs e)
		{
			if (StartUpFlag)
				Application.Exit();

			Close();
		}

	}
}

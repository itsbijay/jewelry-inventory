using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Connections;
using CrystalDecisions.CrystalReports.Engine;

namespace JewelInventory
{
	public partial class frmMasterReport : BaseFormControl
	{
		private readonly IWinSettingProvider _iWinSettingProvider;
		private readonly ICustomerService _customerService;
		private readonly ISupplierService _supplierService;
		private readonly IUserService _userService;
		private readonly IConfigurationService _configurationService;
	    private readonly IDataSetProvider _firmDataSetService;

        public frmMasterReport(IWinSettingProvider iWinSettingProvider, ICustomerService customerService, ISupplierService supplierService, IUserService userService, IConfigurationService configurationService, IDataSetProvider firmDataSetService)
		{
			InitializeComponent();
			_iWinSettingProvider = iWinSettingProvider;
			_customerService = customerService;
			_supplierService = supplierService;
			_userService = userService;
			_configurationService = configurationService;
            _firmDataSetService = firmDataSetService;

			cboMasterReportType.DataSource = LocalStore.MasterReportItems.GetMasterReportItems();
		}

	    public IWinSettingProvider IWinSettingProvider
	    {
	        get { return _iWinSettingProvider; }
	    }

	    private void cboMasterReportType_SelectedIndexChanged(object sender, EventArgs e)
		{
			crystalReportViewer1.ReportSource = null;
			var reportType = ((LocalStore.MasterReportItems)(cboMasterReportType.SelectedItem)).ReportType;
			IList<String> _blankList = new List<String>();

			if (reportType == ReportType.Configuration)
			{
				_blankList.Add("-----Select All Configurations-----");
				cboSelectedReport.DataSource = _blankList;
			}
			else if (reportType == ReportType.Customer)
			{
				cboSelectedReport.DataSource = _customerService.GetCustomersList();
			}
			else if (reportType == ReportType.Supplier)
			{
				cboSelectedReport.DataSource = _supplierService.GetSuppliersList();
			}
			else if (reportType == ReportType.User)
			{
				_blankList.Add("-----Select All Users-----");
				cboSelectedReport.DataSource = _blankList;
			}

			cboSelectedReport.SelectedIndex = 0;
		}

		private void btnShowReport_Click(object sender, EventArgs e)
		{
			var reportDocument = new ReportDocument();
			var reportType = ((LocalStore.MasterReportItems)(cboMasterReportType.SelectedItem)).ReportType;
			DataSet reportDataSet;

			switch (reportType)
			{
				case ReportType.Configuration:
					reportDocument.Load(ReportUtility.ResolveReportPath(ReportConstants.CONFIGURATIONREPORTPATH));
					reportDataSet = GetConfigurationsReport();
					break;

				case ReportType.Customer:
					reportDocument.Load(ReportUtility.ResolveReportPath(ReportConstants.CUSTOMERSREPORTPATH));
					reportDataSet = GetCustomersReport(((CustomerItem)(cboSelectedReport.SelectedItem)).CustomerCode);
					break;

				case ReportType.Supplier:
					reportDocument.Load(ReportUtility.ResolveReportPath(ReportConstants.SUPPLIERSREPORTPATH));
					reportDataSet = GetSuppliersReport(((SupplierItem)(cboSelectedReport.SelectedItem)).SupplierCode);
					break;

				case ReportType.User:
					reportDocument.Load(ReportUtility.ResolveReportPath(ReportConstants.USERSREPORTPATH));
					reportDataSet = GetUsersReport();
					break;

				default:
					throw new NotImplementedException();
			}


			crystalReportViewer1.ReportSource = reportDocument;
			reportDocument.SetDataSource(reportDataSet);
			crystalReportViewer1.Refresh();
		}

		private DataSet GetCustomersReport(string customerCode)
		{
			var customerDataSet = new CustomerDataSet();
			var customerDataTable = customerDataSet.Tables["Customers"];
			var firmDataTable = customerDataSet.Tables["FirmMaster"];
            _firmDataSetService.GetFirmDataTable(firmDataTable);
			var customerList = new List<Customer>();

			if (customerCode == "0")
				customerList = _customerService.GetAllCustomers().ToList();
			else
				customerList.Add(_customerService.GetCustomerByCode(customerCode));

			foreach (var cust in customerList)
			{
				var customerRow = customerDataTable.NewRow();

				customerRow["CustomerId"] = cust.CustomersId;
				customerRow["CustomerCode"] = cust.CustomersCode;
				customerRow["CompanyName"] = cust.CompanyName;
				customerRow["ContactName"] = cust.ContactName;
				customerRow["Phone/Mobile"] = cust.Address.Phone;
				customerRow["Email"] = cust.Properties.Email1;
				customerRow["Website"] = cust.Properties.Website;
				customerRow["VATNumber"] = cust.VATNumber;
				customerRow["Note"] = cust.Properties.Note;

				customerDataTable.Rows.Add(customerRow);
			}
			return customerDataSet;
		}

		private DataSet GetSuppliersReport(string supplierCode)
		{
			var supplierDataSet = new SupplierDataSet();
			var supplierDataTable = supplierDataSet.Tables["Suppliers"];
			var firmDataTable = supplierDataSet.Tables["FirmMaster"];
            _firmDataSetService.GetFirmDataTable(firmDataTable);

			var supplierList = new List<Supplier>();

			if (supplierCode == "0")
				supplierList = _supplierService.GetAllSuppliers().ToList();
			else
				supplierList.Add(_supplierService.GetSupplierByCode(supplierCode));


			foreach (var supplier in supplierList)
			{
				var supplierRow = supplierDataTable.NewRow();

				supplierRow["SupplierId"] = supplier.SupplierId;
				supplierRow["SupplierCode"] = supplier.SupplierCode;
				supplierRow["CompanyName"] = supplier.CompanyName;
				supplierRow["ContactName"] = supplier.ContactName;
				supplierRow["Phone/Mobile"] = supplier.Address.Phone;
				supplierRow["Email"] = supplier.Properties.Email1;
				supplierRow["Website"] = supplier.Properties.Website;
				supplierRow["VATNumber"] = supplier.VATNumber;
				supplierRow["Note"] = supplier.Properties.Note;

				supplierDataTable.Rows.Add(supplierRow);
			}

			return supplierDataSet;
		}

		private DataSet GetConfigurationsReport()
		{
			var configurationDataSet = new ConfigurationDataSet();
			var configurationDataTable = configurationDataSet.Tables["Configurations"];
			var firmDataTable = configurationDataSet.Tables["FirmMaster"];
            _firmDataSetService.GetFirmDataTable(firmDataTable);
			var configurationList = _configurationService.GetAllConfigurations();

			foreach (var configuration in configurationList)
			{
				var configurationRow = configurationDataTable.NewRow();

				configurationRow["ConfigurationId"] = configuration.ConfigurationId;
				configurationRow["Particulars"] = configuration.Particulars;
				configurationRow["ConfigurationValue"] = configuration.ConfigurationValue;
				configurationRow["Remarks"] = configuration.Remarks;
				configurationRow["IsActive"] = configuration.Active;

				configurationDataTable.Rows.Add(configurationRow);
			}

			return configurationDataSet;
		}

		private DataSet GetUsersReport()
		{
			var userDataSet = new UserDataSet();
			var usersDataTable = userDataSet.Tables["Users"];
			var firmDataTable = userDataSet.Tables["FirmMaster"];
            _firmDataSetService.GetFirmDataTable(firmDataTable);
			var usersList = _userService.GetAllUser();

			foreach (var user in usersList)
			{
				var userRow = usersDataTable.NewRow();

				userRow["UserId"] = user.UserId;
				userRow["Email"] = user.Email;
				userRow["FirstName"] = user.Properties.FirstName;
				userRow["LastName"] = user.Properties.LastName;
				userRow["MiddleName"] = user.Properties.LastName;
				userRow["LastLoginDate"] = Convert.ToDateTime(user.LastLoginDate);
				userRow["UserName"] = user.LoginInformations.Username;
				userRow["IsActive"] = user.LoginInformations.IsActive;

				usersDataTable.Rows.Add(userRow);
			}

			return userDataSet;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.EntityClient;

namespace Connections
{
	public class ConnectionServices : IConnectionServices
	{
		readonly IDbConnection _connection;
	    readonly Dictionary<String, String> _errorItems;

		readonly IWinSettingProvider _settingProvider;

		public ConnectionServices()
		{
			_connection = new SqlConnection();
			_errorItems = new Dictionary<String, String>();
		}

		public ConnectionServices(IWinSettingProvider settingProvider)
			: this()
		{
			_settingProvider = settingProvider;
		}

		private bool IsServerConnected
		{
			get
			{
				try
				{
					_connection.Open();
				}
				catch (Exception ex)
				{
					_errorItems.Clear();
					_errorItems.Add(ex.Message, ex.Message);
					return false;
				}
				return true;
			}
		}

		public String CreateConnectionString<T>(T request) where T : DbConnectionStringBuilder
		{
			T builder = request;
			return builder.ConnectionString;
		}

		public bool CheckConnection(String ConnectionString)
		{
			if (_connection.State == ConnectionState.Open) _connection.Close();

			_connection.ConnectionString = ConnectionString;
			return IsServerConnected;
		}

		public String GetEntitySqlConnectionString()
		{
			var sqlConnectionString = _settingProvider.SqlConnectionString;
			var scsb = new SqlConnectionStringBuilder(sqlConnectionString);

			var request = new EntityConnectionStringBuilder
			{
			    Metadata = "res://*/Entities.inventory.csdl|res://*/Entities.inventory.ssdl|res://*/Entities.inventory.msl",
			    Provider = "System.Data.SqlClient",
			    ProviderConnectionString = scsb.ConnectionString
			};

		    return CreateConnectionString(request);
		}

		#region IValidation
		public void AddValidationError(string key, string value)
		{
			_errorItems.Add(key, value);
		}

		public Dictionary<string, string> AllErrors
		{
			get { return _errorItems; }
		}

		public int ErrorCount
		{
			get { return _errorItems.Count; }
		}

		public bool IsValid
		{
			get { return (_errorItems.Count == 0); }
		}
		#endregion
	}
}

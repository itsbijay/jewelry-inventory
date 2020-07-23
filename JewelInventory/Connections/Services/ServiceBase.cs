using Connections.Entities;
using System.Data;
using System.Data.Objects;
using JetCoders.Shared;
using NLog;

namespace Connections
{
	public abstract class ServiceBase
	{
		protected static Logger Logger = LogManager.GetCurrentClassLogger();

		private IinventoryContainer _dbContext;

		public IinventoryContainer DbContext { 
			get {
			    if (_dbContext != null) 
                    return _dbContext;

			    var _setting = new WinSettingProvider();
			    var _connectionServices = new ConnectionServices(_setting);
			    _dbContext = new inventoryContainer(_connectionServices.GetEntitySqlConnectionString());

			    return _dbContext;
			}		 
		 }

		 public IDataRecord GetOriginalRecord(IEntityBase Entity)
		 {
			var originalRecord = ((ObjectContext)DbContext).ObjectStateManager.GetObjectStateEntry(Entity).OriginalValues;

			return originalRecord;
		 }
	}
}

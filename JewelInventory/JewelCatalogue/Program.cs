using System;
using System.Windows.Forms;
using JewelCatalogue.Properties;
using NLog;
using Microsoft.Practices.Unity;
using System.Threading;
using System.Globalization;
using Connections;

namespace JewelCatalogue
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            if (DateTime.Today > new DateTime(2015, 12, 30))
            {
                MessageBox.Show(Resources.Program_Main_Your_software_demo_period_is_over__Please_contact_vendor);
                return;
            }

            BootStrapper.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var winSettingProvider = (IWinSettingProvider)BootStrapper.Container.Resolve(typeof(IWinSettingProvider));
            var connectionServices = (IConnectionServices)BootStrapper.Container.Resolve(typeof(IConnectionServices));
            bool hasConnection = connectionServices.CheckConnection(winSettingProvider.SqlConnectionString);
            if (false == hasConnection)
            {
                MessageBox.Show(Resources.Program_Main_Connection_could_not_be_established__please_check_connection_file_, Constants.ALERTMESSAGEHEADER, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
             

            LocalStore.CurrentUser = new User { UserId = 0 };

            Type type = typeof(frmSplash);

            Application.ThreadException += Application_ThreadException;
            Form windows = (frmSplash)BootStrapper.Container.Resolve(type, type.Name);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("hi-IN");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("hi-IN");

            Application.Run(windows);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger Logger = LogManager.GetCurrentClassLogger();
            Logger.ErrorException("An unhanlded Exception occoured....", e.Exception);
        }
    }

    public class BootStrapper
    {
        private static bool _isInitialized;
        private static readonly Object _locker = new object();
        public static IUnityContainer Container;

        public static void Initialize()
        {
            lock (_locker)
            {
                if (_isInitialized == false)
                {
                    Container = new UnityContainer()
                    .RegisterType<IWinSettingProvider, WinSettingProvider>()
                    .RegisterType<IUserService, UserService>()
                    .RegisterType<ICustomerService, CustomerService>()
                    .RegisterType<IConfigurationService, ConfigurationService>()
                    .RegisterType<ISupplierService, SupplierService>()
                    .RegisterType<IConnectionServices, ConnectionServices>()
                    .RegisterType<ITransactionService, TransactionService>()
                    .RegisterType<IFirmService, FirmService>()
                    .RegisterType<IReportService, ReportService>()
                    .RegisterType<IJewelService, JewelService>()
                    .RegisterType<ICatalogueService, CatalogueService>()
                    .RegisterType<IDataSetProvider, DataSetProvider>()
                    .RegisterType<ILooseDiamondService, LooseDiamondService>()
                    .RegisterType<IExcelExporter, ExcelExporter>();

                    _isInitialized = true;
                }
            }
        }
    }
}

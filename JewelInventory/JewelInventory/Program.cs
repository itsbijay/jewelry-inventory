using System;
using System.Windows.Forms;
using JewelInventory.Properties;
using Microsoft.Practices.Unity;
using Connections;
using System.Threading;
using System.Globalization;
using NLog;

namespace JewelInventory
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
            Application.SetCompatibleTextRenderingDefault(true);

            var type = typeof(frmSplash);
            Form windows;

            var winSettingProvider = BootStrapper.Container.Resolve<IWinSettingProvider>();
            var connectionServices = BootStrapper.Container.Resolve<IConnectionServices>();

            Application.ThreadException += Application_ThreadException;

            try
            {
                var hasConnection = connectionServices.CheckConnection(winSettingProvider.SqlConnectionString);
                if (false == hasConnection)
                {
                    windows = BootStrapper.Container.Resolve<frmConnection>();
                    ((frmConnection)windows).StartUpFlag = true;
                }
                else
                {
                    windows = (frmSplash)BootStrapper.Container.Resolve(type, type.Name);
                }
            }
            catch (Exception)
            {
                windows = BootStrapper.Container.Resolve<frmConnection>();
                ((frmConnection)windows).StartUpFlag = true;
            }

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("hi-IN");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("hi-IN");

            Application.Run(windows);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.ErrorException("An unhanlded exception occoured....", e.Exception);
        }
    }

    public class BootStrapper
    {
        private static bool _isInitialized;
        private static readonly Object Locker = new object();
        public static IUnityContainer Container;

        public static void Initialize()
        {
            lock (Locker)
            {
                if (_isInitialized == false)
                {
                    Container = new UnityContainer()
                        .RegisterType<IWinSettingProvider, WinSettingProvider>()
                        .RegisterType<IUserService, UserService>()
                        .RegisterType<ICustomerService, CustomerService>()
                        .RegisterType<IConfigurationService, ConfigurationService>()
                        .RegisterType<IJewelCalculation, JewelCalculation>()
                        .RegisterType<ISupplierService, SupplierService>()
                        .RegisterType<IConnectionServices, ConnectionServices>()
                        .RegisterType<ITransactionService, TransactionService>()
                        .RegisterType<IFirmService, FirmService>()
                        .RegisterType<IReportService, ReportService>()
                        .RegisterType<IReportUtility, ReportUtility>()
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
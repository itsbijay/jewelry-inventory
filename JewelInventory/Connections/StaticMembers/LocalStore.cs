using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Connections
{
	public class LocalStore
	{
		public class States
		{
			private static List<States> _list;

			public int Id;
			public String StateName;

			public States()
			{
				Id = default(Int32);
				StateName = String.Empty;
			}

			public override string ToString()
			{
				return StateName;
			}

			public static List<States> GetStates()
			{
				_list = new List<States>
				{
				    new States {Id = 1, StateName = "WESTBENGAL"},
				    new States {Id = 2, StateName = "ANDHRAPRADESH"},
				    new States {Id = 3, StateName = "ASSAM"},
				    new States {Id = 4, StateName = "BIHAR"},
				    new States {Id = 5, StateName = "CHHATTISGARH"},
				    new States {Id = 6, StateName = "DELHI"},
				    new States {Id = 7, StateName = "GOA"},
				    new States {Id = 8, StateName = "GUJARAT"},
				    new States {Id = 9, StateName = "HARYANA"},
				    new States {Id = 10, StateName = "HIMACHAL PRADESH"},
				    new States {Id = 11, StateName = "JAMMU & KASHMIR"},
				    new States {Id = 12, StateName = "JHARKHAND"},
				    new States {Id = 13, StateName = "KARNATAKA"},
				    new States {Id = 14, StateName = "KASHMIR"},
				    new States {Id = 15, StateName = "KERALA"},
				    new States {Id = 16, StateName = "MADHYA PRADESH"},
				    new States {Id = 17, StateName = "MAHARASHTRA"},
				    new States {Id = 18, StateName = "MANIPUR"},
				    new States {Id = 19, StateName = "MEGHALAYA"},
				    new States {Id = 20, StateName = "NAGALAND"},
				    new States {Id = 21, StateName = "NAINITAL"},
				    new States {Id = 22, StateName = "ORISSA"},
				    new States {Id = 23, StateName = "PUNJAB"},
				    new States {Id = 24, StateName = "RAJASTHAN"},
				    new States {Id = 24, StateName = "TAMIL NADU"},
				    new States {Id = 25, StateName = "TRIPURA"},
				    new States {Id = 26, StateName = "UTTAR PRADESH"},
				    new States {Id = 27, StateName = "UTTARANCHAL PRADESH"},
				    new States {Id = 28, StateName = "TELANGANA"}
				};

			    return _list;
			}
		}

		public class Countries
		{
			private static List<Countries> _list;

			public int Id;
			public String CountryName;

			public Countries()
			{
				Id = default(Int32);
				CountryName = String.Empty;
			}
			public override string ToString()
			{
				return CountryName;
			}
			public static List<Countries> GetCountries()
			{
				_list = new List<Countries>();
				_list.Add(new Countries { Id = 1, CountryName = "INDIA" });
				return _list;
			}
		}

		public class MasterReportItems
		{
			private static List<MasterReportItems> _list;

			public ReportType ReportType;
			public string MasterReport;

			public MasterReportItems()
			{
				ReportType = ReportType.NotSet;
				MasterReport = String.Empty;
			}

			public override string ToString()
			{
				return MasterReport;
			}

			public static List<MasterReportItems> GetMasterReportItems()
			{
				_list = new List<MasterReportItems>
				{
				    new MasterReportItems() {ReportType = ReportType.Configuration, MasterReport = "Configuration"},
				    new MasterReportItems() {ReportType = ReportType.Customer, MasterReport = "Customer"},
				    new MasterReportItems() {ReportType = ReportType.Supplier, MasterReport = "Supplier"},
				    new MasterReportItems() {ReportType = ReportType.User, MasterReport = "User"}
				};
			    return _list;
			}
		}

		public class TransactionTypeItems
		{
			private static List<TransactionTypeItems> _list;

			public TransactionType JewelTransactionType;
			public string Transaction;

			public TransactionTypeItems()
			{
				JewelTransactionType = TransactionType.NotSet;
				Transaction = String.Empty;
			}

			public override string ToString()
			{
				return Transaction;
			}

			public static List<TransactionTypeItems> GetTransactionTypeItems()
			{
				_list = new List<TransactionTypeItems>();
				_list.Add(new TransactionTypeItems() { JewelTransactionType = TransactionType.PurchaseTransaction, Transaction = "Purchase Transaction" });
				_list.Add(new TransactionTypeItems() { JewelTransactionType = TransactionType.ApprovalTransaction, Transaction = "Approval Transaction" });
				_list.Add(new TransactionTypeItems() { JewelTransactionType = TransactionType.MarketingTransaction, Transaction = "Marketing Transaction" });
				return _list;
			}
		}

		public class Products
		{
			private static List<Products> _list;

			public int Id;
			public String ProductsName;

			public Products()
			{
				Id = default(Int32);
				ProductsName = String.Empty;
			}
			public override string ToString()
			{
				return ProductsName;
			}
			public static List<Products> GetProducts()
			{
				_list = new List<Products>
				{
				    new Products() {Id = 0, ProductsName = "All"},
				    new Products() {Id = 1, ProductsName = "Bangle"},
				    new Products() {Id = 2, ProductsName = "Bracelet"},
				    new Products() {Id = 3, ProductsName = "Chain"},
				    new Products() {Id = 4, ProductsName = "Earring"},
				    new Products() {Id = 5, ProductsName = "Necklases"},
				    new Products() {Id = 6, ProductsName = "Necklace"},
				    new Products() {Id = 7, ProductsName = "Nose Ring"},
				    new Products() {Id = 8, ProductsName = "Pendant Set"},
				    new Products() {Id = 9, ProductsName = "Pendant"},
				    new Products() {Id = 10, ProductsName = "Ring"},
				    new Products() {Id = 11, ProductsName = "Tanmania"},
				    new Products() {Id = 12, ProductsName = "Tanmania Set"},
				    new Products() {Id = 13, ProductsName = "Watch"}
				};

			    return _list;
			}
		}

		public class SieveGroups
		{
			private static List<SieveGroups> _list;

			public String SieveGroupName;
			public Decimal MinValue;
			public Decimal MaxValue;

			public static List<SieveGroups> GetProducts()
			{
				_list = new List<SieveGroups>
				{
				    new SieveGroups() {SieveGroupName = "-2", MinValue = 0.004M, MaxValue = 0.008M},
				    new SieveGroups() {SieveGroupName = "+2-6", MinValue = 0.009M, MaxValue = 0.018M},
				    new SieveGroups() {SieveGroupName = "+6-10", MinValue = 0.019M, MaxValue = 0.058M},
				    new SieveGroups() {SieveGroupName = "+10-11", MinValue = 0.059M, MaxValue = 0.074M},
				    new SieveGroups() {SieveGroupName = "+11-13", MinValue = 0.075M, MaxValue = 0.108M},
				    new SieveGroups() {SieveGroupName = "1/8", MinValue = 0.11M, MaxValue = 0.125M},
				    new SieveGroups() {SieveGroupName = "1/7", MinValue = 0.13M, MaxValue = 0.146M},
				    new SieveGroups() {SieveGroupName = "1/6", MinValue = 0.147M, MaxValue = 0.175M},
				    new SieveGroups() {SieveGroupName = "1/5", MinValue = 0.176M, MaxValue = 0.21M},
				    new SieveGroups() {SieveGroupName = "1/4", MinValue = 0.22M, MaxValue = 0.27M},
				    new SieveGroups() {SieveGroupName = "1/3", MinValue = 0.28M, MaxValue = 0.37M},
				    new SieveGroups() {SieveGroupName = "3/8", MinValue = 0.38M, MaxValue = 0.43M},
				    new SieveGroups() {SieveGroupName = "1/2", MinValue = 0.44M, MaxValue = 0.69M},
				    new SieveGroups() {SieveGroupName = "SEVENTY", MinValue = 0.70M, MaxValue = 0.89M},
				    new SieveGroups() {SieveGroupName = "NINTY", MinValue = 0.90M, MaxValue = 0.99M}
				};

			    return _list;
			}

			public static String GetSieveGroupName(decimal amount)
			{
				var group = GetProducts().FirstOrDefault(x => x.MinValue <= amount && x.MaxValue >= amount);
				if (group == null)
					return String.Empty;

				return group.SieveGroupName;
			}

            public override string ToString()
            {
                return SieveGroupName;
            }
		}

        public static User CurrentUser { get; set; }
        public static Bitmap SceenBitMap { get; set; }

        //TODO: storing costing items in cache for retrievals
        public static CostingRates CostingRates { get; set; }
	}
}


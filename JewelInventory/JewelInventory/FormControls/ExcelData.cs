using System.Collections.Generic;
using JetCoders.Shared;

namespace JewelInventory
{
	public class ExcelData
	{
		public int SRNO { get; set; }
		public string CERTNO { get; set; }
		public string DESIGNNO { get; set; }
		public string TYPE { get; set; }
		public decimal GRWT { get; set; }
		public string KT { get; set; }
		public string STONETYPE { get; set; }
		public int TOTALDIAPCS { get; set; }
		public decimal TOTALDIAWT { get; set; }
		public string SIEVESIZE { get; set; }
		public int DIAPCSDETAIL { get; set; }
		public decimal DIAWTDETAIL { get; set; }
		public int CPCS { get; set; }
		public decimal CWT { get; set; }
		public decimal STAMP { get; set; }
		public string BRAND { get; set; }
	}

	public class JewelData
	{
		public JewelData()
		{
			Items = new List<Item>();
		}
		public List<Item> Items { get; set; }
		public class Item
		{
			public Item()
			{
				SIEVESIZE = new List<string>();
				DIAPCSDETAIL = new List<int>();
				DIAWTDETAIL = new List<decimal>();
			}
			public int SRNO { get; set; }
			public string CERTNO { get; set; }
			public string DESIGNNO { get; set; }
			public string TYPE { get; set; }
			public decimal GRWT { get; set; }
			public string KT { get; set; }
			public string STONETYPE { get; set; }
			public int TOTALDIAPCS { get; set; }
			public decimal TOTALDIAWT { get; set; }
			public IList<string> SIEVESIZE { get; set; }
			public IList<int> DIAPCSDETAIL { get; set; }
			public IList<decimal> DIAWTDETAIL { get; set; }
			public int CPCS { get; set; }
			public decimal CWT { get; set; }
			public decimal STAMP { get; set; }
			public string BRAND { get; set; }

			public bool IsValid { get { return ErrorMessage.IsEmpty(); } }
            public bool HasDiamond { get { return TOTALDIAPCS > 0; } }
			public bool HasColorStone { get { return CPCS > 0; } }

			public string ErrorMessage { get; set; }
		}
	}
}

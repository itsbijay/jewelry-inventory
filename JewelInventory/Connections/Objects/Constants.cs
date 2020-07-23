
namespace Connections
{
	public class Constants
	{
		public const string INVENTORYPRODUCT_TTITLE = "JEWELS INVENTORY";
        public const string CATALOGUEPRODUCT_TITLE = "JEWELS CATALOGUE";
        public const string PRODUCTLICENSEE = "JEWELS INVENTORY";
		public const string ALERTMESSAGEHEADER = "Look's there is a problem";
		public const string AMOUNTVALUEREGEX = @"^\d+(\.\d\d)?$";
		public const string REQUIREFIELDMESSAGE = @"Fileds are required";
		public const string EMAILPATTERN = @"^([a-zA-Z0-9_\-\.\+]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";

		public const string TRANSACTIONPREFIX = "VAN";

		public const string INVOICEFORMAT = "INV{0:MMddyyyy}-{{0}}";

        public const string PURCHASE_MEMOFORMAT = "PUR{0:MMddyyyy}-{{0}}";
        public const string MARKETING_MEMOFORMAT = "MKT{0:MMddyyyy}-{{0}}";
        public const string APPROVAL_MEMOFORMAT = "APM{0:MMddyyyy}-{{0}}";
        public const string MARKETING_RETURN_MEMOFORMAT = "MKT-RTN{0:MMddyyyy}-{{0}}";
        public const string APPROVAL_RETURN_MEMOFORMAT = "APM-RTN{0:MMddyyyy}-{{0}}";
        public const string SALES_MEMOFORMAT = "SL{0:MMddyyyy}-{{0}}";
        public const string SALES_RETURN_MEMOFORMAT = "SL-RTN{0:MMddyyyy}-{{0}}";
        
        public const string TRANFORMAT = "TRAN{0:MMddyyyy}-{{0}}";

        public const string LOOKUPFORMAT = "LU{0:MMddyyyy}-{{0}}";

		public const string SQLCONNECTIONSTRING = "SqlConnectionString";

		public const string IMAGEDIRECTORY = "ImagePath";
        public const string IMAGEFORMAT = "jpg";

        public const string STOCKUPLOADMANULMODE = "StockUploadManulMode";

        public const string EXCELDIRECTORY = "EXCELDIRECTORY";

        public const string JEWELMASTERPREFIX = "JM00";
        public const string CUSTOMERMASTERPREFIX = "CU00";
        public const string SUPPLIERMASTERPREFIX = "SU00";
		public const string LOOSEDIAMONDPREFIX = "DIA00";
	}
}

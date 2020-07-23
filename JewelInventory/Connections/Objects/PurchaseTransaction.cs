using System;

namespace Connections
{
	public class PurchaseTransaction
	{
		public virtual Guid JewelTransactionRowId { get; set; }

		public virtual int JewelTransactionId
		{
			get;
			set;
		}

		public virtual string FinancialYearCode
		{
			get;
			set;
		}

		public virtual DateTime TransactionDate
		{
			get;
			set;
		}

		public virtual string ContactName
		{
			get;
			set;
		}

		public virtual string DocNumber
		{
			get;
			set;
		}

		public virtual string Remarks
		{
			get;
			set;
		}

		public virtual string CertificateNumber
		{
			get;
			set;
		}

		public virtual string JewelType
		{
			get;
			set;
		}

		public virtual string JewelNumber
		{
			get;
			set;
		}

		public virtual string DesingCode
		{
			get;
			set;
		}

		public virtual decimal TotalWeight
		{
			get;
			set;
		}

		public virtual decimal MetalWeight
		{
			get;
			set;
		}

		public virtual decimal StoneWeight
		{
			get;
			set;
		}

		public virtual int StonePcs
		{
			get;
			set;
		}

		public virtual decimal TotalAmount
		{
			get;
			set;
		}

		public virtual TransactionDetails Properties { get; set; }
	}
}

using System;
using System.Runtime.Serialization;

namespace Connections
{
	[DataContract]
    [Serializable]
	public class ItemDetail
	{
		public ItemDetail()
		{
			ItemDescription = String.Empty;
			JewelNumber = String.Empty;
			CertificateNumber = String.Empty;
			ItemCategory = String.Empty;
			DesignCode = String.Empty;
			TotalWeight = default(decimal);
			MetalDetail = new MetalDetail();
			StoneDetail = new StoneDetail();
			ColorStoneDetail = new ColorStoneDetail();
			LabourCharges = default(decimal);
			CertificateCharges = default(decimal);
		}
        
		[DataMember]
		public string ItemDescription { get; set; }
		[DataMember]
		public string JewelNumber { get; set; }
		[DataMember]
		public string CertificateNumber { get; set; }
		[DataMember]
		public string DesignCode { get; set; }
		[DataMember]
		public String ItemCategory { get; set; }
		[DataMember]
		public decimal TotalWeight { get; set; }
		[DataMember]
		public MetalDetail MetalDetail { get; set; }
		[DataMember]
		public StoneDetail StoneDetail { get; set; }
		[DataMember]
		public ColorStoneDetail ColorStoneDetail { get; set; }
		[DataMember]
		public decimal LabourCharges { get; set; }
		[DataMember]
		public decimal CertificateCharges { get; set; }
		[DataMember]
		public decimal StampingCharges { get; set; }

		public decimal Amount
		{
			get
			{
				return Math.Max(LabourCharges + CertificateCharges + MetalDetail.MetalNetAmount + ColorStoneDetail.ColorStoneNetAmount + StoneDetail.StoneNetAmount + StampingCharges, 0);
			}
		}
	}
}

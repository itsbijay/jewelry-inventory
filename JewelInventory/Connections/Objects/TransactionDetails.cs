using System;
using System.Runtime.Serialization;

namespace Connections
{
	[DataContract]
    [Serializable]
	public class TransactionDetails
	{
		[DataMember]
		public ItemDetail ItemDetails { get; set; }
	}
}

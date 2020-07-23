using System;
using System.Runtime.Serialization;

namespace Connections
{
	[DataContract]
	public class CustomerProperties
	{
		[DataMember]
		public String FirstName { get; set; }

		[DataMember]
		public String MiddleName { get; set; }

		[DataMember]
		public String LastName { get; set; }

		[DataMember]
		public String Email1 { get; set; }

		[DataMember]
		public String Email2 { get; set; }

		[DataMember]
		public String Website { get; set; }

		[DataMember]
		public DateTime DOB { get; set; }

		[DataMember]
		public String BankName { get; set; }

		[DataMember]
		public String AccountNumber { get; set; }

		[DataMember]
		public String Note { get; set; }

		public string FullName()
		{
			return FirstName + " " + LastName;
		}
	}
}

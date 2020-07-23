using System;
using System.Runtime.Serialization;

namespace Connections
{
    [DataContract]
	public class UserProperties
	{
        [DataMember]
        public String FirstName { get; set; }

        [DataMember]
        public String MiddleName { get; set; }

        [DataMember]
        public String LastName { get; set; }

        [DataMember]
        public String Email { get; set; }

		public string FullName()
		{
			return FirstName + " " + LastName;
		}
	}
}

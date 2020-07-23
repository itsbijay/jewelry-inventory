using System;
using System.Runtime.Serialization;

namespace Connections
{
    [DataContract]
    [Serializable]
    public class CostingDetails
    {
        [DataMember]
        public ProductCategory ProductCategory { get; set; }

        [DataMember]
        public string Particulars { get; set; }

        [DataMember]
        public string ConfigurationValue { get; set; }

        [DataMember]
        public Decimal Amount { get; set; }

        [DataMember]
        public Decimal MinimumAmount { get; set; }

        [DataMember]
        public JewelItemCategory MetalType { get; set; }
    }
}
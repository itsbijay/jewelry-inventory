using System;
using System.Runtime.Serialization;

namespace Connections
{
    [DataContract]
    public class TransactionLookupDetail
    {
        [DataMember]
        public decimal TaxRate { get; set; }
        [DataMember]
        public decimal OtherTaxRate { get; set; }

        [DataMember]
        public decimal TaxAmount { get; set; }
        [DataMember]
        public decimal OtherTaxAmount { get; set; }

        [IgnoreDataMember]
        public decimal TotalAmount { get { return Math.Max(TaxAmount + OtherTaxAmount, 0); } set {  } }
    }
}

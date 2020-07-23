using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Connections
{
    [DataContract]
    [Serializable]
    public class CertificateRates
    {
        public CertificateRates()
        {
            Items = new List<CertificateRatesItems>();
        }

        [DataMember]
        public List<CertificateRatesItems> Items { get; set; }

        [Serializable]
        public class CertificateRatesItems
        {
            public Decimal RangeMinValue;
            public Decimal RangeMaxValue;
            public Decimal Amount;
        }

    }
}
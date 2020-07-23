using System;
using System.Runtime.Serialization;

namespace Connections
{
    [DataContract]
    [Serializable]
    public class MetalDetail
    {
        public MetalDetail()
        {
            MetalType = String.Empty;
            MetalKT = String.Empty;
            MetalNetWt = default(decimal);
            MetalNetAmount = default(decimal);
        }

        [DataMember]
        public string MetalType { get; set; }
        [DataMember]
        public string MetalKT { get; set; }
        [DataMember]
        public decimal MetalNetWt { get; set; }
        [DataMember]
        public decimal MetalNetAmount { get; set; }

    }
}
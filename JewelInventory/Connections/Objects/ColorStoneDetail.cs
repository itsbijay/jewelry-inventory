using System;
using System.Runtime.Serialization;

namespace Connections
{
    [DataContract]
    [Serializable]
    public class ColorStoneDetail
    {
        public ColorStoneDetail()
        {
            ColorStoneType = String.Empty;
            ColorStoneNetWt = default(decimal);
            ColorStoneNetAmount = default(decimal);
            ColorTotalStonePcs = default(int);
        }

        [DataMember]
        public string ColorStoneType { get; set; }
        [DataMember]
        public decimal ColorStoneNetWt { get; set; }
        [DataMember]
        public decimal ColorStoneNetAmount { get; set; }
        [DataMember]
        public int ColorTotalStonePcs { get; set; }
    }
}
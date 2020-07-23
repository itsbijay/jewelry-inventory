using System;
using System.Runtime.Serialization;

namespace Connections
{
    [DataContract]
    [Serializable]
    public class StoneDetail
    {
        public StoneDetail()
        {
            StoneType = String.Empty;
            StoneNetWt = default(decimal);
            StoneNetAmount = default(decimal);
            TotalStonePcs = default(int);
            StoneChart = new StoneChart();
        }

        [DataMember]
        public string StoneType { get; set; }
        [DataMember]
        public decimal StoneNetWt { get; set; }
        [DataMember]
        public decimal StoneNetAmount { get; set; }
        [DataMember]
        public int TotalStonePcs { get; set; }
        [DataMember]
        public StoneChart StoneChart { get; set; }
    }
}
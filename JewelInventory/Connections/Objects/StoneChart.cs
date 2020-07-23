using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Connections
{
    [DataContract]
    [Serializable]
    public class StoneChart
    {
        public StoneChart()
        {
            StoneMetaDetailList = new List<StoneMetaDetail>();
        }

        [DataMember]
        public List<StoneMetaDetail> StoneMetaDetailList { get; set; }
    }
}
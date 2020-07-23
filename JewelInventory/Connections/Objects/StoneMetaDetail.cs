using System;
using System.Runtime.Serialization;

namespace Connections
{
    [DataContract]
    [Serializable]
    public class StoneMetaDetail
    {
        public StoneMetaDetail()
        {
            StoneSieveSz = String.Empty;
            StonePcs = default(int);
            StoneValue = default(decimal);
            StoneWt = default(decimal);
        }

        [DataMember]
        public string StoneSieveSz { get; set; }
        [DataMember]
        public decimal StoneWt { get; set; }
        [DataMember]
        public int StonePcs { get; set; }
        [DataMember]
        public decimal StoneValue { get; set; }
    }
}
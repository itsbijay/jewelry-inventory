using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Connections
{
    [DataContract]
    [Serializable]
    public class CostingRates
    {
        public CostingRates()
        {
            CostingItems = new List<CostingDetails>();
        }

        [DataMember]
        public List<CostingDetails> CostingItems { get; set; }

        [DataMember]
        public CertificateRates CertificateRate { get; set; }

		[DataMember]
		public decimal StampingRates { get; set; }

        [IgnoreDataMember]
        public bool HasCostingItems
        {
            get
            {
                return (CostingItems.Any(x => x.ProductCategory == ProductCategory.Stone) || CostingItems.Any(x => x.ProductCategory == ProductCategory.ColorStone)) &&
                        CostingItems.Any(x => x.ProductCategory == ProductCategory.Metal) &&
                        CostingItems.Any(x => x.ProductCategory == ProductCategory.Labour);
            }
        }
    }
}

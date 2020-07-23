using System;
using System.Collections.Generic;
using System.Linq;

namespace Connections
{
    public class Catalogue
    {
        public object this[int i]
        {
            get { return CatalogueData[i]; }
        }

        public String QuotationNo { get; set; }
        public String CustomerName { get; set; }
        public DateTime QuotationDate { get; set; }

        public IList<CatalogueMetaData> CatalogueData { get; set; }

        public Decimal TotalNetWt { get { return CatalogueData.Sum(x => x.NetWt); } }
        public int TotalGrsWt { get { return CatalogueData.Sum(x => x.GrsWt); } }
        public Decimal TotalDiaWt { get { return CatalogueData.Sum(x => x.DiaWt); } }
        public int TotalDiaPcs { get { return CatalogueData.Sum(x => x.DiaPcs); } }

        public object[,] ToArray()
        {
            var totalCols = typeof(CatalogueMetaData).GetProperties().Length;
            var totalRows = CatalogueData.Count();
            var arrays = new object[totalRows, totalCols];
            var indexer = 0;
            for (int k = 0; k < totalRows; k++)
            {
                var catalogue = CatalogueData[indexer];
                arrays[k, 0] = catalogue.SrNo;
                arrays[k, 1] = ImageExtension.GetImageName(catalogue.StyleNo);
                arrays[k, 2] = catalogue.JewelNo;
                arrays[k, 3] = catalogue.StyleNo;
                arrays[k, 4] = catalogue.JewelDescription;
                arrays[k, 5] = catalogue.MetalColor;
                arrays[k, 7] = catalogue.DiaPcs;
                arrays[k, 8] = catalogue.DiaWt;
                arrays[k, 9] = catalogue.GrsWt;
                arrays[k, 10] = catalogue.NetWt;

                indexer++;
            }

            return arrays;
        }

        #region CatalogueSummary
        public IList<CatalogueSummary> CatalogueSummaries { get; set; }

        public class CatalogueSummary
        {
            public String JewelDescription { get; set; }
            public Int32 TotalProducts { get; set; }
            public int GrsWt { get; set; }
            public Decimal NetWt { get; set; }
            public int DiaPcs { get; set; }
            public Decimal DiaWt { get; set; }
        }

        public object[,] ToArrayofCatalogueSummary()
        {
            var totalCols = typeof(CatalogueSummary).GetProperties().Length - 1;
            var totalRows = CatalogueSummaries.Count();
            var arrays = new object[totalRows, totalCols];
            var indexer = 0;

            for (var k = 0; k < totalRows; k++)
            {
                var catalogue = CatalogueSummaries[indexer];
                arrays[k, 0] = catalogue.JewelDescription;
                arrays[k, 1] = catalogue.TotalProducts;
                arrays[k, 2] = catalogue.NetWt;
                arrays[k, 3] = catalogue.GrsWt;
                arrays[k, 4] = catalogue.DiaWt;
                arrays[k, 5] = catalogue.DiaPcs;

                indexer++;
            }

            return arrays;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Connections
{
    public class CatalogueService : ICatalogueService
    {
        private readonly IJewelService _jewelService;
        private readonly IDataSetProvider _firmDataSetService;

        public CatalogueService(IJewelService jewelService, IDataSetProvider firmDataSetService)
        {
            _jewelService = jewelService;
            _firmDataSetService = firmDataSetService;
        }

        public Catalogue GetCatalogue(IList<QueryRequest> requestLists, string customerName)
        {
            var catalogueData = new List<CatalogueMetaData>();
            int incr = 1;
            foreach (var request in requestLists)
            {
                var dgvr = _jewelService.GetJewelsByJewelNo(request.JewelNo);

                CatalogueMetaData catalogue = null;

                if (dgvr != null)
                {
                    catalogue = new CatalogueMetaData
                        {
                            SrNo = incr++,
                            JewelNo = dgvr.JewelNo,
                            StyleNo = dgvr.StyleNo,
                            MetalColor = dgvr.MetalColor,
                            NetWt = Convert.ToDecimal(dgvr.NetWt),
                            GrsWt = Convert.ToInt32(dgvr.GrsWt),
                            DiaWt = Convert.ToDecimal(dgvr.DiamondWt),
                            DiaPcs = Convert.ToInt32(dgvr.DiamondPcs),
                            JewelDescription = dgvr.JewelDescription,
                        };
                }

                catalogueData.Add(catalogue);
            }

            var catalogueSummary = from j in catalogueData
                                   group j by new
                                   {
                                       j.JewelDescription,
                                   } into jewel
                                   select new Catalogue.CatalogueSummary
                                   {
                                       JewelDescription = jewel.Key.JewelDescription,
                                       TotalProducts = jewel.Count(),

                                       DiaPcs = jewel.Sum(x => x.DiaPcs),
                                       DiaWt = jewel.Sum(x => x.DiaWt),
                                       NetWt = jewel.Sum(x => x.NetWt),
                                       GrsWt = jewel.Sum(x => x.GrsWt)
                                   };
            var quotationNumber = DateTime.Now.ToString("ddMMyy");
            var catalogues = new Catalogue { CatalogueData = catalogueData, CustomerName = customerName, QuotationDate = DateTime.Now, QuotationNo = quotationNumber, CatalogueSummaries = catalogueSummary.ToList() };
            return catalogues;
        }

        public OrderDataSet GetCatalogueReport(IList<QueryRequest> requestLists, bool includeSummary)
        {
            var totalDiaPcs = 0;
            var totalGrsWt = 0x0;
            using (var orderDataSet = new OrderDataSet())
            {
                decimal totalNetWt = 0, totalDiaWt = 0;

                var dtCatalogueMetaDataTable = orderDataSet.Tables["CatalogueMetaDataTable"];
                var dtSummary = orderDataSet.Tables["SummaryDataTable"];
                var dtCatalogueSummary = orderDataSet.Tables["CatalogueSummaryDataTable"];
                var firmDataTable = orderDataSet.Tables["FirmMaster"];
                _firmDataSetService.GetFirmDataTable(firmDataTable);

                int incr = 1;

                #region Adding Data to master tables

                foreach (var request in requestLists)
                {
                    var JewelData = _jewelService.GetJewelsByJewelNo(request.JewelNo);

                    ///// Adding Data to NewMetal Table ////////
                    DataRow newMetaRow = dtCatalogueMetaDataTable.NewRow();
                    newMetaRow["SrNo"] = incr;
                    newMetaRow["JewelNo"] = JewelData.JewelNo;
                    newMetaRow["StyleNo"] = JewelData.StyleNo;
                    newMetaRow["JewelDescription"] = JewelData.JewelDescription;
                    newMetaRow["MetalColor"] = JewelData.MetalColor;
                    newMetaRow["NetWt"] = JewelData.NetWt;
                    newMetaRow["GrsWt"] = JewelData.GrsWt;
                    newMetaRow["DiaWt"] = JewelData.DiamondWt;
                    newMetaRow["DiaPcs"] = JewelData.DiamondPcs;

                    totalNetWt = totalNetWt + Convert.ToDecimal(JewelData.NetWt);
                    totalGrsWt = totalGrsWt + Convert.ToInt32(JewelData.GrsWt);
                    totalDiaWt = totalDiaWt + Convert.ToDecimal(JewelData.DiamondWt);
                    totalDiaPcs = totalDiaPcs + Convert.ToInt32(JewelData.DiamondPcs);

                    newMetaRow["JewelImage"] = ImageExtension.ResolveImage(JewelData.StyleNo);
                    dtCatalogueMetaDataTable.Rows.Add(newMetaRow);

                    incr = incr + 1;
                }

                #endregion

                #region Adding Data to summary tables

                var totalItems = requestLists.Count;
                var summaryRow = dtSummary.NewRow();
                summaryRow["TotalItems"] = totalItems;
                summaryRow["TotalNetWt"] = totalNetWt;
                summaryRow["TotalGrsWt"] = totalGrsWt;
                summaryRow["TotalDiaWt"] = totalDiaWt;
                summaryRow["TotalDiaPcs"] = totalDiaPcs;
                dtSummary.Rows.Add(summaryRow);

                if (includeSummary)
                {

                    var catalogueSummary = from j in dtCatalogueMetaDataTable.AsEnumerable()
                                           group j by new
                                               {
                                                   JewelDescription = j.FieldOrDefault<string>("JewelDescription")
                                               } into jewel
                                           select new
                                               {
                                                   jewel.Key.JewelDescription,
                                                   TotalProducts = jewel.Count(),
                                                   DiaPcs = jewel.Sum(x => x.FieldOrDefault<int>("DiaPcs")),
                                                   DiaWt = jewel.Sum(x => x.FieldOrDefault<decimal>("DiaWt")),
                                                   NetWt = jewel.Sum(x => x.FieldOrDefault<decimal>("NetWt")),
                                                   GrsWt = jewel.Sum(x => x.FieldOrDefault<int>("GrsWt"))
                                               };

                    foreach (var summary in catalogueSummary)
                    {
                        var catalogueSummaryRow = dtCatalogueSummary.NewRow();
                        catalogueSummaryRow["NetWt"] = summary.NetWt;
                        catalogueSummaryRow["GrsWt"] = summary.GrsWt;
                        catalogueSummaryRow["DiaWt"] = summary.DiaWt;
                        catalogueSummaryRow["DiaPcs"] = summary.DiaPcs;
                        catalogueSummaryRow["JewelDescription"] = summary.JewelDescription;
                        catalogueSummaryRow["TotalProducts"] = summary.TotalProducts;
                        dtCatalogueSummary.Rows.Add(catalogueSummaryRow);
                    }
                }
                #endregion

                return orderDataSet;
            }
        }
    }
}

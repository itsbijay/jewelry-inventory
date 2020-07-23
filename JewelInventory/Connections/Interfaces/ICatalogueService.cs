using System.Collections.Generic;

namespace Connections
{
    public interface ICatalogueService
    {
        OrderDataSet GetCatalogueReport(IList<QueryRequest> requestLists, bool includeSummary);
        Catalogue GetCatalogue(IList<QueryRequest> requestLists, string customerName);
    }
}
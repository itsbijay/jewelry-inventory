using System.Collections.Generic;
using System.Data;
using Connections.Dataset;

namespace Connections
{
    public interface IDataSetProvider
    {
        DataTable GetFirmDataTable(DataTable firmDataTable);
        CostingChartDataSet GetCostingChartDataSet(List<int> requests);
    }
}
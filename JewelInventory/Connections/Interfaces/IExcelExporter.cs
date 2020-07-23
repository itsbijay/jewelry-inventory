using System.Collections.Generic;

namespace Connections
{
    public interface IExcelExporter
    {
        void ExportToExcel(IList<JewelStockLedger> jewelStockLedgerList);
        void ExcelExportForJewelMaster(List<JewelMaster> jewelMasterList);
    }
}
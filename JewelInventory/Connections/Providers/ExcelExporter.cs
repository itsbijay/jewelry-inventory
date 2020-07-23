using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace Connections
{
    public class ExcelExporter : IExcelExporter
    {
        //http://www.clear-lines.com/blog/post/Write-data-to-an-Excel-worksheet-with-C-fast.aspx

        public ExcelExporter()
        {
        }

        public void ExportToExcel(IList<JewelStockLedger> jewelStockLedgerList)
        {
            var excelApp = new Excel.Application();
            Worksheet excelWorkSheet = null;
 
            excelApp.Visible = true;
            var excelWorkBook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            // ExcelWorkBook.Worksheets.Add(); //Adding New Sheet in Excel Workbook
            try
            {
                excelWorkSheet = excelWorkBook.Worksheets[1]; // Compulsory Line in which sheet you want to write data
                //Writing data into excel of 100 rows with 10 column 

                excelWorkSheet.Cells[1, 1] = "CERTI NO";
                excelWorkSheet.Cells[1, 2] = "DESIGN NO";
                excelWorkSheet.Cells[1, 3] = "DIA PCS";
                excelWorkSheet.Cells[1, 4] = "DIA WT";
                excelWorkSheet.Cells[1, 5] = "GR WT";
                excelWorkSheet.Cells[1, 6] = "NT WT";
                excelWorkSheet.Cells[1, 7] = "AMT";

                var rows = jewelStockLedgerList.ToList();
                for (int r = 0; r < rows.Count; r++) //r stands for ExcelRow and c for ExcelColumn
                {
                    var row = r + 2;
                    excelWorkSheet.Cells[row, 1] = rows[r].CertificateNumber;
                    excelWorkSheet.Cells[row, 2] = rows[r].DesignCode;
                    excelWorkSheet.Cells[row, 3] = rows[r].StonePcs;
                    excelWorkSheet.Cells[row, 4] = rows[r].StoneWeight;
                    excelWorkSheet.Cells[row, 5] = rows[r].TotalWeight;
                    excelWorkSheet.Cells[row, 6] = rows[r].MetalWeight;
                    excelWorkSheet.Cells[row, 7] = "";
                }

                 excelWorkBook.SaveAs("BarCodeData_" + DateTime.Now.ToString("MMddyyyy_HHmmss") + ".xls", XlFileFormat.xlWorkbookNormal);
                 MessageBox.Show("Process Completed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 excelApp.Visible = true;

                excelWorkBook.Close();
                excelApp.Quit();

               
            }
            catch (Exception exHandle)
            {
                Console.WriteLine("Exception: " + exHandle.Message);
                Console.ReadLine();
            }
            finally
            {
                ReleaseObject(excelApp);
                ReleaseObject(excelWorkBook);
                ReleaseObject(excelWorkSheet);
            }
         }

        public void ExcelExportForJewelMaster(List<JewelMaster> jewelMasterList)
        {
            var excelApp = new Excel.Application();
            Worksheet excelWorkSheet = null;

            excelApp.Visible = true;
            Workbook excelWorkBook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            // ExcelWorkBook.Worksheets.Add(); //Adding New Sheet in Excel Workbook
            try
            {
                excelWorkSheet = excelWorkBook.Worksheets[1]; // Compulsory Line in which sheet you want to write data
                //Writing data into excel of 100 rows with 10 column 

                excelWorkSheet.Cells[1, 1] = "CERTI NO";
                excelWorkSheet.Cells[1, 2] = "DESIGN NO";
                excelWorkSheet.Cells[1, 3] = "DIA PCS";
                excelWorkSheet.Cells[1, 4] = "DIA WT";
                excelWorkSheet.Cells[1, 5] = "GR WT";
                excelWorkSheet.Cells[1, 6] = "NT WT";
                excelWorkSheet.Cells[1, 7] = "AMT";

                var rows = jewelMasterList;
                for (var r = 0; r < rows.Count; r++) //r stands for ExcelRow and c for ExcelColumn
                {
                    var row = r + 2;
                    excelWorkSheet.Cells[row, 1] = "";
                    excelWorkSheet.Cells[row, 2] = rows[r].StyleNo;
                    excelWorkSheet.Cells[row, 3] = rows[r].DiamondPcs;
                    excelWorkSheet.Cells[row, 4] = rows[r].DiamondWt;
                    excelWorkSheet.Cells[row, 5] = rows[r].GrsWt;
                    excelWorkSheet.Cells[row, 6] = rows[r].NetWt;
                    excelWorkSheet.Cells[row, 7] = "";
                }

                excelWorkBook.SaveAs("BarCodeData_" + DateTime.Now.ToString("MMddyyyy_HHmmss") + ".xls", XlFileFormat.xlWorkbookNormal);
                MessageBox.Show("Process Completed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                excelApp.Visible = true;

                excelWorkBook.Close();
                excelApp.Quit();


            }
            catch (Exception exHandle)
            {
                Console.WriteLine("Exception: " + exHandle.Message);
                Console.ReadLine();
            }
            finally
            {
                ReleaseObject(excelApp);
                ReleaseObject(excelWorkBook);
                ReleaseObject(excelWorkSheet);
            }
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}

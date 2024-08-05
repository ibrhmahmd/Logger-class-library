using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ILogger
{
    public class ExcelFileLogger : Logger
    {
        public ExcelFileLogger(string fileName)
        {
            this.Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }
        public override void log(string msg)
        {
            Application excelApp = null;
            Workbook workbook = null;
            Worksheet worksheet = null;

            try
            {
                excelApp = new Application();
                workbook = excelApp.Workbooks.Open(Path, ReadOnly: false, Editable: true);
                worksheet = workbook.Sheets[1] as Worksheet;

                // Find the next available row
                int row = worksheet.UsedRange.Rows.Count + 1;

                DateTime time = DateTime.Now;

                // Use fully qualified name for Range
                Microsoft.Office.Interop.Excel.Range cell = worksheet.Cells[row, 1] as Microsoft.Office.Interop.Excel.Range;
                cell.Value = time.ToString();

                cell = worksheet.Cells[row, 2] as Microsoft.Office.Interop.Excel.Range;
                cell.Value = msg;

                workbook.Save();
                Console.WriteLine("Log written successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Logging Error: {e.Message}");
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close();
                    Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}

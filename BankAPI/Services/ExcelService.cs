using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace BankAPI.Services
{
    public class ExcelService
    {
        public static void GenerateXlsxReport(Dictionary<DateTime, decimal> report)
        {
            var excelApp = new Excel.Application();

            excelApp.Visible = true;

            excelApp.Workbooks.Add();

            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            int row = 1;
            foreach (var date in report.Keys)
            {
                workSheet.Cells[row, "A"] = date.ToString();
                workSheet.Cells[row, "B"] = report[date];
                row++;
            }


            //workSheet.Columns[1].Autofit();
            //workSheet.Columns[2].Autofit();
        }
    }
}

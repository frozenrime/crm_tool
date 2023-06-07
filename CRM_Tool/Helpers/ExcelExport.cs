using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_Tool.Helpers
{
    public class ExcelExport : ExportBase
    {
        protected override void PrepareData(DataGridView dgv)
        {
            // Prepare data for Excel export
        }

        protected override void SaveFile(DataGridView dgv, string fileName)
        {
            var app = new Microsoft.Office.Interop.Excel.Application();
            var workbook = app.Workbooks.Add(Type.Missing);
            var worksheet = workbook.ActiveSheet;
            worksheet.Name = "Excel WorkSheet";

            // Add headers to the worksheet
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }

            // Add data to the worksheet
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    var cellValue = dgv.Rows[i].Cells[j].Value;
                    var cellText = cellValue != null ? cellValue.ToString() : string.Empty;
                    worksheet.Cells[i + 2, j + 1] = cellText;
                }
            }

            workbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            app.Quit();
        }

        protected override string GetSuccessMessage()
        {
            return "Excel exported successfully";
        }
    }
}

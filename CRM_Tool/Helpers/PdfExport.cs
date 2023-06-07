using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_Tool.Helpers
{
    public class PdfExport : ExportBase
    {
        protected override void PrepareData(DataGridView dgv)
        {
            // Prepare data for PDF export
        }

        protected override void SaveFile(DataGridView dgv, string fileName)
        {
            var pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            try
            {
                PdfWriter.GetInstance(pdfDoc, new FileStream(fileName, FileMode.Create));

                pdfDoc.Open();

                // Create PDF table
                PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
                pdfTable.DefaultCell.Padding = 1;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;
                pdfTable.SpacingBefore = 10;

                // Add headers to the PDF table
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }

                // Add data rows to the PDF table
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string cellValue = cell.Value != null ? cell.Value.ToString() : string.Empty;
                        pdfTable.AddCell(new Phrase(cellValue));
                    }
                }

                // Add the PDF table to the document
                pdfDoc.Add(pdfTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pdfDoc.Close();
            }
        }

        protected override string GetSuccessMessage()
        {
            return "PDF exported successfully";
        }
    }
}

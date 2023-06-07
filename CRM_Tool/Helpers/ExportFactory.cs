using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Tool.Helpers
{
    public class ExportFactory
    {
        public enum ExportType
        {
            Pdf,
            Excel
        }

        public static ExportBase CreateExport(ExportType type)
        {
            switch (type)
            {
                case ExportType.Pdf:
                    return new PdfExport();
                case ExportType.Excel:
                    return new ExcelExport();
                default:
                    throw new ArgumentException("Invalid export type.");
            }
        }
    }
}

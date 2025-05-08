using Automation_Framework.DataLibraries.DataVariables;
using Bytescout.Spreadsheet;

namespace Automation_Framework.Utilities
{
    public class ExcelReader
    {
        private static string sheetName = "TestSheet";
        private static string excelfilePath = GetFilePath.FilePath(@"DataLibraries\DataFiles\TestData.xlsx");

        public static void ReadExcelData()
        {
            Spreadsheet document = new Spreadsheet();
            document.LoadFromFile(excelfilePath);
            Worksheet worksheet = document.Workbook.Worksheets.ByName(sheetName);

            int rowCount = worksheet.UsedRangeRowMax;
            int columnCount = worksheet.UsedRangeColumnMax;
            string cellValue;
            string ColumnName;

            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 0; j <= columnCount; j++)
                {
                    if ((cellValue = worksheet.Cell(i, 0).ToString()) == "1")
                    {
                        cellValue = worksheet.Cell(i, j).ToString();
                        ColumnName = worksheet.Cell(0, j).ToString().ToLower();
                        StoreDataValuesToVariables.SetVariablesWithValues(sheetName, ColumnName, cellValue);
                    }
                }
            }
            document.Close();
        }
    }
}

using ClosedXML.Excel;
using Serilog;

namespace regalinspection.test.Data
{
    public class ExcelDataReader
    {
        private readonly string filePath;
        private readonly string sheetName;

        public ExcelDataReader(string filePath, string sheetName = "Sheet1")
        {
            this.filePath = filePath;
            this.sheetName = sheetName;
        }

        public IEnumerable<(string username, string password, int row)> GetCredentials(int startRow, int endRow)
        {
            var credentialsList = new List<(string username, string password, int row)>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(sheetName);

                for (int row = startRow; row <= endRow; row++)
                {
                    var cellValue = worksheet.Cell(row, 7).GetString();
                    if (string.IsNullOrEmpty(cellValue)) continue;

                    var credentials = cellValue.Split('\n');
                    if (credentials.Length != 2)
                    {
                        Log.Warning("Skipping row {Row}: Invalid format", row);
                        continue;
                    }

                    string username = credentials[0].Trim();
                    string password = credentials[1].Trim();
                    credentialsList.Add((username, password, row));
                }

                workbook.Save();
            }

            return credentialsList;
        }
        public (string username, string password, int row)? GetCredential(int row)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(sheetName);

                var cellValue = worksheet.Cell(row, 7).GetString();
                if (string.IsNullOrEmpty(cellValue))
                {
                    Log.Information("Row {Row}: No data found", row);
                    return null;
                }

                var credentials = cellValue.Split('\n');
                if (credentials.Length != 2)
                {
                    Log.Warning("Row {Row}: Invalid format", row);
                    workbook.Save();
                    return null;
                }

                string username = credentials[0].Trim();
                string password = credentials[1].Trim();

                return (username, password, row);
            }
        }
        public void UpdateResult(int row, string result)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(sheetName);
                worksheet.Cell(row, 6).Value = result;
                workbook.Save();
            }
        }
    }
}

namespace Automation_Framework.DataLibraries.DataVariables
{
    internal class StoreDataValuesToVariables
    {
        public static string UserName;
        public static string Password;
        public static void SetVariablesWithValues(string sheetName, string columnName, string cellValue)
        {
            if (sheetName == "TestSheet")
            {
                if (columnName == "username") UserName = cellValue;
                if (columnName == "password") Password = cellValue;

            }
        }

        public static void SetVariablesWithValues(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}

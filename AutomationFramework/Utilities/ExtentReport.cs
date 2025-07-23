using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace AutomationFramework.Utilities
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;
        public static ScenarioContext _scenarioContext;

        public static string datestamp = DateTime.Now.ToString("yyyyMMdd");
        public static string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        public static string testResultPath = GetFilePath.FilePath(@"TestReports\" + datestamp + @"\TestReport_"+ timestamp +".html");

        public static void ExtentReportSetup()
        {
            var htmlReporter = new ExtentSparkReporter(testResultPath);
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }
    }
}

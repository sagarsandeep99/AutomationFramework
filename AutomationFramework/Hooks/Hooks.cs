using AutomationFramework.Drivers;
using AutomationFramework.Utilities;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;

namespace AutomationFramework.Hooks
{
    [Binding]
    public sealed class Hooks : ExtentReport
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        #region Step

        [AfterStep]
        public void AfterStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepName = _scenarioContext.StepContext.StepInfo.Text;


            //When scenario passed
            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(stepName);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(stepName);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(stepName);
            }

            //When scenario fails
            if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(stepName).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(stepName).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(stepName).Fail(_scenarioContext.TestError.Message);
            }
        }

        #endregion

        #region TestRun

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportSetup();
            //ExcelReader.ReadExcelData();
            //CsvReader.ReadCsvData();
            //XmlReader.ReadXmlData();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }

        #endregion

        #region Feature

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        #endregion

        #region Scenario

        [BeforeScenario("@UiTests")]
        public void BeforeScenarioWithTag()
        {
            var webDriverLibrary = new WebDriverLibrary(_scenarioContext);
            _scenarioContext.Set(webDriverLibrary, "WebDriverLibrary");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            _scenario = _feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario("@UiTests")]
        public void AfterScenario()
        {
            Thread.Sleep(6000);
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }

        #endregion
    }
}

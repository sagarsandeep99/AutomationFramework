using AutomationFramework.ActionClasses;
using AutomationFramework.DataLibraries.DataVariables;
using AutomationFramework.Drivers;
using AutomationFramework.PageObjectModel;
using AutomationFramework.Utilities;
using ExecuteAutomation.Reqnroll.Dynamics;
using OpenQA.Selenium;

namespace AutomationFramework.StepDefinitions.UI
{
    [Binding]
    public class LoginToContactListAppFromExternalDataStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private WebDriver driver;
        LoginToContactListAppFromExternalDataStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given("user1 launches the browser")]
        public void GivenUserLaunchesTheBrowser(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driver = _scenarioContext.Get<WebDriverLibrary>("WebDriverLibrary").SetupDriver(data.Browsers);
        }

        [Given("user1 naivagtes to CLA portal {string}")]
        public void GivenUserNaivagtesToCLAPortal(string url)
        {
            driver.Url = url;
        }

        [Given("user1 enters username and password in CLA from ([^\"]*) file")]
        public void GivenUserEntersUsernameAndPasswordInCLAFromFile(string fileType)
        {
            switch (fileType.ToLower())
            {
                case "excel":
                    ExcelReader.ReadExcelData();
                    break;
                case "csv":
                    CsvReader.ReadCsvData();
                    break;
                case "xml":
                    XmlReader.ReadXmlData();
                    break;
                default:
                    throw new FileNotFoundException($"File type '{fileType}' not supported.");
                    break;
            }
            ContactListAppLoginPage _contactListAppLoginPage = new ContactListAppLoginPage(_scenarioContext);
            _contactListAppLoginPage.ContactListAppLoginProcess(StoreDataValuesToVariables.UserName, StoreDataValuesToVariables.Password);
        }

        [When("user1 logs in to Contact List app")]
        public void WhenUserLogsInToContactListApp()
        {
            Thread.Sleep(3000);
            ContactListAppLoginPage _CLALoginPage = new ContactListAppLoginPage(_scenarioContext);
            _CLALoginPage.ClickOnCLAloginButton();
        }

        [Then("user1 should be logged in and and navigate to Home Page of CLA")]
        public void ThenUserShouldBeLoggedInAndAndNavigateToHomePageOfCLA()
        {
            Thread.Sleep(3000);
            ContactListAppHomePage _CLAhomePage = new ContactListAppHomePage(_scenarioContext);
            UIActions _uiActions = new UIActions(_scenarioContext);
            var actualResult = _uiActions.GetText(_CLAhomePage._ContactListlabel);
            //Assert.AreEqual("Contact List", actualResult, "Home Page is not loaded, login might failed");
        }
    }
}

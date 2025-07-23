using System;
using AutomationFramework.ActionClasses;
using AutomationFramework.DataLibraries.DataVariables;
using AutomationFramework.Drivers;
using AutomationFramework.PageObjectModel;
using ExecuteAutomation.Reqnroll.Dynamics;
using OpenQA.Selenium;

namespace AutomationFramework.StepDefinitions.UI
{
    [Binding]
    public class LoginToGmailfromExternalDataStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
        public LoginToGmailfromExternalDataStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given("user1 launches browser")]
        public void GivenUserLaunchesBrowser(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driver = _scenarioContext.Get<WebDriverLibrary>("WebDriverLibrary").SetupDriver(data.Browsers);
        }

        [Given("user1 naivagtes to gmail portal {string}")]
        public void GivenUserNaivagtesToGmailPortal(string url)
        {
            driver.Url = url;
        }

        [Given("user1 enters username and password")]
        public void GivenUserEntersUsernameAndPassword()
        {
            GmailLoginPage _gmailLoginPage = new GmailLoginPage(_scenarioContext);
            _gmailLoginPage.GmailLoginProcess(StoreDataValuesToVariables.UserName, StoreDataValuesToVariables.Password);
        }

        [When("user1 clicks on login button")]
        public void WhenUserClicksOnLoginButton()
        {
            Thread.Sleep(3000);
            GmailLoginPage _gmailLoginPage = new GmailLoginPage(_scenarioContext);
            _gmailLoginPage.ClickOnGmailloginButton();
        }

        [Then("user1 should be logged in and and navigate to Home Page")]
        public void ThenUserShouldBeLoggedInAndAndNavigateToHomePage()
        {
            Thread.Sleep(3000);
            HomePage _homePage = new HomePage(_scenarioContext);
            UIActions _uiActions = new UIActions(_scenarioContext);
            var actualResult = _uiActions.GetText(_homePage._inboxLink).ToLower();
            //Assert.AreEqual("inbox", actualResult);
        }
    }
}

using System;
using AutomationFramework.ActionClasses;
using AutomationFramework.Drivers;
using AutomationFramework.PageObjectModel;
using ExecuteAutomation.Reqnroll.Dynamics;
using OpenQA.Selenium;

namespace AutomationFramework.StepDefinitions.UI
{
    [Binding]
    public sealed class LoginToGmailStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        public LoginToGmailStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        #region Given

        [Given("user launches browser")]
        public void GivenUserLaunchesBrowser(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driver = _scenarioContext.Get<WebDriverLibrary>("WebDriverLibrary").SetupDriver(data.Browsers);
        }

        [Given("user naivagtes to gmail portal {string}")]
        public void GivenUserNaivagtesToGmailPortal(string url)
        {
            driver.Url = url;
        }

        [Given("user enters username and password")]
        public void GivenUserEntersUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            GmailLoginPage _loginPage = new GmailLoginPage(_scenarioContext);
            _loginPage.GmailLoginProcess(data.UserName, data.Password);
        }

        #endregion

        #region When

        [When("user clicks on login button")]
        public void WhenUserClicksOnLoginButton()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button//span[text()='Next']")).Click();
        }

        #endregion

        #region Then

        [Then("user should be logged in and and navigate to Home Page")]
        public void ThenUserShouldBeLoggedInAndAndNavigateToHomePage()
        {
            Thread.Sleep(3000);
            HomePage _homePage = new HomePage(_scenarioContext);
            UIActions _uiActions = new UIActions(_scenarioContext);
            var actualResult = _uiActions.GetText(_homePage._inboxLink).ToLower();
            //Assert.AreEqual("inbox", actualResult);
        }

        #endregion

    }
}

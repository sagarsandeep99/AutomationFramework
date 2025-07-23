using System;
using AutomationFramework.ActionClasses;
using AutomationFramework.Drivers;
using AutomationFramework.PageObjectModel;
using ExecuteAutomation.Reqnroll.Dynamics;
using OpenQA.Selenium;

namespace AutomationFramework.StepDefinitions.UI
{
    [Binding]
    public class LoginToContactListAppStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
        public LoginToContactListAppStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given("user launches the browser")]
        public void GivenUserLaunchesTheBrowser(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            //driver = _scenarioContext.Get<WebDriverLibrary>("WebDriverLibrary").Setup(data.Browsers);
            driver = _scenarioContext.Get<WebDriverLibrary>("WebDriverLibrary").SetupDriver(data.Browsers);
        }

        [Given("user naivagtes to CLA portal {string}")]
        public void GivenUserNaivagtesToCLAPortal(string url)
        {
            driver.Url = url;
        }

        [Given("user enters username and password in CLA")]
        public void GivenUserEntersUsernameAndPasswordInCLA(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            ContactListAppLoginPage _CLALoginPage = new ContactListAppLoginPage(_scenarioContext);
            _CLALoginPage.ContactListAppLoginProcess(data.UserName, data.Password);

            //ContactListAppLoginPage _CLALoginPage = new ContactListAppLoginPage(_scenarioContext);
            //_CLALoginPage.ContactListAppLoginProcess(StoreDataValuesToVariables.UserName, StoreDataValuesToVariables.Password);
        }

        [When("user logs in to Contact List app")]
        public void WhenUserLogsInToContactListApp()
        {
            Thread.Sleep(3000);
            ContactListAppLoginPage _CLALoginPage = new ContactListAppLoginPage(_scenarioContext);
            _CLALoginPage.ClickOnCLAloginButton();
        }

        [Then("user should be logged in and and navigate to Home Page of CLA")]
        public void ThenUserShouldBeLoggedInAndAndNavigateToHomePageOfCLA()
        {
            Thread.Sleep(3000);
            ContactListAppHomePage _CLAhomePage = new ContactListAppHomePage(_scenarioContext);
            UIActions _uiActions = new UIActions(_scenarioContext);
            var actualResult = _uiActions.GetText(_CLAhomePage._ContactListlabel);
            //Assert.AreEqual("Contact List", actualResult);
        }
    }
}

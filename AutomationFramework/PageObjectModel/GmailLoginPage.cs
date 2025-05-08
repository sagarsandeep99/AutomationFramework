using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_Framework.ActionClasses;
using OpenQA.Selenium;

namespace Automation_Framework.PageObjectModel
{
    internal class GmailLoginPage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UIActions _uiActions;

        private readonly By _userName = By.Id("identifierId");
        private readonly By _password = By.XPath("//input[@name='Passwd']");
        private readonly By _nextForUserName = By.XPath("//button//span[text()='Next']");
        private readonly By _loginButton = By.XPath("//button//span[text()='Next']");

        public GmailLoginPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _uiActions = new UIActions(_scenarioContext);
        }

        public void GmailLoginProcess(string userName, string password)
        {
            _uiActions.GiveInput(_userName, userName);
            _uiActions.Click(_nextForUserName);
            Thread.Sleep(5000);
            _uiActions.GiveInput(_password, password);
        }

        public void ClickOnGmailloginButton()
        {
            _uiActions.Click(_loginButton);
        }
    }
}

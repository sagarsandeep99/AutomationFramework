using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.ActionClasses;
using OpenQA.Selenium;

namespace AutomationFramework.PageObjectModel
{
    internal class ContactListAppLoginPage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UIActions _uiActions;

        private readonly By _userNameCLA = By.Id("email");
        private readonly By _passwordCLA = By.Id("password");
        private readonly By _loginButtonCLA = By.Id("submit");

        public ContactListAppLoginPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _uiActions = new UIActions(_scenarioContext);
        }

        public void ContactListAppLoginProcess(string userName, string password)
        {
            _uiActions.GiveInput(_userNameCLA, userName);
            Thread.Sleep(3000);
            _uiActions.GiveInput(_passwordCLA, password);
        }

        public void ClickOnCLAloginButton()
        {
            _uiActions.Click(_loginButtonCLA);
        }
    }
}

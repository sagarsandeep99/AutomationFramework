using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.ActionClasses;
using OpenQA.Selenium;

namespace AutomationFramework.PageObjectModel
{
    internal class HomePage
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly UIActions _uiActions;
        public HomePage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //_uiActions = new UIActions(_scenarioContext);
        }

        public readonly By _inboxLink = By.XPath("//a[text()='Inbox']");
    }
}

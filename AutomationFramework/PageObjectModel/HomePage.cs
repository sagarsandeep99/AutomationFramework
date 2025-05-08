using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_Framework.ActionClasses;
using OpenQA.Selenium;

namespace Automation_Framework.PageObjectModel
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

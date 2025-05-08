using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Automation_Framework.ActionClasses
{
    class UIActions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public UIActions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void WindowMaximize()
        {
            _driver.Manage().Window.Maximize();
        }

        public void Clear(By element)
        {
            _driver.FindElement(element).Clear();
        }

        public void Click(By element)
        {
            _driver.FindElement(element).Click();
        }

        public void GiveInput(By element, string input)
        {
            _driver.FindElement(element).SendKeys(input);
        }

        public string GetText(By element)
        {
            return _driver.FindElement(element).Text;
        }

        public int Count(By element)
        {
            return _driver.FindElements(element).Count;
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public void ImplicitlyWait(int timeoutInSeconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSeconds);
        }

        public void WebDriverWait(By element, int timeoutInSeconds, string errorMessage)
        {
            try
            {
                if (timeoutInSeconds > 0)
                    new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds))
                        .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
            }
            catch (Exception e)
            {
                Console.WriteLine(e + ": Unable to load " + errorMessage + "element");
                throw;
            }
        }

        public void MouseHoverOver(By element)
        {
            var webElement = _driver.FindElement(element);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(webElement).Perform();
        }

        public void ScrollUp()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scroll(0,0);");
        }

        public void ScrollDown()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scroll(0,10000);");
        }

        public void Quit()
        {
            _driver.Quit();
        }
    }
}

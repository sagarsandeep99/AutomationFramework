using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace AutomationFramework.Drivers
{
    internal class WebDriverLibrary
    {
        private readonly ScenarioContext _scenarioContext;

        public WebDriverLibrary(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Setup(string browserName)
        {
            var capability = GetBrowserOptions(browserName);
            var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability.ToCapabilities());

            _scenarioContext.Set(driver, "WebDriver");

            return driver;
        }

        public IWebDriver SetupDriver(string browserName)
        {
            IWebDriver driver = GetBrowser(browserName);
            driver.Manage().Window.Maximize();
            _scenarioContext.Set(driver, "WebDriver");
            return driver;
        }

        private dynamic GetBrowserOptions(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    return new ChromeOptions();
                case "firefox":
                    return new FirefoxOptions();
                case "edge":
                    return new EdgeOptions();
                case "safari":
                    return new SafariOptions();
                default:
                    return new Exception("No browser found");
            }
        }


        private dynamic GetBrowser(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "edge":
                    return new EdgeDriver();
                case "safari":
                    return new SafariDriver();
                default:
                    return new Exception("No browser found");
            }
        }
    }
}
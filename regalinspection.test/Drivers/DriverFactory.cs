using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace regalinspection.test.Drivers
{
    public static class DriverFactory
    {
        private static IWebDriver? _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = CreateDriver();
            }
            return _driver;
        }

        private static IWebDriver CreateDriver()
        {
            var driver = new ChromeOptions();
            return new ChromeDriver(driver);
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}
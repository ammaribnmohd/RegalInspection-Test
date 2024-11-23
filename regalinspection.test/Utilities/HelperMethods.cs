using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using regalinspection.test.Data;
namespace regalinspection.test.Utilities
{
    public static class HelperMethods
    {
        public static void SignInButtonClick(this IWebElement locator)
        {
            locator.Submit();
        }
        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }
        public static void SelectDropdownOption(this IWebElement dropdown, string value)
        {
            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText(value);
        }
        public static void NavigateToUrl(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}

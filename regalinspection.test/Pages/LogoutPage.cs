using OpenQA.Selenium;

namespace regalinspection.test.Pages
{
    public class LogoutPage
    {
        private readonly IWebDriver driver;

        public LogoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement UserInfoButton => driver.FindElement(By.CssSelector(".user-details"));
        IWebElement LogoutButton => driver.FindElement(By.XPath("//button[.//mat-icon[text()='logout']]"));


        public void Logout()
        {

            UserInfoButton.Click();
            LogoutButton.Click();
        }
    }
}

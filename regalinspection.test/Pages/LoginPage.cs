using OpenQA.Selenium;
using regalinspection.test.Utilities;

namespace regalinspection.test.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement TxtUserName => driver.FindElement(By.Id("username"));
        IWebElement TxtPassword => driver.FindElement(By.Id("password"));
        IWebElement BtnLogin => driver.FindElement(By.ClassName("submit-button"));
        IWebElement DashboardOption => driver.FindElement(By.XPath("//a[@routerlink='/dashboard']"));
        IWebElement LoginErrorMessage => driver.FindElement(By.ClassName("error"));

        public void Login(string username, string password)
        {
            TxtUserName.EnterText(username);
            TxtPassword.EnterText(password);
            BtnLogin.SignInButtonClick();
        }

        public bool IsDashboardVisible()
        {
            try
            {
                return DashboardOption.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsLoginErrorMessageVisible()
        {
            try
            {
                return LoginErrorMessage.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

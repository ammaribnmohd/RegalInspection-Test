using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using regalinspection.test.Pages;
using regalinspection.test.Utilities;
using Serilog;

namespace regalinspection.test.Drivers
{
    [AllureNUnit]
    [AllureSuite("DriverManagement")]
    public static class DriverManager
    {
        public static void NavigateToLoginPage()
        {
            var driver = DriverFactory.GetDriver();
            driver.NavigateToUrl("https://regaldev.ddns.net/login");
            driver.Manage().Window.Maximize();
        }

        public static void Logout()
        {
            var driver = DriverFactory.GetDriver();
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.Logout();
        }

    }
}
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using NUnit.Allure.Core;
using regalinspection.test.Drivers;
using regalinspection.test.Pages;
using Serilog;

namespace regalinspection.test.TestCases
{
    [AllureSuite("LoginTests")]
    public class LoginTests : BaseTests
    {
        [Test]
        [AllureFeature("Login Test with valid credentials")]
        public void LoginWithValidCredentials()
        {
            Log.Information("Starting LoginWithValidCredentials test...");

            var credentialsList = excelDataReader.GetCredentials(51, 55);
            foreach (var (username, password, row) in credentialsList)
            {
                try
                {
                    Log.Information($"Attempting login with valid credentials for row {row} with username: {username} and password: {password}");
                    LoginPage loginPage = new LoginPage(DriverFactory.GetDriver());

                    loginPage.Login(username, password);
                    Thread.Sleep(3000);
                    bool isDashboardVisible = AllureLifecycle.Instance.WrapInStep(() => loginPage.IsDashboardVisible(), "Check if dashboard is visible");
                    if (isDashboardVisible)
                    {
                        Log.Information($"Login successful for row {row}");
                        AllureLifecycle.Instance.WrapInStep(() => { }, "Login Successful");
                    }
                    else
                    {
                        Log.Warning($"Login failed for row {row}");
                        AllureLifecycle.Instance.WrapInStep(() => { }, "Login Failed - Invalid credentials");
                    }
                    DriverManager.Logout();
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error encountered during valid login test for row {row}");
                }
            }
        }
        [Test]
        [AllureFeature("Login Test with Invalid Credentials")]
        public void LoginWithInvalidCredentials()
        {
            Log.Information("Starting LoginWithInvalidCredentials test...");
            var credential = excelDataReader.GetCredential(56);

            if (credential.HasValue)
            {
                var (username, password, row) = credential.Value;

                try
                {
                    Log.Information($"Attempting login with invalid credentials for row {row} with username: {username} and password: {password}");
                    LoginPage loginPage = new LoginPage(DriverFactory.GetDriver());

                    loginPage.Login(username, password);
                    Thread.Sleep(3000);

                    bool isErrorMessageVisible = AllureLifecycle.Instance.WrapInStep(() => loginPage.IsLoginErrorMessageVisible(), "Check if login error message is visible");

                    if (isErrorMessageVisible)
                    {
                        Log.Information($"Login correctly failed for row {row} - Error message is visible");
                        AllureLifecycle.Instance.WrapInStep(() => { }, "Login failed as expected");
                    }
                    else
                    {
                        Log.Warning($"Unexpected success or error message not visible for row {row}");
                        AllureLifecycle.Instance.WrapInStep(() => { }, "Unexpected login result");
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error encountered during invalid login test for row {row}");
                }
            }
            else
            {
                Log.Warning("No valid credentials found for the specified row.");
            }
        }
        public void LoginWithSingleCredential(int row)
        {
            var credential = excelDataReader.GetCredential(row);

            if (credential.HasValue)
            {
                var (username, password, actualRow) = credential.Value;

                try
                {
                    Log.Information("Attempting login with credentials for row {Row} with username: {Username} and password: {Password}", actualRow, username, password);
                    LoginPage loginPage = new LoginPage(DriverFactory.GetDriver());

                    loginPage.Login(username, password);
                    Thread.Sleep(3000);

                    bool isDashboardVisible = AllureLifecycle.Instance.WrapInStep(() => loginPage.IsDashboardVisible(), "Check if dashboard is visible");

                    if (isDashboardVisible)
                    {
                        Log.Information($"Login successful for row {row}");
                        AllureLifecycle.Instance.WrapInStep(() => { }, "Login Successful");
                    }
                    else
                    {
                        Log.Warning($"Login failed for row {row}");

                        AllureLifecycle.Instance.WrapInStep(() => { }, "Login Failed - Invalid credentials");
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error encountered during login test for row {Row}", actualRow);
                }
            }
            else
            {
                Log.Warning("No valid credentials found for the specified row {Row}.", row);
            }
        }
    }
}

using NUnit.Allure.Core;
using regalinspection.test.Data;
using regalinspection.test.Drivers;
using regalinspection.test.Logging;
using Serilog;

namespace regalinspection.test.TestCases
{
    [AllureNUnit]
    public class BaseTests
    {
        protected ExcelDataReader excelDataReader { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            LoggerConfig.InitializeLogger();
            DriverManager.NavigateToLoginPage();
            excelDataReader = new ExcelDataReader(@"F:\Work\Testing-regal\Regal-test\regalinspection.test\regalinspection.test\Data\QA_Checklist.xlsx");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Log.Information("Tests completed.");
            DriverFactory.QuitDriver();
            Log.CloseAndFlush();
        }
    }
}

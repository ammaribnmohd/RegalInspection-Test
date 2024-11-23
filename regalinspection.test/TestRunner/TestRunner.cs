using NUnit.Engine;
using regalinspection.test.Logging;
using regalinspection.test.TestCases;
using Serilog;
using System.Xml;

namespace regalinspection.test
{
    public class TestRunner
    {
        public static void Main(string[] args)
        {
            LoggerConfig.InitializeLogger();
            Log.Information("Starting test execution in TestRunner for LoginTests and SubmitFormTests suites...");

            try
            {
                // Initialize NUnit engine
                ITestEngine engine = TestEngineActivator.CreateInstance();

                // Get the assembly location for the test classes
                string testAssemblyPath = typeof(LoginTests).Assembly.Location;

                // Create a single test package for the entire assembly
                var testPackage = new TestPackage(testAssemblyPath);

                // Get the runner for the test package
                ITestRunner runner = engine.GetRunner(testPackage);

                // Create filters for each test suite
                TestFilterBuilder filterBuilder = new TestFilterBuilder();

                filterBuilder.SelectWhere("class == 'regalinspection.test.TestCases.LoginTests'");
                TestFilter loginTestsFilter = filterBuilder.GetFilter();

                filterBuilder = new TestFilterBuilder();
                filterBuilder.SelectWhere("class == 'regalinspection.test.TestCases.SubmitFormTests'");
                TestFilter submitFormTestsFilter = filterBuilder.GetFilter();

                // Run the LoginTests suite
                Log.Information("Executing LoginTests...");
                XmlNode loginTestsResults = runner.Run(null, loginTestsFilter);
                Log.Information("Completed LoginTests execution.");
                ProcessTestResults(loginTestsResults, "LoginTests");

                // Run the SubmitFormTests suite
                Log.Information("Executing SubmitFormTests...");
                XmlNode submitFormTestsResults = runner.Run(null, submitFormTestsFilter);
                Log.Information("Completed SubmitFormTests execution.");
                ProcessTestResults(submitFormTestsResults, "SubmitFormTests");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred during test execution in TestRunner.");
            }
            finally
            {
                Log.Information("Test execution completed in TestRunner for LoginTests and SubmitFormTests suites.");
                Log.CloseAndFlush();
            }
        }

        private static void ProcessTestResults(XmlNode resultNode, string suiteName)
        {
            Log.Information($"Processing test results for {suiteName}...");

            foreach (XmlNode testResult in resultNode.SelectNodes("//test-case"))
            {
                var testName = testResult.Attributes["fullname"]?.Value;
                var resultStatus = testResult.Attributes["result"]?.Value;
                var message = testResult.SelectSingleNode("failure/message")?.InnerText;

                if (resultStatus == "Passed")
                {
                    Log.Information($"Test {testName} in {suiteName} passed.");
                }
                else if (resultStatus == "Failed")
                {
                    Log.Error($"Test {testName} in {suiteName} failed - {message}");
                }
                else
                {
                    Log.Warning($"Test {testName} in {suiteName} status: {resultStatus}");
                }
            }

            Log.Information($"Completed processing test results for {suiteName}.");
        }
    }
}

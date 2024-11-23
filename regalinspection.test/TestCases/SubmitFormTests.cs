using regalinspection.test.Drivers;
using regalinspection.test.Pages;
using NUnit.Framework;
using Allure.NUnit.Attributes;
using Serilog;
using Allure.Net.Commons;
using NUnit.Allure.Core;

namespace regalinspection.test.TestCases
{
    [AllureSuite("SubmitFormTests")]
    public class SubmitFormTests : BaseTests
    {
        [Test]
        [AllureFeature("Submit Inspection Form with Valid Data")]
        public void SubmitValidInspectionForm()
        {
            try
            {
                Log.Information("Starting SubmitValidInspectionForm test...");

                // Test data for multiple rows
                var testData = new[]
                {
                    new
                    {
                        RowId = 55,
                        OrderedBy = "Emily Clark",
                        Underwriter = "Michael Brown",
                        OrderDate = "18-11-2024",
                        DueDate = "19-11-2024",
                        Insured = "Beta Corp",
                        Address = "456 Elm St",
                        City = "Los Angeles",
                        State = "California",
                        Zip = "90210",
                        ContactName = "Chris Evans",
                        ContactPhone = "3105554321",
                        ContactEmail = "chris@beta.com",
                        Carrier = "Allianz",
                        PolicyNumber = "987654",
                        BusinessType = "Retail",
                        AgentName = "Robert Martinez",
                        AgentPhone = "3105556789",
                        AgentEmail = "robert@agency.com",
                        BuildingValue = "750000",
                        SpecialRequest = "Urgent processing needed",
                        ExpectedToasterMessage = "Inspection form submitted successfully"

                    },
                    new
                    {
                        RowId = 54,
                        OrderedBy = "John Doe",
                        Underwriter = "Jane Smith",
                        OrderDate = "17-11-2024",
                        DueDate = "19-11-2024",
                        Insured = "ACME Corp",
                        Address = "123 Main St",
                        City = "New York",
                        State = "New York",
                        Zip = "52701",
                        ContactName = "Bob Wilson",
                        ContactPhone = "3105854321",
                        ContactEmail = "bob@acme.com",
                        Carrier = "State Farm",
                        PolicyNumber = "123456",
                        BusinessType = "Manufacturing",
                        AgentName = "Alice Johnson",
                        AgentPhone = "2175559876",
                        AgentEmail = "alice@agency.com",
                        BuildingValue = "500000",
                        SpecialRequest = "Priority inspection needed",
                        ExpectedToasterMessage = "Inspection form submitted successfully"
                    }
                };

                foreach (var data in testData)
                {
                    Log.Information("Processing test data for RowId: {RowId}", data.RowId);
                    var loginTests = new LoginTests();
                    loginTests.OneTimeSetup();
                    AllureLifecycle.Instance
                        .WrapInStep(() => loginTests.LoginWithSingleCredential(data.RowId),$"Login with credentials for RowId: {data.RowId}");
                   
                    Thread.Sleep(1000);

                    var submitFormPage = new SubmitFormPage(DriverFactory.GetDriver());


                    AllureLifecycle.Instance.WrapInStep(() => submitFormPage.clickOnSubmitNew(), "Click on Submit New Form");

                    AllureLifecycle.Instance.WrapInStep(() =>
                    {
                        submitFormPage.FillGeneralInformation(
                            orderedBy: data.OrderedBy,
                            underwriter: data.Underwriter,
                            orderDate: data.OrderDate,
                            dueDate: data.DueDate,
                            insured: data.Insured
                        );
                    }, "Filling General Information");

                    AllureLifecycle.Instance.WrapInStep(() =>
                    {
                        submitFormPage.FillInspectionDetails(
                            address: data.Address,
                            city: data.City,
                            state: data.State,
                            zip: data.Zip,
                            contactName: data.ContactName,
                            contactPhone: data.ContactPhone,
                            contactEmail: data.ContactEmail
                        );
                    }, "Filling Inspection Details");

                    AllureLifecycle.Instance.WrapInStep(() =>
                    {
                        submitFormPage.FillBusinessDetails(
                            carrier: data.Carrier,
                            policyNumber: data.PolicyNumber,
                            businessType: data.BusinessType,
                            agentName: data.AgentName,
                            agentPhone: data.AgentPhone,
                            agentEmail: data.AgentEmail
                        );
                    }, "Filling Business Details");

                    AllureLifecycle.Instance.WrapInStep(() =>
                    {
                        submitFormPage.SetPropertyValues(building: true, buildingValue: data.BuildingValue);
                        submitFormPage.SetLiabilityOptions(cgl: true, products: true);
                        submitFormPage.FillSpecialRequests(specialRequest: data.SpecialRequest, photo: true);
                    }, "Setting Property Values and Liability Options");
                    
                    Thread.Sleep(2000);

                    AllureLifecycle.Instance.WrapInStep(() => submitFormPage.SubmitForm(), "Submitting the Form");
                    Thread.Sleep(5000);
                    // Verify toaster text is displayed after form submission
                    Assert.That(submitFormPage.ToasterText.Displayed, Is.True, "Toaster text is not displayed.");
                    Log.Information("Form submitted successfully for RowId: {RowId}", data.RowId);


                    DriverManager.Logout();
                    Log.Information("Logged out after form submission for RowId: {RowId}", data.RowId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Test failed during SubmitValidInspectionForm execution");
                AllureLifecycle.Instance.WrapInStep(() => throw ex, "Handle Test Exception");
                throw;
            }
        }
    }
}

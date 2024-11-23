using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using regalinspection.test.Utilities;

namespace regalinspection.test.Pages
{
    public class SubmitFormPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;


        public SubmitFormPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        private IWebElement WaitAndFindElement(By by)
        {
            return wait.Until(driver => driver.FindElement(by));
        }

        // Now you can safely use driver in methods
        public IWebElement SubmitNew => WaitAndFindElement(By.CssSelector("a[routerLink='/inspection-form']"));

        // General Information Section
        private IWebElement TxtOrderedBy => WaitAndFindElement(By.CssSelector("input[formControlName='orderedBy']"));
        private IWebElement TxtAgencyName => WaitAndFindElement(By.CssSelector("input[formControlName='agencyName']"));
        private IWebElement TxtUnderwriter => WaitAndFindElement(By.CssSelector("input[formControlName='underwriter']"));
        private IWebElement TxtOrderDate => WaitAndFindElement(By.CssSelector("input[formControlName='orderDate']"));
        private IWebElement TxtDueDate => WaitAndFindElement(By.CssSelector("input[formControlName='dueDate']"));
        private IWebElement TxtInsured => WaitAndFindElement(By.CssSelector("input[formControlName='insured']"));

        // Inspection Details Section Elements
        private IWebElement TxtAddress => WaitAndFindElement(By.CssSelector("input[formControlName='address']"));
        IWebElement DdlCity => WaitAndFindElement(By.CssSelector("select[formControlName='city']"));
        IWebElement DdlState => WaitAndFindElement(By.CssSelector("select[formControlName='state']"));
        private IWebElement TxtZip => WaitAndFindElement(By.CssSelector("input[formControlName='zip']"));
        private IWebElement TxtInsuredContactName => WaitAndFindElement(By.CssSelector("input[formControlName='insuredContactName']"));
        private IWebElement TxtInsuredContactPhone => WaitAndFindElement(By.CssSelector("input[formControlName='insuredContactPhone']"));
        private IWebElement TxtInsuredContactEmail => WaitAndFindElement(By.CssSelector("input[formControlName='insuredContactEmail']"));
        private IWebElement TxtCarrier => WaitAndFindElement(By.CssSelector("input[formControlName='carrier']"));
        private IWebElement TxtPolicyNumber => WaitAndFindElement(By.CssSelector("input[formControlName='policyNumber']"));
        private IWebElement TxtBusinessType => WaitAndFindElement(By.CssSelector("input[formControlName='businessType']"));
        private IWebElement TxtRetailAgentName => WaitAndFindElement(By.CssSelector("input[formControlName='retailAgentName']"));
        private IWebElement TxtRetailAgentPhone => WaitAndFindElement(By.CssSelector("input[formControlName='retailAgentPhone']"));
        private IWebElement TxtRetailAgentEmail => WaitAndFindElement(By.CssSelector("input[formControlName='retailAgentEmail']"));

        // Policy Type Radio Buttons
        //private IWebElement RdoNewPolicy => WaitAndFindElement(By.CssSelector("mat-radio-button[value='NEW_POLICY']"));
        //private IWebElement RdoRenewalPolicy => WaitAndFindElement(By.CssSelector("mat-radio-button[value='RENEWAL']"));

        // Property Checkboxes and Values
        private IWebElement ChkBuilding => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='building']"));
        private IWebElement ChkContents => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='contents']"));
        private IWebElement ChkTimeElement => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='timeElement']"));
        private IWebElement ChkBuilderRisk => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='builderRisk']"));
        private IWebElement ChkAllRisk => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='allRisk']"));

        private IWebElement TxtBuildingValue => WaitAndFindElement(By.CssSelector("input[formControlName='buildingValue']"));
        private IWebElement TxtContentsValue => WaitAndFindElement(By.CssSelector("input[formControlName='contentsValue']"));
        private IWebElement TxtTimeElementValue => WaitAndFindElement(By.CssSelector("input[formControlName='timeElementValue']"));
        private IWebElement TxtBuilderRiskValue => WaitAndFindElement(By.CssSelector("input[formControlName='builderRiskValue']"));
        private IWebElement TxtAllRiskValue => WaitAndFindElement(By.CssSelector("input[formControlName='allRiskValue']"));

        // Liability Checkboxes
        private IWebElement ChkCGL => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='cgl']"));
        private IWebElement ChkOLT => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='olt']"));
        private IWebElement ChkMC => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='mc']"));
        private IWebElement ChkProducts => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='products']"));
        private IWebElement ChkOCP => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='ocp']"));

        // Auto Checkboxes
        private IWebElement ChkFleet => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='fleet']"));
        private IWebElement ChkGarage => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='garage']"));
        private IWebElement ChkGarageKeeper => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='garageKeeper']"));
        private IWebElement TxtAdditionalCoverages => WaitAndFindElement(By.CssSelector("textarea[formControlName='additionalCoverages']"));

        // Special Request Section
        private IWebElement ChkPhoto => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='photo']"));
        private IWebElement ChkPhoneSurvey => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='phoneSurvey']"));
        private IWebElement ChkStandardReport => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='standardReport']"));
        private IWebElement ChkJobsiteInspection => WaitAndFindElement(By.CssSelector("mat-checkbox[formControlName='jobsiteInspection']"));
        private IWebElement TxtSpecialRequest => WaitAndFindElement(By.CssSelector("textarea[formControlName='specialRequest']"));

        // Buttons
        private IWebElement BtnUpload => WaitAndFindElement(By.CssSelector("button[color='primary']"));
        private IWebElement BtnSubmitForm => WaitAndFindElement(By.CssSelector("button.bg-blue-500.text-white"));
        private IWebElement BtnSaveForm => WaitAndFindElement(By.XPath("//button[contains(@class, 'override-button-blue')]//p[text()='Save']"));
        public IWebElement ToasterText => WaitAndFindElement(By.CssSelector("span.toastr-message"));
        public void FillGeneralInformation(string orderedBy, string underwriter, string orderDate, string dueDate, string insured)
        {
            TxtOrderedBy.EnterText(orderedBy);
            TxtUnderwriter.EnterText(underwriter);
            TxtOrderDate.EnterText(orderDate);
            TxtDueDate.EnterText(dueDate);
            TxtInsured.EnterText(insured);
        }
        public void FillInspectionDetails(string address, string city, string state, string zip,
            string contactName, string contactPhone, string contactEmail)
        {
            TxtAddress.EnterText(address);
            DdlCity.SelectDropdownOption(city);
            DdlState.SelectDropdownOption(state);
            TxtZip.EnterText(zip);
            TxtInsuredContactName.EnterText(contactName);
            TxtInsuredContactPhone.EnterText(contactPhone);
            TxtInsuredContactEmail.EnterText(contactEmail);
        }
        public void FillBusinessDetails(string carrier, string policyNumber, string businessType,
            string agentName, string agentPhone, string agentEmail)
        {
            TxtCarrier.EnterText(carrier);
            TxtPolicyNumber.EnterText(policyNumber);
            TxtBusinessType.EnterText(businessType);
            TxtRetailAgentName.EnterText(agentName);
            TxtRetailAgentPhone.EnterText(agentPhone);
            TxtRetailAgentEmail.EnterText(agentEmail);
        }

        public void SetPropertyValues(bool building, string buildingValue = null, bool contents = false, string contentsValue = null,
           bool timeElement = false, string timeElementValue = null)
        {
            if (building)
            {
                ChkBuilding.Click();
                if (!string.IsNullOrEmpty(buildingValue))
                    TxtBuildingValue.EnterText(buildingValue);
            }

            if (contents)
            {
                ChkContents.Click();
                if (!string.IsNullOrEmpty(contentsValue))
                    TxtContentsValue.EnterText(contentsValue);
            }

            if (timeElement)
            {
                ChkTimeElement.Click();
                if (!string.IsNullOrEmpty(timeElementValue))
                    TxtTimeElementValue.EnterText(timeElementValue);
            }
        }

        public void SetLiabilityOptions(bool cgl = false, bool olt = false, bool mc = false,
            bool products = false, bool ocp = false)
        {
            if (cgl) ChkCGL.Click();
            if (olt) ChkOLT.Click();
            if (mc) ChkMC.Click();
            if (products) ChkProducts.Click();
            if (ocp) ChkOCP.Click();
        }

        public void FillSpecialRequests(string specialRequest, bool photo = false,
            bool phoneSurvey = false, bool standardReport = false,
            bool jobsiteInspection = false)
        {
            if (photo) ChkPhoto.Click();
            if (phoneSurvey) ChkPhoneSurvey.Click();
            if (standardReport) ChkStandardReport.Click();
            if (jobsiteInspection) ChkJobsiteInspection.Click();

            if (!string.IsNullOrEmpty(specialRequest))
                TxtSpecialRequest.EnterText(specialRequest);
        }
        public void clickOnSubmitNew()
        {
            SubmitNew.Click();
            wait.Until(driver => driver.Url.Contains("/inspection-form"));
        }
        public void SubmitForm()
        {
            BtnSubmitForm.Click();
            BtnSaveForm.Click();
        }
        public bool IsToasterTextDisplayed(string expectedMessage)
        {
            try
            {
                return ToasterText.Text.Contains(expectedMessage);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}

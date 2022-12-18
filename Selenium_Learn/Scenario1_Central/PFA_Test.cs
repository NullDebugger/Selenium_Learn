using System;
using OpenQA.Selenium.Support.UI;
using Selenium_Learn.BaseClass;

namespace Selenium_Learn.Scenario1_Central
{
	public class PFA_Test: BaseTest
	{
        [Test, Order(11)]
        public void test_diagnosis_container()
        {
            //Enter the data you want to test
            string enter_patient_name = "Central__Scenario1 ttestt";
            string enter_s_o = "?central";
            //Enter the test infortmation
            brow.Set_test_id("11");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient record");
            brow.Set_sub_browser_screen("PFA");
            brow.Set_test_case("Diagnosis container");
            brow.Set_test_scenario("Check whether can enter relevant information on diagnosis container");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("");
            //1. Navigating to specific central patient record page && 2. Adding "?central" to current URL
            goto_patient_record(enter_patient_name, enter_s_o);

            //Wait Time until find the element 
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[3]/a"));
                return true;
            });
            wait.Until(waitForElement);
            //3. Find the element of "PFA"
            By Locator_pfa_tab = By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[3]/a");
            IWebElement pfa_tab = (IWebElement)brow.GetWebDriver.FindElement(Locator_pfa_tab);
            pfa_tab.Click();

            /*
             *  Enter relevant information on diagnosis container
                 Find the element of "Weight" input box
                 Enter data to the "Weight"
                 Find the element of "Height" input box
                 Enter date to "Height"
                 Find the element of "Clinical Reason For Tasking" input box
                 Enter data to the "Clinical Reason For Tasking"
                 Find the element of "Clinical Details (Presenting Illness/Injury)" input box
                 Enter data to the "Clinical Details (Presenting Illness/Injury)"
            */
            Func<IWebDriver, bool> waitForElement_diagnosis = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"f611d4ca-a698-479c-a72d-535b98c305b3\"]"));
                return true;
            });
            wait.Until(waitForElement_diagnosis);

            string enter_weight = "85";
            By Locator_weight = By.XPath("//*[@id=\"f611d4ca-a698-479c-a72d-535b98c305b3\"]");
            IWebElement weight = (IWebElement)brow.GetWebDriver.FindElement(Locator_weight);
            weight.Clear();
            weight.SendKeys(enter_weight);

            string enter_height = "185";
            By Locator_height = By.XPath("//*[@id=\"5b6682b8-5368-4d56-bced-ec59534e3933\"]");
            IWebElement height = (IWebElement)brow.GetWebDriver.FindElement(Locator_height);
            height.Clear();
            height.SendKeys(enter_height);

            string enter_clinical_reason = "Mr Jones has presented with increased abdominal pain, with a 3 day history of fever, nausea, appetite loss, and tachycardia";
            By Locator_clinical_reason = By.XPath("//*[@id=\"6d2d9206-f46f-448c-a037-fa9e2ca13ec2\"]");
            IWebElement clinical_reason = (IWebElement)brow.GetWebDriver.FindElement(Locator_clinical_reason);
            clinical_reason.Clear();
            clinical_reason.SendKeys(enter_clinical_reason);

            string enter_clinical_details =
                "He is being transferred for further assessments and investigations with the working diagnosis of a SBO requiring surgical intervention" +
                "He has not used his bowels in 5 days and aperients have had nil effect" +
                "He has not had any instances of vomiting at this stage";
            By Locator_clinical_details = By.XPath("//*[@id=\"fb990fe4-e8b8-462b-9e79-623c8a4b3b25\"]");
            IWebElement clinical_details = (IWebElement)brow.GetWebDriver.FindElement(Locator_clinical_details);
            clinical_details.Clear();
            clinical_details.SendKeys(enter_clinical_details);

        }

        [Test, Order(12)]
        public void test_medical_history_container()
        {
            //Enter the data you want to test
            string enter_patient_name = "Central__Scenario1 ttestt";
            string enter_s_o = "?central";
            //Enter the test infortmation
            brow.Set_test_id("12");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient record");
            brow.Set_sub_browser_screen("PFA");
            brow.Set_test_case("Past Medical History container");
            brow.Set_test_scenario("Check whether can enter relevant information on diagnosis container");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("");
            //1. Navigating to specific central patient record page && 2. Adding "?central" to current URL
            goto_patient_record(enter_patient_name, enter_s_o);

            //Wait Time until find the element 
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[3]/a"));
                return true;
            });
            wait.Until(waitForElement);
            //3. Find the element of "PFA"
            By Locator_pfa_tab = By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[3]/a");
            IWebElement pfa_tab = (IWebElement)brow.GetWebDriver.FindElement(Locator_pfa_tab);
            pfa_tab.Click();

            /*
                Find the element of "Past Medical History" input box
                Enter the data to "Past Medical History" input box
                Find the element of " Allergy" button
                Click "Allergy" button
                Find the element of "Allergen" input box
                Enter the data to  "Allergen" input box
                Find the element of "Reaction" input box
                Enter the data to "Reaction" input box
                Find the element of "Plus" icon
                Click the"Plus" icon
                Find the element of "Save" Button
                Click the "Save" Button
            */
            Func<IWebDriver, bool> waitForElement_medical_history = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"d4fcdd81-d59b-4ef9-9fe5-bd9e9ce2d4d4\"]"));
                return true;
            });
            wait.Until(waitForElement_medical_history);

            string enter_medical_history = "His past medical history includes: GORD, asthma, T2DM, anxiety, and hypertension";
            By Locator_medical_history = By.XPath("//*[@id=\"d4fcdd81-d59b-4ef9-9fe5-bd9e9ce2d4d4\"]");
            IWebElement medical_history = (IWebElement)brow.GetWebDriver.FindElement(Locator_medical_history);
            medical_history.Clear();
            medical_history.SendKeys(enter_medical_history);

            
            By Locator_btn_allergy = By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[3]/form[4]/div/div/div/div/div/div/div[11]/button");
            IWebElement btn_allergy = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_allergy);
            //btn_allergy.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)brow.GetWebDriver;
            js.ExecuteScript("arguments[0].click()", btn_allergy);

            string enter_allergen = "penicillin";
            By Locator_allergen_input = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[2]/div/table/tfoot/tr/td[2]/input");
            IWebElement allergen_input = (IWebElement)brow.GetWebDriver.FindElement(Locator_allergen_input);
            allergen_input.SendKeys(enter_allergen);

            string enter_reaction = "rash, vomiting, nausea, and blurred vision";
            By Locator_reaction_input = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[2]/div/table/tfoot/tr/td[3]/input");
            IWebElement reaction_input = (IWebElement)brow.GetWebDriver.FindElement(Locator_reaction_input);
            reaction_input.SendKeys(enter_reaction);

            //Click "+" button
            By Locator_puls_btn = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[2]/div/table/tfoot/tr/td[5]/h1/i");
            IWebElement puls_btn = (IWebElement)brow.GetWebDriver.FindElement(Locator_puls_btn);
            puls_btn.Click();

            //Click Save button
            By Locator_save_btn = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[3]/button[2]");
            IWebElement save_btn = (IWebElement)brow.GetWebDriver.FindElement(Locator_save_btn);
            save_btn.Click();
        }

        [Test, Order(13)]
        public void test_advance_care_container() {
            //Enter the data you want to test
            string enter_patient_name = "Central__Scenario1 ttestt";
            string enter_s_o = "?central";
            //Enter the test infortmation
            brow.Set_test_id("13");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient record");
            brow.Set_sub_browser_screen("PFA");
            brow.Set_test_case("Past Medical History container");
            brow.Set_test_scenario("Check whether can enter relevant information on diagnosis container");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("");
            //1. Navigating to specific central patient record page && 2. Adding "?central" to current URL
            goto_patient_record(enter_patient_name, enter_s_o);

            //Wait Time until find the element 
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[3]/a"));
                return true;
            });
            wait.Until(waitForElement);
            //3. Find the element of "PFA"
            By Locator_pfa_tab = By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[3]/a");
            IWebElement pfa_tab = (IWebElement)brow.GetWebDriver.FindElement(Locator_pfa_tab);
            pfa_tab.Click();

            /*
                Find the element of "Advance Care Directive" input box
                Enter data into "Advance Care Directive" input box
             */
            Func<IWebDriver, bool> waitForElement_care_dir = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"9a82b492-0907-4a10-83d2-69eb84c73c7a\"]"));
                return true;
            });
            wait.Until(waitForElement_care_dir);
            string enter_care_directive = "He is for full resus.";
            By Locator_care_directive = By.XPath("//*[@id=\"9a82b492-0907-4a10-83d2-69eb84c73c7a\"]");
            IWebElement care_directive = (IWebElement)brow.GetWebDriver.FindElement(Locator_care_directive);
            care_directive.SendKeys(enter_care_directive);
            //Click full resus button
            By Locator_btn_resus = By.XPath("//*[@id=\"3eb850fc-0036-4b3c-b107-39a07095bdf2\"]");
            IWebElement resus_btn = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_resus);
            //resus_btn.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)brow.GetWebDriver;
            js.ExecuteScript("arguments[0].click()", resus_btn);

        }
    }
}


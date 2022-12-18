using System;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using OpenQA.Selenium.Support.UI;
using Selenium_Learn.BaseClass;

namespace Selenium_Learn.Scenario1_Central
{
	public class New_Medication_Test: BaseTest
	{
		[Test, Order(16)]
		public void test_new_medication() {
            //Enter the data you want to test
            string enter_patient_name = "Central__Scenario1 ttestt";
            string enter_s_o = "?central";
            //Enter the test infortmation
            brow.Set_test_id("16");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient record");
            brow.Set_sub_browser_screen("Medication");
            brow.Set_test_case("New Medication");
            brow.Set_test_scenario("Check whether can order the \"PRN analgesia\"");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("");
            //1. Navigating to specific central patient record page && 2. Adding "?central" to current URL
            goto_patient_record(enter_patient_name, enter_s_o);


            //3. Find the element of "Medication", Click "Medication" tab
            //Wait Time until find the element 
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[5]/a"));
                return true;
            });
            wait.Until(waitForElement);

            By Locator_medication_tab = By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[5]/a");
            IWebElement medication_tab = (IWebElement)brow.GetWebDriver.FindElement(Locator_medication_tab);
            medication_tab.Click();

            /*
                Find the button of "New Medication"
                Click the "New Medication" button
                Find the element of "Name" input box
                Enter data into this input box
                Select the first row of the table
                Find the element of "Dose" input box
                Enter data into this input box
                Find the element of "Dose UML" dropdown
                Select the UNL
                Find the element of "Max Dose" input box
                Enter data into this input box
                Find the element of "Total Dose" input box
                Enter data into this input box
                Find the element of "Total Dose UML" dropdown
                Select the UNL
                Find the element of "Frequency "
                Slected the frequency
                Find the element of "Route"
                Slected the route
                Find the elemnent of "Instruction" input box
                Enter data into this input box
                Find the element of "Prescribe"
                Selected the optioin
                Find the "Save" Button
                Click "Save" button
             */
            //    Find the button of "New Medication"
            //    Click the "New Medication" button
            Func<IWebDriver, bool> waitForElement_btn_new_medication = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[5]/form/div/div/div/div/div/div/div/div/div/div[1]/button"));
                return true;
            });
            wait.Until(waitForElement_btn_new_medication);

            By Locator_btn_new_medication = By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[5]/form/div/div/div/div/div/div/div/div/div/div[1]/button");
            IWebElement btn_new_medication = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_new_medication);
            IJavaScriptExecutor js = (IJavaScriptExecutor)brow.GetWebDriver;
            js.ExecuteScript("arguments[0].click()", btn_new_medication);
            //    Find the element of "Name" input box
            //    Enter data into this input box
            //Name
            Func<IWebDriver, bool> waitForElement_medication_name = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[1]/input"));
                return true;
            });
            wait.Until(waitForElement_medication_name);

            string enter_medication_name = "Fentanyl";
            By Locator_medication_name = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[1]/input");
            IWebElement new_medication_name = (IWebElement)brow.GetWebDriver.FindElement(Locator_medication_name);
            new_medication_name.SendKeys(enter_medication_name);

            //Select the first row of the table
            Func<IWebDriver, bool> waitForElement_radios = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[2]/table/tbody/tr[1]/td[1]/input"));
                return true;
            });
            wait.Until(waitForElement_radios);

            By Locator_medication_name_radio = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[2]/table/tbody/tr[1]/td[1]/input");
            IWebElement medication_name_radio = (IWebElement)brow.GetWebDriver.FindElement(Locator_medication_name_radio);
            js.ExecuteScript("arguments[0].click()", medication_name_radio);
            //    Find the element of "Dose" input box
            //    Enter data into this input box
            string enter_dose = "20";
            By Locator_dose = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[3]/div[1]/input");
            IWebElement dose_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_dose);
            dose_input_box.SendKeys(enter_dose);
            //    Find the element of "Dose UML" dropdown
            //    Select the UNL
            string enter_dose_UML = "microgram";
            By Locator_dose_uml = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[3]/div[2]/div/select");
            IWebElement dose_uml_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_dose_uml);
            dose_uml_input_box.SendKeys(enter_dose_UML);

            //    Find the element of "Max Dose" input box
            //    Enter data into this input box
            string enter_max_dose = "100";
            By Locator_max_dose = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[3]/div[5]/input");
            IWebElement max_dose_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_max_dose);
            max_dose_input_box.SendKeys(enter_max_dose);

            //    Find the element of "Frequency "
            //    Slected the frequency
            string enter_frequency = "other";
            By Locator_frequency = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[4]/div[1]/select");
            IWebElement frequency_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_frequency);
            frequency_input_box.SendKeys(enter_frequency);

            //    Find the element of "Route"
            //    Slected the route
            string enter_route = "IV";
            By Locator_route = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[4]/div[2]/select");
            IWebElement route_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_route);
            route_input_box.SendKeys(enter_route);

            //    Find the elemnent of "Instruction" input box
            //    Enter data into this input box
            string enter_instruction = "can be administered 10 minutely for pain";
            By Locator_instruction = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[4]/div[3]/input");
            IWebElement instruction_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_instruction);
            instruction_input_box.SendKeys(enter_instruction);

            //    Find the element of "Prescribe"
            //    Selected the optioin/
            string enter_prescribe = "In person";
            By Locator_prescribe = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[5]/div[1]/select");
            IWebElement prescribe_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_prescribe);
            prescribe_input_box.SendKeys(enter_prescribe);

            //    Find the "Save" Button
            //    Click "Save" button
            By Locator_btn_save = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[3]/div/button");
            IWebElement btn_save = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_save);
            js.ExecuteScript("arguments[0].click()", btn_save);
        }
	}
}


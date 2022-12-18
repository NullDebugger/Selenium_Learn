using System;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using OpenQA.Selenium.Support.UI;
using Selenium_Learn.BaseClass;

namespace Selenium_Learn.Scenario1_Central
{
	public class New_Intravenous_Fluid_Order_Test: BaseTest
	{
		[Test, Order(15)]
		public void test_new_fluid_order() {
            //Enter the data you want to test
            string enter_patient_name = "Central__Scenario1 ttestt";
            string enter_s_o = "?central";
            //Enter the test infortmation
            brow.Set_test_id("15");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient record");
            brow.Set_sub_browser_screen("Fluids & Drug Infusions");
            brow.Set_test_case("New Intravenous Fluid Order");
            brow.Set_test_scenario("Check whether can order the infusion on the Fluids & Drug Infusions tab  ");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("");
            //1. Navigating to specific central patient record page && 2. Adding "?central" to current URL
            goto_patient_record(enter_patient_name, enter_s_o);


            //3. Find the element of "Fluids & Drug Infusions")
            //Wait Time until find the element 
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[6]/a"));
                return true;
            });
            wait.Until(waitForElement);

            By Locator_fluids_drug_infusions_tab = By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[6]/a");
            IWebElement fluids_drug_infusions_tab = (IWebElement)brow.GetWebDriver.FindElement(Locator_fluids_drug_infusions_tab);
            fluids_drug_infusions_tab.Click();

            /*
                Find the button of "New Intravenous Fluid Order"
                Click the button of "New Intravenous Fluid Order"
                Find the element of "Name" input box
                Enter the keyword on the "Name" input box
                Select the first row of the table
                Find the element of "Rate ml/hr" input box
                Enter date to "Rate ml/hr" input box
                Find the element of "Volumn" input box
                Enter date to "Volumn" input box
                Find the element of "Prescribe method" input box
                Enter date to "Prescribe method" input box
                Find the element of "Save" Button
                Click "Save" button
             */
            Func<IWebDriver, bool> waitForElement_btn_intravenous_fluid_order = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[6]/form/div/div/div/div/div/div/div/div/div[3]/div/div[1]/button"));
                return true;
            });
            wait.Until(waitForElement_btn_intravenous_fluid_order);

            By Locator_btn_intravenous_fluid_order = By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[6]/form/div/div/div/div/div/div/div/div/div[3]/div/div[1]/button");
            IWebElement btn_new_intravenous_fluid_order = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_intravenous_fluid_order);
            IJavaScriptExecutor js = (IJavaScriptExecutor)brow.GetWebDriver;
            js.ExecuteScript("arguments[0].click()", btn_new_intravenous_fluid_order);
            //Name
            Func<IWebDriver, bool> waitForElement_fluid_name = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"lookup-field\"]"));
                return true;
            });
            wait.Until(waitForElement_fluid_name);

            string enter_intravenous_fluid_order_name = "Hartmanns solutio";
            By Locator_intravenous_fluid_order_name = By.XPath("//*[@id=\"lookup-field\"]");
            IWebElement new_intravenous_fluid_order_name = (IWebElement)brow.GetWebDriver.FindElement(Locator_intravenous_fluid_order_name);
            //IJavaScriptExecutor js = (IJavaScriptExecutor)brow.GetWebDriver;
            //js.ExecuteScript("arguments[0].click()", new_intravenous_fluid_order_name);
            new_intravenous_fluid_order_name.SendKeys(enter_intravenous_fluid_order_name);


            Func<IWebDriver, bool> waitForElement_radios = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[2]/table/tbody/tr/td[1]/input"));
                return true;
            });
            wait.Until(waitForElement_radios);

            By Locator_intravenous_fluid_order_name_radio = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[2]/table/tbody/tr/td[1]/input");
            IWebElement intravenous_fluid_order_name_radio = (IWebElement)brow.GetWebDriver.FindElement(Locator_intravenous_fluid_order_name_radio);
            //IJavaScriptExecutor js = (IJavaScriptExecutor)brow.GetWebDriver;
            js.ExecuteScript("arguments[0].click()", intravenous_fluid_order_name_radio);

            //  Find the element of "Rate ml/hr" input box
            //  Enter date to "Rate ml/hr" input box
            string enter_rate = "60";
            By Locator_rate = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[2]/div[1]/input");
            IWebElement rate_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_rate);
            rate_input_box.SendKeys(enter_rate);
            //    Find the element of "Volumn" input box
            //    Enter date to "Volumn" input box
            string enter_volumn = "8";
            By Locator_volumn = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[2]/div[2]/input");
            IWebElement volumn_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_volumn);
            volumn_input_box.SendKeys(enter_volumn);

            string enter_duration_UOM = "Hours(s)";
            By Locator_duration_UOM = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[2]/div[3]/select");
            IWebElement duration_UOM_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_duration_UOM);
            duration_UOM_input_box.SendKeys(enter_duration_UOM);
            //    Find the element of "Prescribe method" input box
            //    Enter date to "Prescribe method" input box
            string enter_prescribe_method = "In person";
            By Locator_prescribe_method = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[2]/div/div[3]/div[4]/div[1]/select");
            IWebElement prescribe_method_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_prescribe_method);
            prescribe_method_input_box.SendKeys(enter_prescribe_method);
            //    Find the element of "Save" Button
            //    Click "Save" button
            By Locator_btn_save = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[3]/div/button");
            IWebElement btn_save = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_save);
            //btn_save.Click();
            js.ExecuteScript("arguments[0].click()", btn_save);
        }
	}
}


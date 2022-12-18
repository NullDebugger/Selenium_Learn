using System;
using OpenQA.Selenium.Support.UI;
using Selenium_Learn.BaseClass;

namespace Selenium_Learn.Scenario1_Central
{
	public class Escort_Accompanied_Test: BaseTest
	{
		[Test, Order(14)]
		public void test_escort_accompanied() {
            //Enter the data you want to test
            string enter_patient_name = "Central__Scenario1 ttestt";
            string enter_s_o = "?central";
            //Enter the test infortmation
            brow.Set_test_id("14");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient record");
            brow.Set_test_case("Escort Accompanied");
            brow.Set_sub_browser_screen("Tasking");
            brow.Set_test_scenario("Check whether can add new person to Escort Accompanied ");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("");
            //1. Navigating to specific central patient record page && 2. Adding "?central" to current URL
            goto_patient_record(enter_patient_name, enter_s_o);

            //Wait Time until find the element 
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[1]/a"));
                return true;
            });
            wait.Until(waitForElement);
            //3. Find the element of "Tasking"
            By Locator_tasking_tab = By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[1]/a");
            IWebElement tasking_tab = (IWebElement)brow.GetWebDriver.FindElement(Locator_tasking_tab);
            tasking_tab.Click();

            /*
                Find the "New" Button of "Escort Accompanied"
                Click "New" Button
                Find the element of "Name" input box
                Enter data to "Name" input box
                Find the element of "Relationship" input box
                Enter data to "Relationship" input box
                Click "Save" button
             */
            Func<IWebDriver, bool> waitForElement_btn_escort = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[1]/form[5]/div/div/div/div/div/div/div/button"));
                return true;
            });
            wait.Until(waitForElement_btn_escort);

            By Locator_btn_new_escort_accom = By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[1]/form[5]/div/div/div/div/div/div/div/button");
            IWebElement btn_new_escort_accom = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_new_escort_accom);
            //using "JavascriptExecutor" to click the button, because the button is hidden on the right side of screen(not within Viewport)
            IJavaScriptExecutor js = (IJavaScriptExecutor)brow.GetWebDriver;
            js.ExecuteScript("arguments[0].click()", btn_new_escort_accom);

            
            string enter_name_of_escort = "Mrs Lucy Jones";
            By Locator_name_input = By.XPath("//*[@id=\"988f8977-6f4b-4267-93b8-fe1a7028a630\"]");
            IWebElement name_input = (IWebElement)brow.GetWebDriver.FindElement(Locator_name_input);
            name_input.SendKeys(enter_name_of_escort);

            string enter_relationship_of_escort = "patient’s wife";
            By Locator_relationship_input = By.XPath("//*[@id=\"5c70e64f-c759-47c7-aed5-9cc66a3018b8\"]");
            IWebElement relationship_input = (IWebElement)brow.GetWebDriver.FindElement(Locator_relationship_input);
            relationship_input.SendKeys(enter_relationship_of_escort);

            By Locator_btn_save = By.XPath("//*[@id=\"preset_modal\"]/div/div[2]/div/form/div/div[4]/button[2]");
            IWebElement btn_save = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_save);
            btn_save.Click();
        }
    }
}


using System;
using OpenQA.Selenium.Support.UI;
using Selenium_Learn.BaseClass;

namespace Selenium_Learn.Scenario1_Central
{
	public class Aeromed_Journey_Log_Test: BaseTest
	{
		[Test, Order(16)]
		public void test_aeromed_journey_log() {
            //Enter the data you want to test
            string enter_patient_name = "Central__Scenario1 ttestt";
            string enter_s_o = "?central";
            //Enter the test infortmation
            brow.Set_test_id("16");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient record");
            brow.Set_sub_browser_screen("Tasking");
            brow.Set_test_case("Aeromed Journey Log");
            brow.Set_test_scenario("Check whether can document jouney time: \"First contact with patient Date/Time\"");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("");
            //1. Navigating to specific central patient record page && 2. Adding "?central" to current URL
            goto_patient_record(enter_patient_name, enter_s_o);


            //3. Find the element of "Tasking" tab
            //Wait Time until find the element 
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[1]/a"));
                return true;
            });
            wait.Until(waitForElement);

            By Locator_tasking_tab = By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[1]/a");
            IWebElement tasking_tab = (IWebElement)brow.GetWebDriver.FindElement(Locator_tasking_tab);
            tasking_tab.Click();

            /*
                Find the "New" button of "First contact with patient Date/Time"
                Click the "New" Button to document first contact with the patient on the Journey Log container
             */
            Func<IWebDriver, bool> waitForElement_btn_first_contact_time = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[1]/form[2]/div/div/div/div/div/div/div[2]/div[2]/button"));
                return true;
            });
            wait.Until(waitForElement_btn_first_contact_time);

            By Locator_btn_first_contact_time = By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[1]/form[2]/div/div/div/div/div/div/div[2]/div[2]/button");
            IWebElement btn_first_contact_time = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_first_contact_time);
            IJavaScriptExecutor js = (IJavaScriptExecutor)brow.GetWebDriver;
            js.ExecuteScript("arguments[0].click()", btn_first_contact_time);
           
        }

    }
}


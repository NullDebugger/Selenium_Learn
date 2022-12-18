using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Selenium_Learn.BaseClass;

namespace Selenium_Learn.Scenario1_Central
{
	public class Arrival_Assess_Tests:BaseTest
	{
        
		//[Test, Order(17)]
		//public void test_diagnosis_container() {
  //          //enter the data we want to test
  //          string enter_primary_diagnosis = "obstruction of bowel";

  //          navigating_to_arrival_assess_tab("17", "Check whether can document the current condition of the patient", "Diagnosis container");
  //          /*
  //              Find the element of "Primary Diagnosis *" input box
  //              Enter data into this input box
  //          */
  //          WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
  //          Func<IWebDriver, bool> waitForElement_primary_diagnosis = new Func<IWebDriver, bool>((IWebDriver Web) =>
  //          {
  //              Web.FindElement(By.XPath(""));
  //              return true;
  //          });
  //          wait.Until(waitForElement_primary_diagnosis);

           
  //          By Locator_primary_diagnosis = By.XPath("");
  //          IWebElement primary_diagnosis_input_box = (IWebElement)brow.GetWebDriver.FindElement(Locator_primary_diagnosis);
  //          primary_diagnosis_input_box.SendKeys(enter_primary_diagnosis);
  //      }

  //      [Test, Order(18)]
  //      public void test_human_figure()
  //      {

  //      }
  //      [Test, Order(19)]
  //      public void test_circulation_container()
  //      {

  //      }
  //      [Test, Order(20)]
  //      public void test_other_container()
  //      {

  //      }
  //      [Test, Order(21)]
  //      public void test_nutrition_container()
  //      {

  //      }

        //This function is used to navigate to arrival assess tab
        public void navigating_to_arrival_assess_tab(string id, string scenario, string test_case)
        {
            //Enter the data you want to test
            string enter_patient_name = "Central__Scenario1 ttestt";
            string enter_s_o = "?central";
            //Enter the test infortmation
            brow.Set_test_id(id);
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient record");
            brow.Set_sub_browser_screen("Tasking");
            brow.Set_test_case(test_case);
            brow.Set_test_scenario(scenario);
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("");
            //1. Navigating to specific central patient record page && 2. Adding "?central" to current URL
            goto_patient_record(enter_patient_name, enter_s_o);

            //3. Find the element of "Arrival Assess/Plan" tab
            //Wait Time until find the element 
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[4]/a"));
                return true;
            });
            wait.Until(waitForElement);

            By Locator_arrival_plan_tab = By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[4]/a");
            IWebElement arrival_plan_tab = (IWebElement)brow.GetWebDriver.FindElement(Locator_arrival_plan_tab);
            arrival_plan_tab.Click();
        }
    }
}


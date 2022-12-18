using System;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using Selenium_Learn.BaseClass;

namespace Selenium_Learn.Scenario1_Central
{
	public class Search_Bar_Test: BaseTest
	{
        /*
			1	Navigating to Task list page
			2	Enter the keyword on the search bar
			3	Click the first row of the table
		 */
        [Test, Order(8)]
		public void test_search_bar()
		{
            //Enter the data you want to test
            string enter_search_data = "Central__Scenario1 ttestt";
            //Enter the test infortmation
            brow.Set_test_id("8");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Task List");
            brow.Set_test_case("Search Bar");
            brow.Set_test_scenario("Check whether can find the specifc patient's record in the EHR");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("page will jump into \"Centre_ttttest\" patient record page");
            // ------------------- 1. Login and navigate to Task-list page ------------------------
            login_action();

            //2   Enter the keyword on the search bar
            By Locator_searchbar = By.XPath("//*[@id=\"root\"]/div/main/div/div/div/div/div[1]/div[1]/div/div/div[2]/div/div[1]/div[1]/input");
            IWebElement search_bar = (IWebElement)brow.GetWebDriver.FindElement(Locator_searchbar);
            search_bar.SendKeys(enter_search_data);

            //3   Click the first row of the table
            //Explicit wait for elements of the application to load so that actions can be performed on them
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[1]/div/div/div[2]/div/div[2]/table/tbody/tr[1]"));
                return true;
            });
            wait.Until(waitForElement);
            //Click first row
            By Locator_first_row = By.XPath("/html/body/div/div/main/div/div/div/div/div[1]/div[1]/div/div/div[2]/div/div[2]/table/tbody/tr[1]");
            IWebElement table_first_row = (IWebElement)brow.GetWebDriver.FindElement(Locator_first_row);
            table_first_row.Click();

            //Assertion 
            string expected_url = "https://rfdsdemo.sandboxwebsite.com.au/patientdetails/forms/c13df176-db9e-4bf3-8beb-e2ffbf6450ac";
            string actual_url = brow.GetWebDriver.Url;
            Assert.AreEqual(expected_url, actual_url);
            System.Threading.Thread.Sleep(4000);

        }
    }
}


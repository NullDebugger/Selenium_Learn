using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium_Learn.BaseClass;

namespace Selenium_Learn.Scenario1_Central
{
	public class Attachment_Test: BaseTest
	{
        /*
			1	Navigating to specific central patient record page
			2	Adding "?central" to current URL
			3	Click "Attachtmen" tag
			3	Find the element of "new Attachment"
			4	Sendkeys to this element
			5	Find the element of "Thumbnail" icon
			6	Click "Thumbnail" icon to download the file
		 */
        [Test, Order(9)]
		public void test_new_attachment() {
            //Enter the data you want to test
            string enter_patient_name = "Central__Scenario1 ttestt";
            string enter_s_o = "?central";
            //Enter the test infortmation
            brow.Set_test_id("9");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient record");
            brow.Set_sub_browser_screen("Attachments");
            brow.Set_test_case("Attachment");
            brow.Set_test_scenario("Check whether can upload the attachment");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("");
            //1. Navigating to specific central patient record page && 2. Adding "?central" to current URL
            goto_patient_record(enter_patient_name, enter_s_o);

            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[2]/a"));
                return true;
            });
            wait.Until(waitForElement);

            //Click attachment tab
            By Locator_attachment_tab = By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[2]/a");
            IWebElement attachment_tab = (IWebElement)brow.GetWebDriver.FindElement(Locator_attachment_tab);
            attachment_tab.Click();


            //3. Find the element of "new Attachment"
            Func<IWebDriver, bool> waitForElement_New_btn = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div/h4/button"));
                return true;
            });
            wait.Until(waitForElement_New_btn);
            By Locator_btn_new_attachment = By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div/h4/button");
            IWebElement btn_new_attachment = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_new_attachment);
            //using "JavascriptExecutor" to click the button, because the button is hidden on the right side of screen(not within Viewport)
            IJavaScriptExecutor js = (IJavaScriptExecutor)brow.GetWebDriver;
            js.ExecuteScript("arguments[0].click()", btn_new_attachment);

            By Locator_btn_upload_file = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[2]/input[1]");
            IWebElement btn_upload_file = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_upload_file);
            btn_upload_file.SendKeys("/Users/ken/Documents/Visual_Studio/Selenium_Learn/Selenium_Learn/Scenario1_Central/strong_cat.png");

            // Save
            By Locator_btn_save = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[3]/button[2]");
            IWebElement btn_save = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_save);
            btn_save.Click();

            //checked whether the file is upload successfully
            Func<IWebDriver, bool> waitForElement_first_row = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div/div/table/tbody/tr/td[1]"));
                return true;
            });
            wait.Until(waitForElement_first_row);
            By Locator_attachment_file_first_row = By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div/div/table/tbody/tr/td[1]");
            IWebElement attachment_file_first_row = (IWebElement)brow.GetWebDriver.FindElement(Locator_attachment_file_first_row);
            string actual_file_name = attachment_file_first_row.Text.ToString();
            string expected_file_name = "strong_cat.png";
            Assert.AreEqual(actual_file_name, expected_file_name);

        }

        [Test, Order(10)]
        public void test_download_attachment()
        {
            //Enter the data you want to test
            string enter_patient_name = "Central__Scenario1 ttestt";
            string enter_s_o = "?central";
            //Enter the test infortmation
            brow.Set_test_id("10");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient record");
            brow.Set_sub_browser_screen("Attachments");
            brow.Set_test_case("Attachment");
            brow.Set_test_scenario("Check whether can download the attachment");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("");
            //1. Navigating to specific central patient record page && 2. Adding "?central" to current URL
            goto_patient_record(enter_patient_name, enter_s_o);
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[2]/a"));
                return true;
            });
            wait.Until(waitForElement);

            //3. Find the element of "Attachment" tab
            By Locator_attachment_tab = By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/ul/div/div[1]/div/div[1]/div[2]/a");
            IWebElement attachment_tab = (IWebElement)brow.GetWebDriver.FindElement(Locator_attachment_tab);
            attachment_tab.Click();

            Func<IWebDriver, bool> waitForElement_thumnail = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div/div/table/thead/tr/th[3]"));
                return true;
            });
            wait.Until(waitForElement_thumnail);

            //4. Find the element of file "Thumbnail" and click it 
            By Locator_thumbnail = By.XPath("//*[@id=\"patientform\"]/div[7]/div[1]/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div/div/table/tbody/tr[1]/td[3]/a");
            IWebElement thumbnail = (IWebElement)brow.GetWebDriver.FindElement(Locator_thumbnail);
            thumbnail.Click();

            //5. Check whether the file exsit in "/Users/ken/Downloads/"
            bool result = CheckFile("strong_cat.png"); ; // boolean result true or false is stored after checking the zip file name
            if (result == true){
                Assert.Pass();// if the zip file is present 
            }else{
                Assert.Fail("The file does not exist.");// if the file is not present, then the  test fails
            }
        }
    }
}


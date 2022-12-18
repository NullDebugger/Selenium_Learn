using System;
using OpenQA.Selenium.Support.UI;
using Selenium_Learn.BaseClass;

namespace Selenium_Learn
{
    [TestFixture]
	public class Login_Test : BaseTest
    {
        //Test case 1: Login function with valid data
        [Test, Order(0)]
        public void test_validData_login()
        {
            //Enter the data you want to test
            string enter_login_username = "kchen@jamesanthonyconsulting.com.au";
            string enter_login_password = "****Enter_Password****";
            //Enter the test infortmation
            brow.Set_test_id("1");
            brow.Set_test_s_o("Global");
            brow.Set_browser_screen("Login Screen");
            brow.Set_test_case("Login");
            brow.Set_test_scenario("Check user login via OKta with vaild data");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("User can login and Web page redirects to the patient detial page");
            //------- 1: The user navigates to Login page ---------
            brow.Goto(test_url);
            System.Threading.Thread.Sleep(4000);

            //------- 2: The user clicks the "Okta Login" button. -------
            //Access "Okta Login" by element's Xpath
            By Locator_btn_login = By.XPath("//*[@id=\"root\"]/div/div/div/div/div/div/div/form/div[2]/button");
            IWebElement btn_login = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_login);
            //Click "Okta Login" Button
            btn_login.Click();
            System.Threading.Thread.Sleep(8000);

            //Store all the opened window into the list 
            List<string> lstWindow = brow.GetWebDriver.WindowHandles.ToList();
            //switch to Okta Login Window
            brow.GetWebDriver.SwitchTo().Window(lstWindow[1]);

            //------- 3: In the 'username' field, the user enters a registered email address. ------
            //Access 'username' text field by element's Xpath
            By Locator_username = By.XPath("//*[@id=\"okta-signin-username\"]");
            IWebElement text_username = (IWebElement)brow.GetWebDriver.FindElement(Locator_username);
            text_username.SendKeys(enter_login_username);

            //------- 4: In the ''password' field, the user enters the registered password -------
            By Locator_password = By.XPath("//*[@id=\"okta-signin-password\"]");
            IWebElement text_password = (IWebElement)brow.GetWebDriver.FindElement(Locator_password);
            text_password.SendKeys(enter_login_password);

            //------- 5: The user clicks ‘Sign In'. -------
            By Locator_okta_login = By.XPath("//*[@id=\"okta-signin-submit\"]");
            IWebElement btn_okta_login = (IWebElement)brow.GetWebDriver.FindElement(Locator_okta_login);
            btn_okta_login.Submit();

            System.Threading.Thread.Sleep(8000);
            //After Login Successfully - switch window back to RFDS
            brow.GetWebDriver.SwitchTo().Window(lstWindow[0]);

            //------ 6: Check that expected and actual URL is the same ---------
            String actual_Url = "https://rfdsdemo.sandboxwebsite.com.au/patientdetails/tasks";
            String expected_Url = brow.GetWebDriver.Url;
            //Console.WriteLine(expected_Url + " -- vs --" + actual_Url);
            Assert.AreEqual(expected_Url, actual_Url);
            System.Threading.Thread.Sleep(4000);
        }

        //Test case 2: Login function with invalid data
        [Test, Order(1)]
        public void test_invalidDate_login()
        {
            //Enter the data you want to test
            string enter_login_username = "test@jamesanthonyconsulting.com.au";
            string enter_login_password = "12345678";
            //Enter the test infortmation
            brow.Set_test_id("2");
            brow.Set_test_s_o("Global");
            brow.Set_browser_screen("Login Screen");
            brow.Set_test_case("Login");
            brow.Set_test_scenario("Check user login via OKta with invaild data");
            brow.Set_test_Description("Lots");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("User can not login");
            //------- 1: The user navigates to Login page ---------
            brow.Goto(test_url);
            //Explcit wait until page loading finished and find the login button
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement_Loading = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div/div/div/form/div[2]/button"));
                return true;
            });

            wait.Until(waitForElement_Loading);

            //------- 2: The user clicks the "Okta Login" button. -------
            //Access "Okta Login" by element's Xpath
            By Locator_btn_login = By.XPath("//*[@id=\"root\"]/div/div/div/div/div/div/div/form/div[2]/button");
            IWebElement btn_login = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_login);
            //Click "Okta Login" Button
            btn_login.Click();
            System.Threading.Thread.Sleep(8000);

            //Store all the opened window into the list 
            List<string> lstWindow = brow.GetWebDriver.WindowHandles.ToList();
            //switch to Okta Login Window
            brow.GetWebDriver.SwitchTo().Window(lstWindow[1]);

            //------- 3: In the 'username' field, the user enters an invalid email address. ------
            //Access 'username' text field by element's Xpath
            By Locator_username = By.XPath("//*[@id=\"okta-signin-username\"]");
            IWebElement text_username = (IWebElement)brow.GetWebDriver.FindElement(Locator_username);
            text_username.SendKeys(enter_login_username);

            //------- 4: In the ''password' field, the user enters the invalid password -------
            By Locator_password = By.XPath("//*[@id=\"okta-signin-password\"]");
            IWebElement text_password = (IWebElement)brow.GetWebDriver.FindElement(Locator_password);
            text_password.SendKeys(enter_login_password);

            //------- 5: The user clicks ‘Sign In'. -------
            By Locator_okta_login = By.XPath("//*[@id=\"okta-signin-submit\"]");
            IWebElement btn_okta_login = (IWebElement)brow.GetWebDriver.FindElement(Locator_okta_login);
            btn_okta_login.Submit();

            System.Threading.Thread.Sleep(8000);
            //After Login Successfully - switch window back to RFDS
            brow.GetWebDriver.SwitchTo().Window(lstWindow[0]);

            //------ 6: Check that expected and actual URL is not the same ---------
            String actual_Url = "https://rfdsdemo.sandboxwebsite.com.au/patientdetails/tasks";
            String expected_Url = brow.GetWebDriver.Url;
            Assert.AreNotEqual(expected_Url, actual_Url);
            System.Threading.Thread.Sleep(4000);
        }

    }

}


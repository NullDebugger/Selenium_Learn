using System;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Learn.BaseClass
{
    public class Browser_ops
    {
        IWebDriver webDriver;
        //Initial "Test Information" data
        String test_id = "";
        String test_s_o = "";
        String browser_screen = "";
        String sub_browser_screen = "";
        String test_case = "";
        String test_scenario = "";
        String description = "";
        String test_data = "";
        String expected_results = "";

        //String test_status = "";
        public void Init_Browser()
        {
            webDriver = new ChromeDriver(".");
            webDriver.Manage().Window.Maximize();
        }
        
        public string Title
        {
            get { return webDriver.Title; }
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
        }
        public void Close()
        {
            webDriver.Quit();
        }
        public IWebDriver GetWebDriver
        {
            get { return webDriver; }
        }
        //-------- Set and Get Function for "Test Information" ---------
        //Test ID
        public void Set_test_id(string enter_test_id)
        {
            test_id = enter_test_id;
        }
        public string Test_ID
        {
            get { return test_id; }
        }
        //Browser Screen
        public void Set_browser_screen(string enter_browser_screen)
        {
            browser_screen = enter_browser_screen;
        }
        public string Browser_Screen
        {
            get { return browser_screen; }
        }
        //String sub_browser_screen = "";
        public void Set_sub_browser_screen(string enter_sub_browser_screen)
        {
            sub_browser_screen = enter_sub_browser_screen;
        }
        public string Sub_Browser_Screen
        {
            get { return sub_browser_screen; }
        }
        //Test Case
        public void Set_test_case(string enter_test_case)
        {
            test_case = enter_test_case;
        }
        public string Test_Case
        {
            get { return test_case; }
        }
        //String test_scenario = "";
        public void Set_test_scenario(string enter_test_scenario)
        {
            test_scenario = enter_test_scenario;
        }
        public string Test_Scenario
        {
            get { return test_scenario; }
        }
        //String Description = "";
        public void Set_test_Description(string enter_test_description)
        {
            description = enter_test_description;
        }
        public string Test_Description
        {
            get { return description; }
        }
        //String test_data = "";
        public void Set_test_data(string enter_test_data)
        {
            test_data = enter_test_data;
        }
        public string Test_Data
        {
            get { return test_data; }
        }
        //String expected_results = "";
        public void Set_expected_results(string enter_expected_results)
        {
            expected_results = enter_expected_results;
        }
        public string Expected_Results
        {
            get { return expected_results; }
        }
        //String test_s_o = "";
        public void Set_test_s_o(string enter_test_s_o)
        {
            test_s_o = enter_test_s_o;
        }
        public string Test_s_o
        {
            get { return test_s_o; }
        }

    }

    public class BaseTest
	{
        public Browser_ops brow = new Browser_ops();
        public String test_url = "https://rfdsdemo.sandboxwebsite.com.au/auth/login";
        //----------------------- Start Testing ------------------
        [SetUp]
        public void start_Browser()
        {
            brow.Init_Browser();
        }

        [TearDown]
        public void close_Browser()
        {
            //close Browser
            brow.Close();
            var context = TestContext.CurrentContext;
            //Get the Testing result
            string testname = context.Test.Name;
            string testresult = context.Result.Outcome.ToString();
            //add to CSV file
            addToCSV(brow.Test_ID, brow.Test_s_o, brow.Browser_Screen, brow.Sub_Browser_Screen, brow.Test_Case, brow.Test_Scenario, brow.Test_Description, brow.Test_Data, brow.Expected_Results, testresult, "Testing_Report.csv");
            //Console.WriteLine("Iam Tear",brow.Test_ID);
        }
        //----------------------- End Testing ---------------------

        //---------- This function is used to Login and navigate to Task-list page ------------------------
        public void login_action()
        {
            //Enter the data you want to test
            string enter_login_username = "kchen@jamesanthonyconsulting.com.au";
            string enter_login_password = "******";

            //-------The user navigates to Login page ---------
            brow.Goto(test_url);
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            System.Threading.Thread.Sleep(4000);

            //------- The user clicks the "Okta Login" button. -------
            //Access "Okta Login" by element's Xpath
            By Locator_btn_login = By.XPath("//*[@id=\"root\"]/div/div/div/div/div/div/div/form/div[2]/button");
            IWebElement btn_login = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_login);
            //Click "Okta Login" Button
            btn_login.Click();
            System.Threading.Thread.Sleep(4000);

            //Store all the opened window into the list 
            List<string> lstWindow = brow.GetWebDriver.WindowHandles.ToList();
            //switch to Okta Login Window
            brow.GetWebDriver.SwitchTo().Window(lstWindow[1]);

            //Explicit wait until sign in username was found
            Func<IWebDriver, bool> waitForElement_okta_sign = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"okta-signin-username\"]"));
                return true;
            });
            wait.Until(waitForElement_okta_sign);

            //------- In the 'username' field, the user enters a registered email address. ------
            //Access 'username' text field by element's Xpath
            By Locator_username = By.XPath("//*[@id=\"okta-signin-username\"]");
            IWebElement text_username = (IWebElement)brow.GetWebDriver.FindElement(Locator_username);
            text_username.SendKeys(enter_login_username);

            //------- In the ''password' field, the user enters the registered password -------
            By Locator_password = By.XPath("//*[@id=\"okta-signin-password\"]");
            IWebElement text_password = (IWebElement)brow.GetWebDriver.FindElement(Locator_password);
            text_password.SendKeys(enter_login_password);

            //------- The user clicks ‘Sign In'. -------
            By Locator_okta_login = By.XPath("//*[@id=\"okta-signin-submit\"]");
            IWebElement btn_okta_login = (IWebElement)brow.GetWebDriver.FindElement(Locator_okta_login);
            btn_okta_login.Submit();

            System.Threading.Thread.Sleep(8000);
            //After Login Successfully - switch window back to RFDS
            brow.GetWebDriver.SwitchTo().Window(lstWindow[0]);
        }

        //-------------------- This Function is used to add the test result list into CSV file ----------------
        public static void addToCSV(String test_id, String test_s_o, String browser_screen, String sub_browser_screen, String test_case, String test_scenario, String test_description, String test_data, String expected_results, String test_result, String filepath)
        {
            // Enter Header data
            string[] report_header = {
                "Test ID",
                "S/O",
                "Browser Screen",
                "Sub-Screen (if applicable)",
                "Test Case",
                "Test Scenario",
                "Description",
                "Test Data",
                "Expected / Intended Results",
                "Test Status"
            };
            try
            {
                //Make sure the file was created 
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("Testing_Report.csv", true))
                {
                    Console.WriteLine("Report was created");
                }
                //If not header on the file, then adding header to the report
                using var streamReader = File.OpenText("Testing_Report.csv");
                var length_file = streamReader.ReadToEnd().Length;
                if (length_file == 0)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                    {
                        for (int i = 0; i < report_header.Length; i++)
                        {
                            if (i == (report_header.Length - 1))
                            {
                                file.WriteLine(report_header[i]);
                            }
                            else
                            {
                                file.Write(report_header[i] + ",");
                            }
                        }
                        //file.WriteLine("Testing Name" + "," + "Test Result");
                    }
                    Console.WriteLine("I want to add header");
                }

                //Ture means put the content into end of file vs False means replace everthing the file have
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(test_id + "," + test_s_o + "," + browser_screen + "," + sub_browser_screen + "," +test_case + "," + test_scenario + "," + test_description + "," + test_data + "," + expected_results + "," + test_result);
                }
            }
            catch (Exception ex)
            {
                //This will print error that occurred on console
                throw new ApplicationException("This program did an oopsis :", ex);
            }
        }

    }
}


using System.Reflection.Metadata;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Numerics;

namespace Selenium_Learn;

public class Tests
{
    public class Browser_ops
    {
        IWebDriver webDriver;
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
    }
    /*
            Test cases - Okta Login
        1: The user navigates to Login page
        2: The user clicks the "Okta Login" button.
        3: In the ’username' field, the user enters a registered email address.
        4: In the ''password' field, the user enters the registered password
        5: The user clicks ‘Sign In'.
        6: Check that expected and actual URL is the same 
    */
    class Nunit_Demo_Login
    {
        Browser_ops brow = new Browser_ops();
        String test_url = "https://rfdsdemo.sandboxwebsite.com.au/auth/login";

        [SetUp]
        public void start_Browser()
        {
            brow.Init_Browser();
        }

        //Test case 1: Login function with valid data
        [Test, Order(0)]
        public void test_validData_login()
        {
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
            text_username.SendKeys("kchen@jamesanthonyconsulting.com.au");

            //------- 4: In the ''password' field, the user enters the registered password -------
            By Locator_password = By.XPath("//*[@id=\"okta-signin-password\"]");
            IWebElement text_password = (IWebElement)brow.GetWebDriver.FindElement(Locator_password);
            text_password.SendKeys("pan449580866");

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
            text_username.SendKeys("test@jamesanthonyconsulting.com.au");

            //------- 4: In the ''password' field, the user enters the invalid password -------
            By Locator_password = By.XPath("//*[@id=\"okta-signin-password\"]");
            IWebElement text_password = (IWebElement)brow.GetWebDriver.FindElement(Locator_password);
            text_password.SendKeys("test123456");

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
        //------------------------------------------- Testing Create Patient Function ---------------------------------------------------
        /*
         * 1. Login and navigate to Task-list page
         * 2. Click Create New Task Button
         * 3. Slecte specific S/O
         * 4. Fill out data for each S/O
         * 5. Click Save Button
         * 6. Check whether the patient is create successfully.
        */
        //---------- This function is used to Login and navigate to Task-list page ------------------------
        public void login_action()
        {
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
            text_username.SendKeys("kchen@jamesanthonyconsulting.com.au");

            //------- In the ''password' field, the user enters the registered password -------
            By Locator_password = By.XPath("//*[@id=\"okta-signin-password\"]");
            IWebElement text_password = (IWebElement)brow.GetWebDriver.FindElement(Locator_password);
            text_password.SendKeys("pan449580866");

            //------- The user clicks ‘Sign In'. -------
            By Locator_okta_login = By.XPath("//*[@id=\"okta-signin-submit\"]");
            IWebElement btn_okta_login = (IWebElement)brow.GetWebDriver.FindElement(Locator_okta_login);
            btn_okta_login.Submit();

            System.Threading.Thread.Sleep(8000);
            //After Login Successfully - switch window back to RFDS
            brow.GetWebDriver.SwitchTo().Window(lstWindow[0]);
        }

        //--------------- Testing WA
        [Test, Order(2)]
        public void test_create_patients_WA()
        {
            //Enter the data you want to test
            string enter_wa_form_firstname = "WA_Test";
            string enter_wa_form_lastname = "Test_1";
            string enter_wa_form_sex = "Male";
            string enter_wa_form_age_year = "18";
            string enter_wa_form_age_month = "4";
            string enter_wa_form_age_day = "3";
            string enter_wa_form_weight = "74";
            string enter_wa_form_height = "183";
            string enter_wa_form_width = "34";
            string enter_wa_form_booking_id = "1234";
            string enter_wa_form_consult = "4321";
            string enter_wa_form_person_req = "test";
            string enter_wa_form_location = "Aboriginal Hostels Limited";
            string enter_wa_form_destination = "Abra Mine Camp";
            string enter_wa_form_phone1 = "111222333";
            string enter_wa_form_phone2 = "444222333";
            string enter_wa_form_phone3 = "555222333";
            string enter_wa_form_patient_condition = "good";
            string enter_wa_form_urn = "test";

            // ------------------- 1. Login and navigate to Task-list page ------------------------
            login_action();

            //--------------------------- 2.Click Create New Task Button -------------------------
            By Locator_btn_newPatient = By.XPath("//*[@id=\"root\"]/div/main/div/div/div/div/div[1]/div[1]/div/div/div[2]/div/div[1]/div[1]/div/button[2]");
            IWebElement btn_newPatient = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_newPatient);
            btn_newPatient.Click();

            //--------------------------- 3.Slecte specific S/ O ----------------------------------
            //Explicit wait for elements of the application to load so that actions can be performed on them
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/div[1]"));
                return true;
            });
            wait.Until(waitForElement);
            //Click WA
            By Locator_wa_form = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[2]/div/ul/li[1]");
            IWebElement wa_patient_form = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_form);
            wa_patient_form.Click();

            //Explict wait until find the element of form then perform next step
            Func<IWebDriver, bool> waitForElement_Form = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[1]/input"));
                return true;
            });
            wait.Until(waitForElement_Form);

            //--------------------------- 4.Fill out data for each S/ O ----------------------------
            //Fill out data for WA Patient form
            //First name
            By Locator_wa_form_firstname = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[1]/input");
            IWebElement wa_form_firstname = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_form_firstname);
            wa_form_firstname.SendKeys(enter_wa_form_firstname);
            //Last name
            By Locator_wa_form_lastname = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[2]/input");
            IWebElement wa_form_lastname = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_form_lastname);
            wa_form_lastname.SendKeys(enter_wa_form_lastname);
            //Sex - dropdown menu
            By Locator_wa_form_sex = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[4]/select");
            IWebElement wa_form_sex = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_form_sex);
            SelectElement oSelect = new SelectElement(wa_form_sex);
            oSelect.SelectByText(enter_wa_form_sex);
            //DOB-unknow checked box
            By Locator_wa_dob_unknow = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[2]/div[2]/input");
            IWebElement wa_form_dob_unknow = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_dob_unknow);
            wa_form_dob_unknow.Click();
            //Age in Year
            By Locator_wa_age_year = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[2]/div[3]/input");
            IWebElement wa_form_age_year = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_age_year);
            wa_form_age_year.Clear();
            wa_form_age_year.SendKeys(enter_wa_form_age_year);
            //Age in Month
            By Locator_wa_age_month = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[2]/div[4]/input");
            IWebElement wa_form_age_month = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_age_month);
            wa_form_age_month.Clear();
            wa_form_age_month.SendKeys(enter_wa_form_age_month);
            //Age in Day
            By Locator_wa_age_day = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[2]/div[5]/input");
            IWebElement wa_form_age_day = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_age_day);
            wa_form_age_day.Clear();
            wa_form_age_day.SendKeys(enter_wa_form_age_day);
            //Weight
            By Locator_wa_weight = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[1]/input");
            IWebElement wa_form_weight = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_weight);
            wa_form_weight.SendKeys(enter_wa_form_weight);
            //Height
            By Locator_wa_height = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[2]/input");
            IWebElement wa_form_height = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_height);
            wa_form_height.SendKeys(enter_wa_form_height);
            //Width
            By Locator_wa_widht = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[3]/input");
            IWebElement wa_form_widht = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_widht);
            wa_form_widht.SendKeys(enter_wa_form_width);
            //Booking id
            By Locator_wa_booking_id = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[4]/div/input");
            IWebElement wa_form_booking_id = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_booking_id);
            wa_form_booking_id.SendKeys(enter_wa_form_booking_id);
            //Flight request checkbox
            By Locator_wa_flight_request = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[5]/div[1]/input");
            IWebElement wa_form_flight_request= (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_flight_request);
            wa_form_flight_request.Click();
            //Consult code
            By Locator_wa_consult = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[5]/div[2]/input");
            IWebElement wa_form_consult = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_consult);
            wa_form_consult.SendKeys(enter_wa_form_consult);
            //Person Requesting
            By Locator_wa_person_request = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[6]/div[1]/input");
            IWebElement wa_form_person_request = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_person_request);
            wa_form_person_request.SendKeys(enter_wa_form_person_req);
            //Phone Number
            By Locator_wa_phone_n1 = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[6]/div[2]/input");
            IWebElement wa_form_phone_n1 = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_phone_n1);
            wa_form_phone_n1.SendKeys(enter_wa_form_phone1);

            //Patient Location
            By Locator_wa_location = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[7]/div[1]/div/div[1]/input");
            IWebElement wa_form_location = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_location);
            wa_form_location.SendKeys(enter_wa_form_location);

            //Phone Number
            By Locator_wa_phone_n2 = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[7]/div[2]/input");
            IWebElement wa_form_phone_n2 = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_phone_n2);
            wa_form_phone_n2.SendKeys(enter_wa_form_phone2);

            //Patient Destination     
            By Locator_wa_destination = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[8]/div[1]/div/div[1]/input");
            IWebElement wa_form_destination = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_destination);
            wa_form_destination.SendKeys(enter_wa_form_destination);

            //Phone Number
            By Locator_wa_phone_n3 = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[8]/div[2]/input");
            IWebElement wa_form_phone_n3 = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_phone_n3);
            wa_form_phone_n3.SendKeys(enter_wa_form_phone3);
            //Patient Condition
            By Locator_wa_condition = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[9]/div[1]/input");
            IWebElement wa_form_condition = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_condition);
            wa_form_condition.SendKeys(enter_wa_form_patient_condition);
            //URN
            By Locator_wa_urn = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[9]/div[2]/input");
            IWebElement wa_form_urn = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_urn);
            wa_form_urn.SendKeys(enter_wa_form_urn);

            //------------------------------ 5.Click Save Button -------------------------------
            By Locator_wa_save_btn = By.XPath("//*[@id=\"btnSavePatient\"]");
            IWebElement wa_form_btn_save = (IWebElement)brow.GetWebDriver.FindElement(Locator_wa_save_btn);
            wa_form_btn_save.Click();

            //-------------------- 6.Check whether the patient is create successfully. -----------------------
            //Still Thinking how to assert this one
            /*
                1. Get all of the list of the table
                2. Use for loop to check each row
                    - if the row's text equal to expected result, return 'true'
                    - else, return 'false'
             */
        }

        //----------------- Testing Central
        [Test, Order(3)]
        public void test_create_patients_Central()
        {
            //Enter the data you want to test
            string enter_central_form_firstname = "Central_Test";
            string enter_central_form_lastname = "Test_1";
            string enter_central_form_age_year = "18";
            string enter_central_form_age_month = "4";
            string enter_central_form_age_day = "3";
            string enter_central_form_weight = "74";
            string enter_central_form_height = "183";
            string enter_central_form_width = "34";
            string enter_central_form_gender = "Male";
            string enter_central_form_indigenous_sta = "NAB Non Aboriginal";        
            string enter_central_form_address_1 = "Synagogue PL";
            string enter_central_form_address_2 = "Lot14";
            string enter_central_form_suburb = "4321";
            string enter_central_form_phone = "1122334455";
            string enter_central_form_taskId = "12345";
            // ------------------- 1. Login and navigate to Task-list page ------------------------
            login_action();
            //--------------------------- 2.Click Create New Task Button -------------------------
            By Locator_btn_newPatient = By.XPath("//*[@id=\"root\"]/div/main/div/div/div/div/div[1]/div[1]/div/div/div[2]/div/div[1]/div[1]/div/button[2]");
            IWebElement btn_newPatient = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_newPatient);
            btn_newPatient.Click();

            //--------------------------- 3.Slecte specific S/ O ----------------------------------
            //Explicit wait for elements of the application to load so that actions can be performed on them
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/div[1]"));
                return true;
            });
            wait.Until(waitForElement);
            //Click Central
            By Locator_central_form = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[2]/div/ul/li[2]");
            IWebElement central_patient_form = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_form);
            central_patient_form.Click();

            //Explict wait until find the element of form then perform next step
            Func<IWebDriver, bool> waitForElement_Form = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[1]/input"));
                return true;
            });
            wait.Until(waitForElement_Form);

            //--------------------------- 4.Fill out data for each S/ O ----------------------------
            //Fill out data for Central Patient form
            //First name
            By Locator_central_form_firstname = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[1]/input");
            IWebElement central_form_firstname = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_form_firstname);
            central_form_firstname.SendKeys(enter_central_form_firstname);

            //Last name
            By Locator_central_form_lastname = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[2]/input");
            IWebElement central_form_lastname = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_form_lastname);
            central_form_lastname.SendKeys(enter_central_form_lastname);
            //DOB-unknow checked box
            By Locator_central_dob_unknow = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[2]/div[2]/input");
            IWebElement central_form_dob_unknow = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_dob_unknow);
            central_form_dob_unknow.Click();
            //Age in Year
            By Locator_central_age_year = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[2]/div[3]/input");
            IWebElement central_form_age_year = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_age_year);
            central_form_age_year.Clear();
            central_form_age_year.SendKeys(enter_central_form_age_year);
            //Age in Month
            By Locator_central_age_month = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[2]/div[4]/input");
            IWebElement central_form_age_month = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_age_month);
            central_form_age_month.Clear();
            central_form_age_month.SendKeys(enter_central_form_age_month);
            //Age in Day
            By Locator_central_age_day = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[2]/div[5]/input");
            IWebElement central_form_age_day = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_age_day);
            central_form_age_day.Clear();
            central_form_age_day.SendKeys(enter_central_form_age_day);
            //Weight
            By Locator_central_weight = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[1]/input");
            IWebElement central_form_weight = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_weight);
            central_form_weight.SendKeys(enter_central_form_weight);
            //Height
            By Locator_central_height = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[2]/input");
            IWebElement central_form_height = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_height);
            central_form_height.SendKeys(enter_central_form_height);
            //Width
            By Locator_central_width = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[4]/input");
            IWebElement central_form_width = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_width);
            central_form_width.SendKeys(enter_central_form_width);
            //Gender - dropdown menu
            By Locator_central_form_gender = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[4]/div[1]/select");
            IWebElement central_form_gender = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_form_gender);
            SelectElement oSelect = new SelectElement(central_form_gender);
            oSelect.SelectByText(enter_central_form_gender);
            // Indigenous Status
            By Locator_central_form_indigenous_sta = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[4]/div[2]/select");
            IWebElement central_form_indigenous_sta = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_form_indigenous_sta);
            SelectElement oSelect_2 = new SelectElement(central_form_indigenous_sta);
            oSelect_2.SelectByText(enter_central_form_indigenous_sta);
            //Address line1 
            By Locator_central_address_1 = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[5]/div/input[1]");
            IWebElement central_form_address_1 = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_address_1);
            central_form_address_1.SendKeys(enter_central_form_address_1);
            //Address line2
            By Locator_central_address_2 = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[5]/div/input[2]");
            IWebElement central_form_address_2 = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_address_2);
            central_form_address_2.SendKeys(enter_central_form_address_2);
            //Suburb
            By Locator_central_suburb = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[6]/div[1]/div/div[1]/input");
            IWebElement central_form_suburb = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_suburb);
            central_form_suburb.SendKeys(enter_central_form_suburb);
            //Phone
            By Locator_central_phone = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[8]/div/input");
            IWebElement central_form_phone = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_phone);
            central_form_phone.SendKeys(enter_central_form_phone);
            //Task id
            By Locator_central_taskId = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[9]/div/input");
            IWebElement central_form_taskId = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_taskId);
            central_form_taskId.SendKeys(enter_central_form_taskId);

            //------------------------------ 5.Click Save Button -------------------------------
            By Locator_central_save_btn = By.XPath("//*[@id=\"btnSavePatient\"]");
            IWebElement central_form_btn_save = (IWebElement)brow.GetWebDriver.FindElement(Locator_central_save_btn);
            central_form_btn_save.Click();

            //-------------------- 6.Check whether the patient is create successfully. -----------------------
            //Still Thinking how to assert this one

        }
        

        //----------------- Testing QLD
        [Test, Order(4)]
        public void test_create_patients_QLD()
        {
            //Enter the data you want to test
            string enter_qld_form_firstname = "QLD_Test";
            string enter_qld_form_lastname = "Test_1";
            string enter_qld_form_afr_num = "18";
            string enter_qld_form_afr_line_num = "8";
            string enter_qld_form_tcr_num = "23";
            string enter_qld_form_rsq_num = "24";
            string enter_qld_form_base = "Townsville";
            string enter_qld_form_task_type = "Primary - Pre-hospital/ No health service";
            // ------------------- 1. Login and navigate to Task-list page ------------------------
            login_action();
            //--------------------------- 2.Click Create New Task Button -------------------------
            By Locator_btn_newPatient = By.XPath("//*[@id=\"root\"]/div/main/div/div/div/div/div[1]/div[1]/div/div/div[2]/div/div[1]/div[1]/div/button[2]");
            IWebElement btn_newPatient = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_newPatient);
            btn_newPatient.Click();

            //--------------------------- 3.Slecte specific S/ O ----------------------------------
            //Explicit wait for elements of the application to load so that actions can be performed on them
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/div[1]"));
                return true;
            });
            wait.Until(waitForElement);

            //Click QLD
            By Locator_qld_form = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[2]/div/ul/li[3]");
            IWebElement qld_patient_form = (IWebElement)brow.GetWebDriver.FindElement(Locator_qld_form);
            qld_patient_form.Click();

            //Explict wait until find the element of form then perform next step
            Func<IWebDriver, bool> waitForElement_Form = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[1]/input"));
                return true;
            });
            wait.Until(waitForElement_Form);

            //--------------------------- 4.Fill out data for each S/ O ----------------------------
            //Fill out data for QLD Patient form
            //First name
            By Locator_qld_form_firstname = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[1]/input");
            IWebElement qld_form_firstname = (IWebElement)brow.GetWebDriver.FindElement(Locator_qld_form_firstname);
            qld_form_firstname.SendKeys(enter_qld_form_firstname);
            //Last name
            By Locator_qld_form_lastname = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[2]/input");
            IWebElement qld_form_lastname = (IWebElement)brow.GetWebDriver.FindElement(Locator_qld_form_lastname);
            qld_form_lastname.SendKeys(enter_qld_form_lastname);

            //AFR Number
            By Locator_qld_form_afr_num = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[2]/div/input");
            IWebElement qld_form_afr_num = (IWebElement)brow.GetWebDriver.FindElement(Locator_qld_form_afr_num);
            qld_form_afr_num.SendKeys(enter_qld_form_afr_num);

            //AFR Line Number
            By Locator_qld_form_afr_line_num = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[1]/input");
            IWebElement qld_form_afr_line_num = (IWebElement)brow.GetWebDriver.FindElement(Locator_qld_form_afr_line_num);
            qld_form_afr_line_num.SendKeys(enter_qld_form_afr_line_num);

            //TCR Number
            By Locator_qld_form_tcr_num = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[2]/input");
            IWebElement qld_form_tcr_num = (IWebElement)brow.GetWebDriver.FindElement(Locator_qld_form_tcr_num);
            qld_form_tcr_num.SendKeys(enter_qld_form_tcr_num);

            //RSQ Number
            By Locator_qld_form_rsq_num = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[3]/input");
            IWebElement qld_form_rsq_num = (IWebElement)brow.GetWebDriver.FindElement(Locator_qld_form_rsq_num);
            qld_form_rsq_num.SendKeys(enter_qld_form_rsq_num);

            //Base 
            By Locator_qld_form_base = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[4]/div[1]/div/div[1]/input");
            IWebElement qld_form_base = (IWebElement)brow.GetWebDriver.FindElement(Locator_qld_form_base);
            qld_form_base.SendKeys(enter_qld_form_base);

            //Patient Task Type- dropdown menu
            By Locator_qld_form_task_type = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[4]/div[2]/select");
            IWebElement qld_form_task_type = (IWebElement)brow.GetWebDriver.FindElement(Locator_qld_form_task_type);
            SelectElement oSelect_2 = new SelectElement(qld_form_task_type);
            oSelect_2.SelectByText(enter_qld_form_task_type);

            //------------------------------ 5.Click Save Button -------------------------------
            By Locator_qld_save_btn = By.XPath("//*[@id=\"btnSavePatient\"]");
            IWebElement qld_form_btn_save = (IWebElement)brow.GetWebDriver.FindElement(Locator_qld_save_btn);
            qld_form_btn_save.Click();

            //-------------------- 6.Check whether the patient is create successfully. -----------------------
            //Still Thinking how to assert this one
        }
        

        //----------------- Testing SE
        [Test, Order(5)]
        public void test_create_patients_SE()
        {
            //Enter the data you want to test
            string enter_se_form_firstname = "SE_Test";
            string enter_se_form_lastname = "Test_1";    
            string enter_se_form_age_year = "18";
            string enter_se_form_age_month = "4";
            string enter_se_form_age_day = "3";
            string enter_se_form_weight = "74";
            string enter_se_form_height = "183";
            string enter_se_form_width = "34";
            string enter_se_form_gender = "Male";
            string enter_se_form_indig_status = "NAB Non Aboriginal";
            string enter_se_form_address_1 = "1234";
            string enter_se_form_address_2 = "Lot14";
            string enter_se_form_suburb = "Adelaide";
            string enter_se_form_state = "SA";
            string enter_se_form_postalcode = "5000";
            string enter_se_form_phone = "11223344";
            string enter_se_form_mrn = "112233";
            string enter_se_form_taskId = "12345";
            string enter_se_form_missionId = "1122";
            // ------------------- 1. Login and navigate to Task-list page ------------------------
            login_action();
            //--------------------------- 2.Click Create New Task Button -------------------------
            By Locator_btn_newPatient = By.XPath("//*[@id=\"root\"]/div/main/div/div/div/div/div[1]/div[1]/div/div/div[2]/div/div[1]/div[1]/div/button[2]");
            IWebElement btn_newPatient = (IWebElement)brow.GetWebDriver.FindElement(Locator_btn_newPatient);
            btn_newPatient.Click();

            //--------------------------- 3.Slecte specific S/ O ----------------------------------
            //Explicit wait for elements of the application to load so that actions can be performed on them
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/div[1]"));
                return true;
            });
            wait.Until(waitForElement);
            //Click SE
            By Locator_se_form = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[2]/div/ul/li[4]");
            IWebElement se_patient_form = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_form);
            se_patient_form.Click();

            //Explict wait until find the element of form then perform next step
            Func<IWebDriver, bool> waitForElement_Form = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[1]/input"));
                return true;
            });
            wait.Until(waitForElement_Form);

            //--------------------------- 4.Fill out data for each S/ O ----------------------------
            //Fill out data for SE Patient form
            //First name
            By Locator_se_form_firstname = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[1]/input");
            IWebElement se_form_firstname = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_form_firstname);
            se_form_firstname.SendKeys(enter_se_form_firstname);
            //Last name
            By Locator_se_form_lastname = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[1]/div[2]/input");
            IWebElement wa_form_lastname = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_form_lastname);
            wa_form_lastname.SendKeys(enter_se_form_lastname);
            //DOB-unknow checked box
            By Locator_se_dob_unknow = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[2]/input");
            IWebElement se_form_dob_unknow = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_dob_unknow);
            se_form_dob_unknow.Click();
            //Age in Year
            By Locator_se_age_year = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[3]/input");
            IWebElement se_form_age_year = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_age_year);
            se_form_age_year.Clear();
            se_form_age_year.SendKeys(enter_se_form_age_year);
            //Age in Month
            By Locator_se_age_month = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[4]/input");
            IWebElement se_form_age_month = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_age_month);
            se_form_age_month.Clear();
            se_form_age_month.SendKeys(enter_se_form_age_month);
            //Age in Day
            By Locator_se_age_day = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[3]/div[5]/input");
            IWebElement se_form_age_day = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_age_day);
            se_form_age_day.Clear();
            se_form_age_day.SendKeys(enter_se_form_age_day);
            //Weight
            By Locator_se_weight = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[4]/div[1]/input");
            IWebElement se_form_weight = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_weight);
            se_form_weight.SendKeys(enter_se_form_weight);
            //Height
            By Locator_se_height = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[4]/div[2]/input");
            IWebElement se_form_height = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_height);
            se_form_height.SendKeys(enter_se_form_height);
            //Width
            By Locator_se_widht = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[4]/div[4]/input");
            IWebElement se_form_widht = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_widht);
            se_form_widht.SendKeys(enter_se_form_width);


            //Gender - dropdown menu
            By Locator_se_form_gender = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[5]/div[1]/select");
            IWebElement se_form_gender = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_form_gender);
            SelectElement oSelect = new SelectElement(se_form_gender);
            oSelect.SelectByText(enter_se_form_gender);
            //Indigenous Status - dropdown menu
            By Locator_se_form_indige_status = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[5]/div[2]/select");
            IWebElement se_form_indige_status = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_form_indige_status);
            SelectElement oSelect_2 = new SelectElement(se_form_indige_status);
            oSelect_2.SelectByText(enter_se_form_indig_status);

            //Address lin1
            By Locator_se_address_1 = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[6]/div/input[1]");
            IWebElement se_form_address_1 = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_address_1);
            se_form_address_1.SendKeys(enter_se_form_address_1);
            //Address lin2
            By Locator_se_address_2 = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[6]/div/input[2]");
            IWebElement se_form_address_2 = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_address_2);
            se_form_address_2.SendKeys(enter_se_form_address_2);
            //Suburb
            By Locator_se_suburb = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[7]/div[1]/input");
            IWebElement se_form_suburb = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_suburb);
            se_form_suburb.SendKeys(enter_se_form_suburb);
            //State
            By Locator_se_state = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[7]/div[2]/input");
            IWebElement se_form_state = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_state);
            se_form_state.SendKeys(enter_se_form_state);
            //Postalcode
            By Locator_se_postalcode = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[7]/div[3]/input");
            IWebElement se_form_postalcode = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_postalcode);
            se_form_postalcode.SendKeys(enter_se_form_postalcode);
            //Phone
            By Locator_se_form_phone = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[9]/div[1]/input");
            IWebElement se_form_phone = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_form_phone);
            se_form_phone.SendKeys(enter_se_form_phone);
            //MRN#
            By Locator_se_form_mrn = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[9]/div[2]/input");
            IWebElement se_form_mrn = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_form_mrn);
            se_form_mrn.SendKeys(enter_se_form_mrn);
            //Task ID
            By Locator_se_form_taskId = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[10]/div[1]/input");
            IWebElement se_form_taskId = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_form_taskId);
            se_form_taskId.SendKeys(enter_se_form_taskId);
            //Mission ID
            By Locator_se_form_missionId = By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[1]/div/div[10]/div[2]/input");
            IWebElement se_form_MissionId = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_form_missionId);
            se_form_MissionId.SendKeys(enter_se_form_missionId);
            
            //------------------------------ 5.Click Save Button -------------------------------
            By Locator_se_save_btn = By.XPath("//*[@id=\"btnSavePatient\"]");
            IWebElement se_form_btn_save = (IWebElement)brow.GetWebDriver.FindElement(Locator_se_save_btn);
            se_form_btn_save.Click();

            //-------------------- 6.Check whether the patient is create successfully. -----------------------
            //Still Thinking how to assert this one
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
            addToCSV(testname, testresult, "report.csv");
        }
        //This Function is used to add the test result list into CSV file
        public static void addToCSV(String test_name, String test_result, String filepath)
        {
            try
            {
                //Ture means put the content into end of file vs False means replace everthing the file have
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(test_name + "," + test_result);
                }
            }catch (Exception ex)
            {
                //This will print error that occurred on console
                throw new ApplicationException("This program did an oopsis :", ex);
            }
        }
    }
    
}

using System;
using OpenQA.Selenium.Support.UI;
using Selenium_Learn.BaseClass;

namespace Selenium_Learn
{
	public class Fillout_Patient_Form_Test : BaseTest
	{
        /*
         * Fill out the data for each S/O 
         * 1. Login
         * 2. Serach central patient using keyword
         * 3. Click the patient
         * 4. fillout the task detail
         */
        [Test, Order(6)]
        public void test_fillout_data_Central()
        {
            //Enter the data you want to test and test information
            string enter_search_keyword = "central_tttest";
            brow.Set_test_id("7");
            brow.Set_test_s_o("Central");
            brow.Set_browser_screen("Patient Record");
            brow.Set_sub_browser_screen("Tasking");
            brow.Set_test_case("Task Detail");
            brow.Set_test_scenario("Test....");
            brow.Set_test_Description("add later");
            brow.Set_test_data("Lots");
            brow.Set_expected_results("Fill out data successfully");
            //*1.Login
            login_action();
            //* 2.Serach central patient using "serach bar && keyword"
            //Search bar
            By Locator_search_bar = By.XPath("//*[@id=\"root\"]/div/main/div/div/div/div/div[1]/div[1]/div/div/div[2]/div/div[1]/div[1]/input");
            IWebElement search_bar = (IWebElement)brow.GetWebDriver.FindElement(Locator_search_bar);
            search_bar.SendKeys(enter_search_keyword);
            //Wait the table loading complete
            WebDriverWait wait = new WebDriverWait(brow.GetWebDriver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement_Table = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"root\"]/div/main/div/div/div/div/div[1]/div[1]/div/div/div[2]/div/div[2]/table/tbody/tr[1]"));
                return true;
            });
            wait.Until(waitForElement_Table);
            //* 3.Click the patient
            //Select the first row of the table
            By Locator_first_row_table = By.XPath("//*[@id=\"root\"]/div/main/div/div/div/div/div[1]/div[1]/div/div/div[2]/div/div[2]/table/tbody/tr[1]");
            IWebElement first_row_table = (IWebElement)brow.GetWebDriver.FindElement(Locator_first_row_table);
            first_row_table.Click();
            //add "?central" to the end of url
            brow.Goto(brow.GetWebDriver.Url + "?central");
            Func<IWebDriver, bool> waitForElement_Url = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath("//*[@id=\"87164269-102c-4763-928f-805c77a45afa\"]"));
                return true;
            });
            wait.Until(waitForElement_Url);
            //*4.fillout the task detail
            //Task ID
            string enter_task_detail_taskID = "SA4345677";
            By Locator_task_detail_taskID = By.XPath("//*[@id=\"87164269-102c-4763-928f-805c77a45afa\"]");
            IWebElement task_detail_taskID = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_taskID);

            task_detail_taskID.Click();
            task_detail_taskID.Clear();
            task_detail_taskID.SendKeys(enter_task_detail_taskID);
            //Evacuation Date
            string enter_task_detail_evacuation_date = "03-09-2022";
            By Locator_task_detail_evacuation_date = By.XPath("//*[@id=\"3df54041-1dbe-4539-9d47-5c19652d5b3b\"]");
            IWebElement task_detail_evacuation_date = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_evacuation_date);
            task_detail_evacuation_date.SendKeys(enter_task_detail_evacuation_date);
            //Originating Airstrip/Airport
            string enter_task_detail_originating_airport = "RENMARK | YREN";
            By Locator_task_detail_originating_airport = By.XPath("//*[@id=\"cc6a8231-e35a-45c0-a621-87f2932b6f7f\"]");
            IWebElement task_detail_originating_airport = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_originating_airport);
            task_detail_originating_airport.Clear();
            task_detail_originating_airport.SendKeys(enter_task_detail_originating_airport);
            //Destination Airstrip/Airport
            string enter_task_detail_destination_airport = "ADELAIDE | YPAD";
            By Locator_task_detail_destination_airport = By.XPath("//*[@id=\"3c72b805-355e-4e5d-a573-b4df56eb02e6\"]");
            IWebElement task_detail_destination_airport = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_destination_airport);
            task_detail_destination_airport.Clear();
            task_detail_destination_airport.SendKeys(enter_task_detail_destination_airport);
            //Originating Facility
            string enter_task_detail_originating_facility = "Riverland Mallee Coorong LHN - Renmark Paringa";
            By Locator_task_detail_originating_facility = By.XPath("//*[@id=\"3f25f552-2396-46b5-bbff-c1e945a6ebd6\"]");
            IWebElement task_detail_originating_facility = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_originating_facility);
            task_detail_originating_facility.Clear();
            task_detail_originating_facility.SendKeys(enter_task_detail_originating_facility);
            //Destination Facility
            string enter_task_detail_destination_facility = "Central Adelaide LHN - Royal Adelaide Hospital | RAH";
            By Locator_task_detail_destination_facility = By.XPath("//*[@id=\"b1594a2a-ea7b-49f3-8dc3-14ba29de1a51\"]");
            IWebElement task_detail_destination_facility = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_destination_facility);
            task_detail_destination_facility.Clear();
            task_detail_destination_facility.SendKeys(enter_task_detail_destination_facility);
            //Priority
            string enter_task_detail_priority = "2 As soon as possible";
            By Locator_task_detail_priority = By.XPath("//*[@id=\"d55b591e-53e5-4a0f-b27e-eaf2809bcbc5\"]");
            IWebElement task_detail_priority = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_priority);
            task_detail_priority.SendKeys(enter_task_detail_priority);
            //Acuity
            string enter_task_detail_acuity = "2 Intermediate (Low Acuity)";
            By Locator_task_detail_acuity = By.XPath("//*[@id=\"dbba55aa-f3cd-4d82-bb53-0903cfa0b028\"]");
            IWebElement task_detail_acuity = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_acuity);
            task_detail_acuity.SendKeys(enter_task_detail_acuity);
            //Clinical Transfer Type
            string enter_task_detail_clinical_transfer_type = "Surgical";
            By Locator_task_detail_clinical_transfer_type = By.XPath("//*[@id=\"dac1f368-1bb4-4061-8b40-465f33f45e9b\"]");
            IWebElement task_detail_clinical_transfer_type = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_clinical_transfer_type);
            task_detail_clinical_transfer_type.SendKeys(enter_task_detail_clinical_transfer_type);
            //Crew Mix
            string enter_task_detail_crew_mix = "2A RFDS Nurse Only";
            By Locator_task_detail_crew_mix = By.XPath("//*[@id=\"e90401a5-beca-4c5b-9cf2-a1b9bc019adc\"]");
            IWebElement task_detail_crew_mix = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_crew_mix);
            task_detail_crew_mix.SendKeys(enter_task_detail_crew_mix);
            //Evac Type
            string enter_task_detail_evac_type = "(I) Interhospital Transfer";
            By Locator_task_detail_evac_type = By.XPath("//*[@id=\"12727fa3-59a7-413e-94a6-129b68abe3d9\"]");
            IWebElement task_detail_evac_type = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_evac_type);
            task_detail_evac_type.SendKeys(enter_task_detail_evac_type);
            //Carry
            string enter_task_detail_carry = "Single";
            By Locator_task_detail_carry = By.XPath("//*[@id=\"895be76f-4c79-4a04-9e0b-2fa6d92b02da\"]");
            IWebElement task_detail_carry = (IWebElement)brow.GetWebDriver.FindElement(Locator_task_detail_carry);
            task_detail_carry.SendKeys(enter_task_detail_carry);
            //---------------------------------------- Not Finished ------------------------------
        }

    }
}


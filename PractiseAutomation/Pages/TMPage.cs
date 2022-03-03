using OpenQA.Selenium;
using PractiseAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PractiseAutomation.Pages
{
    internal class TMPage
    {
        public void TMCreate(IWebDriver driver)
        {
            //Click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            //click on typecode dropdown
            IWebElement typecodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span"));
            typecodeDropdown.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 2);


            //Select Material from the typecode dropdown
            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            materialOption.Click();

            //identify the code text box and enter a value
            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("PractiseAutomation");

            //Identify the decription text box and enter a value
            IWebElement decriptionTextBox = driver.FindElement(By.Id("Description"));
            decriptionTextBox.SendKeys("AutomationDescription");

            //Identify the price field and click on it.
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            //Enter a value to the price textbox
            IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
            priceTextBox.SendKeys("123");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 2);


            //click on GoToLastPageButton
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 2);


            //checking the created material is saved or not
            IWebElement checkSavedValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (checkSavedValue.Text == "PractiseAutomation")
            {
                Console.WriteLine("Material created successfully, test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }

            // ==============EDIT STARTS HERE===============================
            // 1. click on edit button
            // 2. Edit code field
            // 3. Edit description field
            // 4. Edit price field
            // 5. save editted details

        }
        public void EditTM(IWebDriver driver)
        {

            //click on edit button

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Edit code field
            IWebElement editCode = driver.FindElement(By.Id("Code"));
            editCode.Clear();
            editCode.SendKeys("EditCheck");

            //Edit description field

            IWebElement editDescription = driver.FindElement(By.Id("Description"));
            editDescription.Clear();
            editDescription.SendKeys("EditDescription");

            //Edit Price field
            IWebElement clickOnPrice = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            clickOnPrice.Click();
            IWebElement editPrice = driver.FindElement(By.Id("Price"));

            editPrice.Clear();
            clickOnPrice.Click();
            editPrice.SendKeys("100");

            //save editted details

            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 2);

            //Go to last page
            IWebElement editGoToLastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            editGoToLastPage.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 2);

            IWebElement checkEdittedValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (checkEdittedValue.Text == "EditCheck")
            {
                Console.WriteLine("Editted successfully, test passed.");
            }
            else
            {
                Console.WriteLine("Test failed");
            }

        }
        // ==============DELETE STARTS HERE===============================
        // 1. click on delete button
        // 2. Confirm to delete


        //Click on delete button
        public void DeleteTM(IWebDriver driver)
        {

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));

            IWebElement checkEdittedValueforDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (checkEdittedValueforDelete.Text == "EditCheck")
            {
                deleteButton.Click();
                // Confirm to delete
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                Console.WriteLine("Deleted Sucessfully,Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        
        }
    }
}

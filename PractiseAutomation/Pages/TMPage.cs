using NUnit.Framework;
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
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 10);


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
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);


            //click on GoToLastPageButton
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            //Thread.Sleep(5000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);
        }

        //checking the created material is saved or not

        public string GetCode(IWebDriver driver)
        {
            IWebElement checkSavedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return checkSavedCode.Text;
        }

        public string GetTypeCode(IWebDriver driver)
        {
            IWebElement checkSavedType = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return checkSavedType.Text;

        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement checkSavedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return checkSavedDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement checkSavedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return checkSavedPrice.Text;
        }




        //option 1

        //Assert.That(checkSavedCode.Text == "PractiseAutomation", "Expected code did not match, test failed");
        //    Assert.That(checkSavedType.Text == "M", "Expected code did not match,test failed");
        //    Assert.That(checkSavedDescription.Text == "AutomationDescription", "Expected decription did not match,test failed");
        //    Assert.That(checkSavedPrice.Text == "$123.00", "Expected price did not match,test failed");

            //option 2

            //if (checkSavedCode.Text == "PractiseAutomation")
            //{
            //    Assert.Pass("Material created successfully, test passed);
            //}
            //else
            //{
            //    Assert.Fail("Test failed");
            //}
        
        // ==============EDIT STARTS HERE===============================
        // 1. click on edit button
        // 2. Edit code field
        // 3. Edit description field
        // 4. Edit price field
        // 5. save editted details

        public void EditTM(IWebDriver driver, string description, string code, string price)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);

            //Go to last page
            IWebElement editGoToLastPage1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            editGoToLastPage1.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 60);
            //Thread.Sleep(5000);

            //check the element to be editted is ours
            IWebElement elementToBeEditted = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if(elementToBeEditted.Text == "PractiseAutomation")
            {
                //click on edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be editted is not found");
            }

            //Edit code field
            IWebElement editCode = driver.FindElement(By.Id("Code"));
            editCode.Clear();
            editCode.SendKeys(code);

            //Edit description field

            IWebElement editDescription = driver.FindElement(By.Id("Description"));
            editDescription.Clear();
            editDescription.SendKeys(description);

            //Edit Price field
            IWebElement clickOnPrice = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            clickOnPrice.Click();
            IWebElement editPrice = driver.FindElement(By.Id("Price"));

            editPrice.Clear();
            clickOnPrice.Click();
            editPrice.SendKeys(price);

            //save editted details

            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);

            //Go to last page
            IWebElement editGoToLastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            editGoToLastPage.Click();

            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[9]/td[1]", 2);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 60);
            //Thread.Sleep(5000);

            IWebElement checkEdittedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            //Assert.That(checkEdittedCode.Text == "EditCheck123", "editted code and expected code do not match,Edit failed");
            //Assert.That(checkEdittedType.Text == "M", "editted type and expected type do not match,Edit failed");
            //Assert.That(checkEdittedPrice.Text == "$100.00", "editted price and expected price do not match,Edit failed");

            //if (checkEdittedValue.Text == "EditCheck")
            //{
            //    Console.WriteLine("Editted successfully, test passed.");
            //}
            //else
            //{
            //    Console.WriteLine("Test failed");
            //}

        }
        public string edittedDescription(IWebDriver driver)
        {
            IWebElement checkEdittedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return checkEdittedDescription.Text;
        }
        public string edittedCode(IWebDriver driver)
        {
            IWebElement checkEdittedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return checkEdittedCode.Text;

        }
        public string edittedPrice(IWebDriver driver)
        {
            IWebElement checkEdittedType = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return checkEdittedType.Text;

        }

        public void DeleteTM(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 10);
            //click on GoToLastPageButton
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();


            IWebElement checkEdittedValueforDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (checkEdittedValueforDelete.Text == "EditCheck123")
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));

                deleteButton.Click();

                // Confirm to delete
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();

                Assert.Pass("Deleted successfully");
            }
            else
            {
                Console.WriteLine("Test failed");
                Assert.Fail("Record to be deleted is not found, test failed");
            }

            //refresh the page to validate the record has been deleted.
            driver.Navigate().Refresh();

            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton1.Click();

            IWebElement checkEdittedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement checkEdittedType = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement checkEdittedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement checkEdittedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(checkEdittedCode.Text =="EditCheck123", "code not deleted successfully,test passed");
            Assert.That(checkEdittedType.Text == "M", "Type not deleted successfully,test passed");
            Assert.That(checkEdittedDescription.Text == "EditDescription123", "Decription not deleted successfully,test passed");
            Assert.That(checkEdittedPrice.Text == "$100.00", "Price not deleted successfully,test passed");

        }
    }
}

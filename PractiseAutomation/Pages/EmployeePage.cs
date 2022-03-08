using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using PractiseAutomation.Utilities;

namespace PractiseAutomation.Pages
{
    internal class EmployeePage
    {
        public void CreateEmployee(IWebDriver driver)
        {
            //Click on create button
            IWebElement createButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createButton.Click();

            //identify the name textbox and enter the value
            IWebElement nameTextBox = driver.FindElement(By.Id("Name"));
            nameTextBox.SendKeys("Reshma");

            //identify the username textbox and enter the value.
            IWebElement usernameTextBox = driver.FindElement(By.Id("Username"));
            usernameTextBox.SendKeys("username");

            //identify the contact textbox and enter the value.
            IWebElement contactTextBox = driver.FindElement(By.Id("ContactDisplay"));
            contactTextBox.SendKeys("123456");

            //identify the password textbox and enter the value.
            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys("Password123#");

            //identify the retype-password textbox and enter the value.
            IWebElement retypePasswordTextBox = driver.FindElement(By.Id("RetypePassword"));
            retypePasswordTextBox.SendKeys("Password123#");

            //click on save button
            IWebElement saveButton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            saveButton.Click();

            //click on back to list
            IWebElement backToListLink = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
            backToListLink.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);

            //Go to last page
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);

            //check whether the record is saved or not
            IWebElement actualName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement actualUserName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[2]"));

            Assert.That(actualName.Text == "Reshma", "Record not saved,Test fail");
            Assert.That(actualUserName.Text == "username", "Record not saved,Test fail");

        }

        public void EditEmployee(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);

            //Go to last page
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);

            //check the element to be editted is ours.
            IWebElement lastElementToBeEditted = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (lastElementToBeEditted.Text == "Reshma")
            {
                //Click on edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record doesnot match");
            }

            //edit the name textbox
            IWebElement editNameTextBox = driver.FindElement(By.Id("Name"));
            editNameTextBox.Clear();
            editNameTextBox.SendKeys("ReshmaTest");

            //edit username textbox
            IWebElement editUsername = driver.FindElement(By.Id("Username"));
            editUsername.Clear();
            editUsername.SendKeys("Username123");

            //click on save button
            IWebElement saveButton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            saveButton.Click();
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 100);


            //click on back to list
            IWebElement backToListLink = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
            backToListLink.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);

            //Go to last page
            IWebElement editGoToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]"));
            editGoToLastPageButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);

            //Check the record has editted successfully.
            IWebElement edittedActualName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement edittedActualusername = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[2]"));

            Assert.That(edittedActualName.Text == "ReshmaTest", "name not editted, test failed");
            Assert.That(edittedActualusername.Text == "Username123", "username not editted, test failed");

        }

        public void DeleteEmployee(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);
            
            //click on GoToLastPageButton
            IWebElement delgoToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            delgoToLastPageButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 60);


            IWebElement checkEdittedValueforDelete = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (checkEdittedValueforDelete.Text == "ReshmaTest")
            {
                IWebElement deleteButton1 = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));

                deleteButton1.Click();

                // Confirm to delete
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();

                Assert.Pass("Deleted successfully");
            }
            else
            {
                
                Assert.Fail("Record to be deleted is not found, test failed");
            }

            //refresh the page to validate the record has been deleted.
            driver.Navigate().Refresh();

            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton1.Click();

            IWebElement checkEdittedName = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement checkEdittedUsername = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            

            Assert.That(checkEdittedName.Text == "ReshmaTest", "name not deleted successfully,test passed");
            Assert.That(checkEdittedUsername.Text == "Username123", "Type not deleted successfully,test passed");
            

        }
    }
}

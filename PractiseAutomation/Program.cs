using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace PractiseAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //open chrome browser.
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //launch the portal.
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            //Identify the username text box and enter valid username.
            IWebElement userNameTextBox = driver.FindElement(By.Id("UserName"));
            userNameTextBox.SendKeys("hari");
            
            //Identify the password text box and enter valid password.
            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys("123123");

            //Click login button.
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            //check if login is successfull(Validation)
            IWebElement actualUser = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if(actualUser.Text == "Hello hari!")
            {
                Console.WriteLine("User logged in successfully, Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }

            //click on administrationDropdown
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();

            //Go to Time and material page
            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();

            //Click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            //click on typecode dropdown
            IWebElement typecodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span"));
            typecodeDropdown.Click();
            Thread.Sleep(1000);

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
            Thread.Sleep(5000);

            //click on GoToLastPageButton
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(5000);

            //checking the created material is saved or not
            IWebElement checkSavedValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if(checkSavedValue.Text == "PractiseAutomation")
            {
                Console.WriteLine("Material created successfully, test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }

        }
    }
}

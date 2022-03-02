using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

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
        }
    }
}

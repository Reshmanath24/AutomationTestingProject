using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PractiseAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseAutomation.Utilities
{
    internal class CommonDriver
    {
        public IWebDriver driver;


        [OneTimeSetUp]    //similar to pre condition
        public void LoginFunction()
        {
            // open chrome browser.

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //login page object initialisation
            LoginPage loginPageObject = new LoginPage();
            loginPageObject.LoginMethod(driver);


        }

        [OneTimeTearDown]   //similar to post condition
        public void CloseTestRun()
        {
            //driver.Quit();
        }
    }
}

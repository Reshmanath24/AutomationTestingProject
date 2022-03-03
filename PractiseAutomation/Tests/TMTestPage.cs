using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace PractiseAutomation.Pages

{
    internal class TMTestPage

    {
        static void Main(string[] args)
        {
            // open chrome browser.
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //login page object initialisation
            LoginPage loginPageObject = new LoginPage();
            loginPageObject.LoginMethod(driver);

            //home page object initialisation
            HomePage homePageObject = new HomePage();
            homePageObject.HomePageMethod(driver);

            //TM page object initialisation
            TMPage tmPageObject = new TMPage();
            tmPageObject.TMCreate(driver);
            tmPageObject.EditTM(driver);
            tmPageObject.DeleteTM(driver);




        }
    }
        }


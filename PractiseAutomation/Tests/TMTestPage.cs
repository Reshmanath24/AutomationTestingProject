using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PractiseAutomation.Utilities;
using System;
using System.Threading;
using PractiseAutomation.Pages;

namespace PractiseAutomation.Tests

{ 
    [TestFixture] //similar to test scenarios
    [Parallelizable]
    internal class TMTestPage : CommonDriver
        

        {
            [Test, Order(1), Description("Check whether user is able to create material record")]  //similar to test case
            public void CreateTM_Test()
            {
            //home page object initialisation
            HomePage homePageObject = new HomePage();
            homePageObject.GoToTMPage(driver);

            TMPage tmPageObject = new TMPage();
                tmPageObject.TMCreate(driver);
            }

            [Test,Order(2), Description("Check whether user is able to edit the created record")]
            public void EditTM_Test()
            {
            //home page object initialisation
            HomePage homePageObject = new HomePage();
            homePageObject.GoToTMPage(driver);

            TMPage tmPageObject = new TMPage();
                tmPageObject.EditTM(driver);
            }

            [Test, Order(3), Description("check whether user is able to delete an existing record")]
            public void DeleteTM_Test()
            {
            //home page object initialisation
            HomePage homePageObject = new HomePage();
            homePageObject.GoToTMPage(driver);

            TMPage tmPageObject = new TMPage();
                tmPageObject.DeleteTM(driver);

            }

           
        }
    }


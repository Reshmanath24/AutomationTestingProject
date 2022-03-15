using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PractiseAutomation.Pages;
using PractiseAutomation.Utilities;
using System;
using TechTalk.SpecFlow;

namespace PractiseAutomation
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        //initialising all pages here
        LoginPage loginPageObject = new LoginPage();
        HomePage homePageObject = new HomePage();
        TMPage tmPageObject = new TMPage();

        [Given(@"I logged in successfully to the turnup portal")]
        public void GivenILoggedInSuccessfullyToTheTurnupPortal()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //login page object initialisation
            
            loginPageObject.LoginMethod(driver);
        }

        [Given(@"Navigated to the TM page")]
        public void GivenNavigatedToTheTMPage()
        {
            
            homePageObject.GoToTMPage(driver);
        }

        [When(@"the Time and material was created")]
        public void WhenTheTimeAndMaterialWasCreated()
        {
            
            tmPageObject.TMCreate(driver);
        }

        [Then(@"the record has been created successfully")]
        public void ThenTheRecordHasBeenCreatedSuccessfully()
        {
            
            string newCode = tmPageObject.GetCode(driver);
            string newTypeCode = tmPageObject.GetTypeCode(driver);
            string newDescription = tmPageObject.GetDescription(driver);
            string newPrice = tmPageObject.GetPrice(driver);

            Assert.That(newCode == "PractiseAutomation", "Expected code did not match, test failed");
            Assert.That(newTypeCode == "M", "Expected code did not match,test failed");
            Assert.That(newDescription == "AutomationDescription", "Expected decription did not match,test failed");
            Assert.That(newPrice == "$123.00", "Expected price did not match,test failed");
        }

       
        [When(@"the '([^']*)','([^']*)','([^']*)' field has to be updated in the time and material record")]
        public void WhenTheFieldHasToBeUpdatedInTheTimeAndMaterialRecord(string p0, string p1, string p2)
        {
            tmPageObject.EditTM(driver, p0, p1, p2);
        }

        [Then(@"Need to check the '([^']*)','([^']*)','([^']*)' field has been updated successfully")]
        public void ThenNeedToCheckTheFieldHasBeenUpdatedSuccessfully(string p0, string p1, string p2)
        {
            string getEdittedDescription = tmPageObject.edittedDescription(driver);
            string getEdittedCode = tmPageObject.edittedCode(driver);
            string getEdittedPrice = tmPageObject.edittedPrice(driver);

            Assert.That(getEdittedDescription == p0, "editted description and expected description do not match,Edit failed");
            Assert.That(getEdittedCode == p1, "editted code and expected code do not match,Edit failed");
            Assert.That(getEdittedPrice == p2, "editted price and expected price do not match,Edit failed");

        }




    }
}

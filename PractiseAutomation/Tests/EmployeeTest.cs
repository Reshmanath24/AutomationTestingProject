using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PractiseAutomation.Pages;
using PractiseAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseAutomation.Tests
{
    [TestFixture]
    [Parallelizable]
    internal class EmployeeTest:CommonDriver

    {
       
        [Test, Order(1)]
        
        public void CreateEmployee_Test()
        {
            //home page object initialisation
            HomePage homePageObject = new HomePage();
            homePageObject.GoToEmployeePage(driver);

            EmployeePage employeePageObject = new EmployeePage();
            employeePageObject.CreateEmployee(driver);
        }

        [Test, Order(2)]
       
        public void EditEmployee_Test()
        {
            //home page object initialisation
            HomePage homePageObject = new HomePage();
            homePageObject.GoToEmployeePage(driver);

            EmployeePage employeePageObject = new EmployeePage();
            employeePageObject.EditEmployee(driver);
        }

        [Test, Order(3)]
        
        public void DeleteEmployee_Test()
        {
            //home page object initialisation
            HomePage homePageObject = new HomePage();
            homePageObject.GoToEmployeePage(driver);

            EmployeePage employeePageObject = new EmployeePage();
            employeePageObject.DeleteEmployee(driver);
        }

        

    }
}

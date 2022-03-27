using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Task50
{
    public class CustomObjectsTest
    {
        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Url = "https://demo.seleniumeasy.com/table-sort-search-demo.html";
        }

        [Test]
        public void CustomObjectsReturnListTest()
        {
            Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(15);

            var showEntries = new SelectElement(Driver.FindElement(By.Name("example_length")));
            showEntries.SelectByText("10");
            var employeesList = FindEmployees();
        }

        private List<EmployeeInfo> FindEmployees()
        {
            var employeesList = new List<EmployeeInfo>();
            var nextButton = Driver.FindElement(By.Id("example_next"));
            var i = 0;

            do
            {
                if (i > 0)
                {
                    nextButton.Click();
                }

                FindEmployeesOnPage(employeesList);

                i++;
                nextButton = Driver.FindElement(By.Id("example_next"));

            } while (nextButton.GetCssValue("cursor") != "default");

            return employeesList;
        }

        private void FindEmployeesOnPage(List<EmployeeInfo> employeesList)
        {
            var employees = Driver.FindElements(By.XPath("//table[@id='example']//tbody/*"));
            foreach (var employee in employees)
            {
                var age = employee.FindElement(By.XPath(".//td[4]")).Text;
                var salary = employee.FindElement(By.XPath(".//td[6]")).GetAttribute("data-order");

                if (int.Parse(age) > 38 && int.Parse(salary) < 200000)
                {
                    var newEmp = new EmployeeInfo(
                        employee.FindElement(By.XPath(".//td[1]")).Text,
                        employee.FindElement(By.XPath(".//td[2]")).Text,
                        employee.FindElement(By.XPath(".//td[3]")).Text);
                    employeesList.Add(newEmp);
                }
            }
        }
    }
}
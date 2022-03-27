using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Task50
{
    public class WaitForUserTest
    {
        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Url = "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";
        }

        [Test]
        public void WaitingForUserTest()
        {

            Driver.FindElement(By.Id("save")).Click();

            var wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("loading")));

            Driver.Close();
        }
    }
}

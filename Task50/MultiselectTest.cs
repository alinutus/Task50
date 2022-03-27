using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Task50
{
    public class MultiselectTest
    {
        private IWebDriver Driver;

        [SetUp] 
        public void Setup()
        {
            Driver = new ChromeDriver();
        }

        [Test]
        public void ThreeOptionsSelectedTest()
        {
            Driver.Url = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
            var optionElements = Driver.FindElements(By.XPath("//select[@id='multi-select']//option"));
            var selectedCount = 0;

            for (int i = 0; i < 3; i++)
            {
                optionElements[new Random().Next(optionElements.Count)].Click();
            }

            foreach (var optionElement in optionElements)
            {
                if(optionElement.Selected)
                {
                    selectedCount++;
                }
            }

            var message = "Options count has wrong value";
            Assert.IsTrue(selectedCount == 3, message);
        }

    }
}
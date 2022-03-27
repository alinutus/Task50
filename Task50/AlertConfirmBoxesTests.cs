using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Task50
{
    public class AlertConfirmBoxesTests
    {
        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
        }

        [Test]
        public void AlertBoxTest()
        {
            
            Driver.FindElement(By.XPath("//button[@class='btn btn-default']")).Click();

            var wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(15));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string text = alert.Text.ToString();

            var message = "Alert's text has wrong value";
            var alertText = "I am an alert box!";
            Assert.AreEqual(alertText, text, message);

            alert.Accept();
        }

        [Test]
        public void ConfirmAlertBoxTest()
        {
            Driver.FindElement(By.XPath("//button[@class='btn btn-default btn-lg']")).Click();

            var wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(15));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string text = alert.Text.ToString();

            var message = "Alert's text has wrong value";
            var alertText = "Press a button!";
            Assert.AreEqual(alertText, text, message);

            alert.Dismiss();

            var myConfirmText = Driver.FindElement(By.Id("confirm-demo")).Text.ToString();
            var confirmText = "You pressed Cancel!";
            var errorMessage = "Confirmed text has wrong value";
            Assert.AreEqual(myConfirmText, confirmText, errorMessage);
        }

        [Test]
        public void PromptAlertBoxTest()
        {
            Driver.FindElement(By.XPath("//button[@onClick='myPromptFunction()']")).Click();

            var wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(15));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string text = alert.Text.ToString();

            var message = "Alert's text has wrong value";
            var alertText = "Please enter your name";
            Assert.AreEqual(alertText, text, message);

            alert.SendKeys("Alina");
            alert.Accept();

            var myConfirmText = Driver.FindElement(By.Id("prompt-demo")).Text.ToString();
            var confirmText = "You have entered 'Alina' !";
            var errorMessage = "Confirmed text has wrong value";
            Assert.AreEqual(myConfirmText, confirmText, errorMessage);
        }
    }
}
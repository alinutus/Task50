using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Task50
{
    public class YandexLoginTests
    {
        private static readonly By USERNAME_FIRST_LETTER = By.ClassName("username__first-letter");

        private IWebDriver Driver;

        [Test]
        [TestCase("alinutus@yandex.ru", "coherent1")]
        [TestCase("autolilia", "coherent1")]
        public void LogIn(string name, string password)
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(15);

        
            Driver.Url = "https://yandex.by";
            IWebElement loginButtonFirst = Driver.FindElement(By.XPath("//a[@data-statlog='notifications.mail.logout.enter']"));
            loginButtonFirst.Click();

            IWebElement loginNameTextField = Driver.FindElement(By.XPath("//span/input[@type='text']"));
            loginNameTextField.SendKeys(name);

            IWebElement loginButtonSecond = Driver.FindElement(By.Id("passp:sign-in"));
            loginButtonSecond.Click();

            Thread.Sleep(1000);

            IWebElement passwordTextField = Driver.FindElement(By.Name("passwd"));
            passwordTextField.SendKeys(password);

            IWebElement loginButtonThird = Driver.FindElement(By.Id("passp:sign-in"));
            loginButtonThird.Click();

            Thread.Sleep(1000);

            var wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(15));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = Driver.FindElement(USERNAME_FIRST_LETTER);
                    return elementToBeDisplayed.Text == "A" || elementToBeDisplayed.Text == "a";
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
            );

            var loginElement = Driver.FindElement(By.ClassName("username__first-letter")).Text;
            Assert.AreEqual("A", loginElement);
        }
    }      
 }
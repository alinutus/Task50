using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    public class DownloadButtonTest
    {
        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Url = "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";
        }

        [Test]
        public void PageRefreshWhenPersentageIsMore50Test()
        {

            Driver.FindElement(By.Id("cricle-btn")).Click();

            IWebElement element = Driver.FindElement(By.ClassName("percenttext"));
            var wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, "50"));

            Driver.Navigate().Refresh();
        }
    }
}

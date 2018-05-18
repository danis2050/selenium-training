using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace seleniumtraining
{
    [TestFixture]
    public class MyTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTest()
        {
            
            driver.Navigate().GoToUrl("http://www.google.ru/");
            driver.FindElement(By.Id("lst-ib")).SendKeys("software-testing.ru");
            driver.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
           
        }

        [TearDown]

        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;


namespace seleniumtraining
{
    [TestFixture]
    public class MyTestsFireFox
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            
            FirefoxBinary binary = new FirefoxBinary(@"C:\Program Files\Mozilla Firefox\firefox.exe");
            driver = new FirefoxDriver(binary, new FirefoxProfile());
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTestFF()
        {

            driver.Navigate().GoToUrl("http://www.google.ru/");
            driver.FindElement(By.Id("lst-ib")).SendKeys("software-testing.ru");
            driver.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);

        }

        [Test]
        public void LoginFF()
        {

            driver.Navigate().GoToUrl("http://localhost/litecart/admin/login.php");
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

        }

        [TearDown]

        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}

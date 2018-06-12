using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using OpenQA;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using System.Linq;


namespace seleniumtraining
{
    [TestFixture]
    public class MyTestEvents
    {
        private EventFiringWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new EventFiringWebDriver (new ChromeDriver());
            driver.FindingElement += Driver_FindingElements;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Driver_FindingElements(object sender, FindElementEventArgs e)
        {
            Console.WriteLine(e.FindMethod);
        }

        [Test]
        public void FirstTestEvent()
        {

            driver.Navigate().GoToUrl("http://www.google.ru/");
            
            driver.FindElement(By.Id("lst-ib")).SendKeys("software-testing.ru");
            driver.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);

        }

        [TearDown]
        public void stop()
        {
            //driver.Quit();
            //driver = null;
        }
    }
}

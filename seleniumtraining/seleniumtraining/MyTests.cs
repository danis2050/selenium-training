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

        [Test]
        public void Login()
        {

            driver.Navigate().GoToUrl("http://localhost/litecart/admin/login.php");
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

        }
		
		[Test]
        public void Menu()
        {

            driver.Navigate().GoToUrl("http://localhost/litecart/admin/login.php");
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
                     
            IList<IWebElement> Elements = driver.FindElements(By.XPath("//ul[@id='box-apps-menu']/li"));

            for(int i=1; i<= Elements.Count; i++ )
            {
                string xp = "//ul[@id='box-apps-menu']/li[" + i + "]";
                driver.FindElement(By.XPath(xp)).Click();

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(driver.FindElement(By.CssSelector("h1")).Enabled);
               

                IList<IWebElement> ElementsInto = driver.FindElements(By.XPath(xp + "/ul/li"));

                for (int n = 1; n <= ElementsInto.Count; n++)
                {
                    string xpinto = xp + "/ul/li[" + n + "]";
                    driver.FindElement(By.XPath(xpinto)).Click();
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(driver.FindElement(By.CssSelector("h1")).Enabled);

                }
            }

           

        }

        [TearDown]

        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}

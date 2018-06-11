using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using System.Linq;


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
		
		[Test]
        public void Stickers()
        {

            driver.Navigate().GoToUrl("http://localhost/litecart");

            string[] Locators = { "//div[@id='box-most-popular']", "//div[@id='box-campaigns']", "//div[@id='box-latest-products']" };

            int z = 0;

            for (int j = 0; j <= 2; j++)
            {

                
                IList<IWebElement> PopularElements = driver.FindElements(By.XPath(Locators[j] +"/div/ul/li"));

                for (int i = 1; i <= PopularElements.Count; i++)
                {
                    string xp = Locators[j] + "/div/ul/li[" + i + "]/a/div/div";
                    IList<IWebElement> Stickers = driver.FindElements(By.XPath(xp));
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, Stickers.Count);

                    z = z + 1;
                }

            }

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(11, z);

          
        }

        [Test]
        public void StickersNew()
        {
            driver.Navigate().GoToUrl("http://localhost/litecart");

            IList<IWebElement> Elements = driver.FindElements(By.CssSelector("div.image-wrapper"));

            foreach (IWebElement Element in Elements)
            {
                IList<IWebElement> Stickers = Element.FindElements(By.CssSelector("div"));
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, Stickers.Count);
            }

        }


        [Test]
        public void Countries()
        {

            driver.Navigate().GoToUrl("http://localhost/litecart/admin/login.php");
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=countries&doc=countries");

            //IList<IWebElement> Elements = driver.FindElements(By.XPath("//table[@class='dataTable']/tbody/tr[@class='row']/td[5]/a"));
            IList<IWebElement> Elements = driver.FindElements(By.XPath("//table[@class='dataTable']/tbody/tr[@class='row']"));
            List<string> Lt1 = new List<string>();
            List<string> Lt2 = new List<string>();
            StreamWriter sw = new StreamWriter("C:\\Countries.txt");
            foreach (IWebElement Element in Elements)
            {
                string t = Element.FindElement(By.XPath(".//td[5]/a")).GetAttribute("text");
                Lt1.Add(t);
                Lt2.Add(t);
                sw.WriteLine(t);
            }
            sw.Close();
            Lt2.Sort();

            for (int i = 0; i < Lt1.Count; i++)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(Lt1[i], Lt2[i]);
            }

        }

        [Test]
        public void Countries1()
        {
            driver.Navigate().GoToUrl("http://localhost/litecart/admin/login.php");
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=countries&doc=countries");
            
            IList<IWebElement> Elements = driver.FindElements(By.XPath("//table[@class='dataTable']/tbody/tr[@class='row']"));
            List<string> Lt1 = new List<string>();
            List<string> Lt2 = new List<string>();
            List<string> LtZone1 = new List<string>();
            List<string> LtZone2 = new List<string>();
            List<string> LinkZone = new List<string>();
            StreamWriter sw = new StreamWriter("C:\\Countries.txt");
            foreach (IWebElement Element in Elements)
            {
                string t = Element.FindElement(By.XPath(".//td[5]/a")).GetAttribute("text");
                Lt1.Add(t);
                Lt2.Add(t);
                sw.WriteLine(t);
                
                 if (Convert.ToInt32(Element.FindElement(By.XPath(".//td[6]")).GetAttribute("textContent")) > 0)
                 {
                     LinkZone.Add(Element.FindElement(By.XPath(".//td[5]/a")).GetAttribute("href"));
                 }
            }

            Lt2.Sort();


            for (int i = 0; i < Lt1.Count; i++)
            {
                if (Lt1[i] != Lt2[i])
                {
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Страны отличаются");
                }

            }

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, LinkZone.Count);

            foreach (string link in LinkZone)
            {
                driver.Navigate().GoToUrl(link);
                Thread.Sleep(5000);
                IList<IWebElement> Elements1 = driver.FindElements(By.XPath("//table[@id='table-zones']/tbody/tr/td[3]/input"));
                
                foreach (IWebElement Element in Elements1)
                {
                    string t1 = Element.GetAttribute("Value");
                    LtZone1.Add(t1);
                    LtZone2.Add(t1);
                    sw.WriteLine(t1);
                }                                             
            }

            sw.Close();
        }

        [Test]
        public void CountriesAndZones()
        {
            driver.Navigate().GoToUrl("http://localhost/litecart/admin/login.php");
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=countries&doc=countries");

            IList<IWebElement> Elements = driver.FindElements(By.XPath("//table[@class='dataTable']/tbody/tr[@class='row']"));
            List<string> Lt1 = new List<string>();
            List<string> Lt2 = new List<string>();
            List<string> LtZone1 = new List<string>();
            List<string> LtZone2 = new List<string>();
            List<string> LinkZone = new List<string>();
            StreamWriter sw = new StreamWriter("C:\\Countries.txt");
            foreach (IWebElement Element in Elements)
            {
                string t = Element.FindElement(By.XPath(".//td[5]/a")).GetAttribute("text");
                Lt1.Add(t);
                Lt2.Add(t);
                sw.WriteLine(t);

                if (Convert.ToInt32(Element.FindElement(By.XPath(".//td[6]")).GetAttribute("textContent")) > 0)
                {
                    LinkZone.Add(Element.FindElement(By.XPath(".//td[5]/a")).GetAttribute("href"));
                }
            }

            Lt2.Sort();


            for (int i = 0; i < Lt1.Count; i++)
            {
                if (Lt1[i] != Lt2[i])
                {
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Страны отличаются");
                }

            }

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, LinkZone.Count);

            foreach (string link in LinkZone)
            {
                driver.Navigate().GoToUrl(link);
                Thread.Sleep(5000);
                IList<IWebElement> Elements1 = driver.FindElements(By.XPath("//table[@id='table-zones']/tbody/tr/td[3]/input"));

                foreach (IWebElement Element in Elements1)
                {
                    string t1 = Element.GetAttribute("Value");
                    LtZone1.Add(t1);
                    LtZone2.Add(t1);
                    sw.WriteLine(t1);
                }
            }

            sw.Close();
        }
		
		[Test]
        public void CreateAccount()
        {
            driver.Navigate().GoToUrl("http://localhost/litecart/en/create_account");
            driver.FindElement(By.CssSelector("input[name='firstname']")).SendKeys("Nick1");
            driver.FindElement(By.CssSelector("input[name='lastname']")).SendKeys("Apple1");
            driver.FindElement(By.CssSelector("input[name='address1']")).SendKeys("Street 1-5");
            driver.FindElement(By.CssSelector("input[name='postcode']")).SendKeys("12894");
            driver.FindElement(By.CssSelector("input[name='city']")).SendKeys("Atlanta");            
            new SelectElement(driver.FindElement(By.CssSelector("select[name='country_code']"))).SelectByText("United States");
            new SelectElement(driver.FindElement(By.CssSelector("select[name='zone_code']"))).SelectByText("Georgia");
            driver.FindElement(By.CssSelector("input[name='email']")).SendKeys("danis2054@gmail.com");
            driver.FindElement(By.CssSelector("input[name='phone']")).SendKeys("+79162001450");
            driver.FindElement(By.CssSelector("input[name='password']")).SendKeys("12345");
            driver.FindElement(By.CssSelector("input[name='confirmed_password']")).SendKeys("12345");
            driver.FindElement(By.CssSelector("button[name='create_account']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//ul[@class='list-vertical']/li[4]/a")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("input[name='email']")).SendKeys("danis2054@gmail.com");
            driver.FindElement(By.CssSelector("input[name='password']")).SendKeys("12345");
            driver.FindElement(By.CssSelector("button[name='login']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//ul[@class='list-vertical']/li[4]/a")).Click();
        }

        [Test]
        public void CreateAccountNew()
        {
            driver.Navigate().GoToUrl("http://localhost/litecart/en/create_account");
            driver.FindElement(By.CssSelector("input[name='firstname']")).SendKeys("Nick1");
            driver.FindElement(By.CssSelector("input[name='lastname']")).SendKeys("Apple1");
            driver.FindElement(By.CssSelector("input[name='address1']")).SendKeys("Street 1-5");
            driver.FindElement(By.CssSelector("input[name='postcode']")).SendKeys("12894");
            driver.FindElement(By.CssSelector("input[name='city']")).SendKeys("Atlanta");
            new SelectElement(driver.FindElement(By.CssSelector("select[name='country_code']"))).SelectByText("United States");
            Thread.Sleep(2000);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='zone_code']"))).SelectByText("Georgia");
            Random rand = new Random();
            string email = "danis" + Convert.ToString(rand.Next(10000000)) + "@gmail.com";
            driver.FindElement(By.CssSelector("input[name='email']")).SendKeys(email);
            driver.FindElement(By.CssSelector("input[name='phone']")).SendKeys("+79162001450");
            driver.FindElement(By.CssSelector("input[name='password']")).SendKeys("12345");
            driver.FindElement(By.CssSelector("input[name='confirmed_password']")).SendKeys("12345");
            driver.FindElement(By.CssSelector("button[name='create_account']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//ul[@class='list-vertical']/li[4]/a")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("input[name='email']")).SendKeys(email);
            driver.FindElement(By.CssSelector("input[name='password']")).SendKeys("12345");
            driver.FindElement(By.CssSelector("button[name='login']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//ul[@class='list-vertical']/li[4]/a")).Click();
        }

        [Test]
        public void AddToCart()
        {
            driver.Navigate().GoToUrl("http://localhost/litecart");
            // Зеленая утка. Добавление в корзину 
            driver.FindElement(By.CssSelector("img.image[alt='Green Duck']")).Click();
            string quantity = driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("textContent");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(quantity, "0");           
            driver.FindElement(By.CssSelector("button[name='add_cart_product']")).Click();
            wait.Until(d => (d.FindElement(By.CssSelector("span.quantity")).GetAttribute("textContent"))=="1");
            // Голубая утка. Добавление в корзину  
            driver.FindElement(By.CssSelector("img.image[alt='Blue Duck']")).Click();
            driver.FindElement(By.CssSelector("button[name='add_cart_product']")).Click();
            wait.Until(d => (d.FindElement(By.CssSelector("span.quantity")).GetAttribute("textContent")) == "2");
            // Фиолетовая утка. Добавление в корзину
            driver.FindElement(By.CssSelector("img.image[alt='Purple Duck']")).Click();
            driver.FindElement(By.CssSelector("button[name='add_cart_product']")).Click();
            wait.Until(d => (d.FindElement(By.CssSelector("span.quantity")).GetAttribute("textContent")) == "3");
            driver.FindElement(By.CssSelector("div#cart a.image")).Click();
            //Удаляем уточки
            driver.FindElement(By.CssSelector("button[name='remove_cart_item']")).Click();
            wait.Until(d => (d.FindElements(By.CssSelector("td.item")).Count) == 2);
            driver.FindElement(By.CssSelector("button[name='remove_cart_item']")).Click();
            wait.Until(d => (d.FindElements(By.CssSelector("td.item")).Count) == 1);
            driver.FindElement(By.CssSelector("button[name='remove_cart_item']")).Click();          
        }

		[Test]
		public void OpenWindows()
		{
			driver.Navigate().GoToUrl("http://localhost/litecart/admin/login.php");
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();
			driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=countries&doc=countries");
			// открываем первую страну - Афганистан
			driver.FindElement(By.CssSelector("tr.row a")).Click();
			// находим элементы, на которые будем кликать 
			ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tbody>tr>td>a[target='_blank']"));

			string mainWindow = driver.CurrentWindowHandle;
			ICollection<string> oldWindows = driver.WindowHandles;
			foreach (IWebElement element in elements)
			{
				element.Click();
				// ожидание в течение 10 секунд появление нового окна. у нас есть уже одно открытое окно, поэтому ждем второе окно
				wait.Until(d => (d.WindowHandles.Count > 1));
				ICollection<string> newdWindows = driver.WindowHandles;
				// находим разность двух коллекций
				IEnumerable<string> diff = newdWindows.Except(oldWindows);
				// получаем handler нового окна
				string newWindow = diff.ToList()[0];
				driver.SwitchTo().Window(newWindow);
				// окна открываются и закрываются быстро, поэтому я ввел эту паузу, чтобы визуально было видно, что тест отрабатывает, открывает и закрывает окна 
				Thread.Sleep(2000);
				driver.Close();
				driver.SwitchTo().Window(mainWindow);

			}
		}

        [Test]
        public void GeoZones()
        {
            driver.Navigate().GoToUrl("http://localhost/litecart/admin/login.php");
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            // Канада
            driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones");
            driver.FindElement(By.XPath("//a[contains(text(),'Canada')]")).Click();
            IList<IWebElement> elements = driver.FindElements(By.XPath("//table[@id='table-zones']/tbody/tr/td[3]/select/option[@selected='selected']"));
            List<string> Lt1 = new List<string>();
            List<string> Lt2 = new List<string>();
            StreamWriter sw = new StreamWriter("C:\\Zones.txt");
            foreach (IWebElement element in elements)
            {
                string t = element.GetAttribute("text");
                Lt1.Add(t);
                Lt2.Add(t);
                sw.WriteLine(t);
            }
            Lt2.Sort();
            for (int i = 0; i < Lt1.Count; i++)
            {
                if (Lt1[i] != Lt2[i])
                {
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Список зон для Канады неупорядочен");
                }
            }
            sw.Close();

            // США
            driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones");
            driver.FindElement(By.XPath("//a[contains(text(),'United States of America')]")).Click();
            IList<IWebElement> elements1 = driver.FindElements(By.XPath("//table[@id='table-zones']/tbody/tr/td[3]/select/option[@selected='selected']"));
            List<string> Lt3 = new List<string>();
            List<string> Lt4 = new List<string>();
            StreamWriter sw1 = new StreamWriter("C:\\Zones1.txt");
            foreach (IWebElement element in elements1)
            {
                string t = element.GetAttribute("textContent");
                Lt3.Add(t);
                Lt4.Add(t);
                sw1.WriteLine(t);
            }
            Lt4.Sort();
            for (int i = 0; i < Lt3.Count; i++)
            {
                if (Lt3[i] != Lt4[i])
                {
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Список зон для США неупорядочен");
                }
            }
            sw1.Close();
        }


		[TearDown]
        public void stop()
        {
           //driver.Quit();
           //driver = null;
        }
    }
}

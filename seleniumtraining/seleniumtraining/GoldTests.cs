using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace seleniumtraining
{
	[TestFixture]
	public class GoldTests
	{
		private IWebDriver driver;
		private WebDriverWait wait;

		[SetUp]
		public void start()
		{
			driver = new ChromeDriver();
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Manage().Window.Maximize();
		}

		#region Автотесты LoginByCard и LoginByPhone

		/// <summary>
		/// Логин на сайт по номеру карты
		/// card = "1120000057033873"
		/// </summary>

		[Test]
		public void LoginByCard()
		{
			driver.Navigate().GoToUrl("https://zoloto585.ru/");
			driver.FindElement(By.CssSelector("#app>header>div.section.header-middle>div>div.header-middle__login>div.header-middle__login-block>div>a:nth-child(1)")).Click();
			driver.FindElement(By.Name("cardNumber")).Click();
			driver.FindElement(By.Name("cardNumber")).SendKeys(Keys.Home + "1120000057033873");
			driver.FindElement(By.CssSelector("button.reg-card-content__form-btn")).Click();
			Assert.AreEqual("1120000057033873", driver.FindElement(By.CssSelector("#app>header>div.section.header-middle>div>div.header-middle__login>div.header-middle__login-block>div.auth>div.card")).Text);
		}


		/// <summary>
		/// Логин на сайт по номеру мобильного телефона
		/// phone = "79162001459"
		/// </summary>

		[Test]
		public void LoginByPhone()
		{
			driver.Navigate().GoToUrl("https://zoloto585.ru/");
			driver.FindElement(By.CssSelector("#app>header>div.section.header-middle>div>div.header-middle__login>div.header-middle__login-block>div>a:nth-child(1)")).Click();
			driver.FindElement(By.CssSelector("#app>div.v--modal-overlay>div.v--modal-box.v--modal>div>div.reg-card-content__form>form>div:nth-child(4)>a")).Click();
			driver.FindElement(By.Name("phone")).Click();
			driver.FindElement(By.Name("phone")).SendKeys(Keys.Home + "79162001459");
			driver.FindElement(By.CssSelector("button.reg-card-content__form-btn")).Click();
			Assert.AreEqual("1120000057033873", driver.FindElement(By.CssSelector("#app>header>div.section.header-middle>div>div.header-middle__login>div.header-middle__login-block>div.auth>div.card")).Text);
		}

		#endregion


		[TearDown]
		public void stop()
		{
			driver.Quit();
			driver = null;
		}

	}
}

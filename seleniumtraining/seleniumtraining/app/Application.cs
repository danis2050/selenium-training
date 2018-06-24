using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumtraining
{
    public class Application
    {
        private IWebDriver driver;
        private MainPage mainPage;
        private ProductPage productPage;
        private CheckoutPage checkoutPage;

        public Application()
        {
            driver = new ChromeDriver();
            mainPage = new MainPage(driver);
            productPage = new ProductPage(driver);
            checkoutPage = new CheckoutPage(driver);
            
        }

        public void AddToCart(string productname)
        {
            mainPage.Open();
            mainPage.FindAndClickDuck(productname);
        }

        public void Quit()
        {
            driver.Quit();
        }

    }
}

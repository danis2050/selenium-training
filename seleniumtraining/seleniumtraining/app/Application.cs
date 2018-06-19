using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumtraining
{
    public class Application
    {
        private IWebDriver driver;

        public Application()
        {
            driver = new ChromeDriver();
            
        }

        public void Quit()
        {
            driver.Quit();
        }

    }
}

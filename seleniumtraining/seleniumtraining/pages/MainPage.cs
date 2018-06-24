using System;
using OpenQA.Selenium;

namespace seleniumtraining
{
    internal class MainPage: Page
    {
       public MainPage(IWebDriver driver): base(driver)
        {

        }

       internal void Open()
       {
           driver.Url = "http://localhost/litecart";
       }

       internal void FindAndClickDuck(string duckname)
       {
           string selector = $"img.image[alt='{duckname}']";
           driver.FindElement(By.CssSelector(selector)).Click();
       }
    }
}

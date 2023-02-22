using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitachiProject.Common
{
    public class Search
    {
        By searchButtonBy = By.Id("open-global-search");
        By searchBoxBy = By.Id("site-search-keyword");

        public Search() { }
        public void GlobalSearch(string keyword, IWebDriver driver) {
            // Find the search box and enter the search keywords
            driver.FindElement(searchButtonBy).Click();
            driver.FindElement(searchBoxBy).SendKeys(keyword);
            driver.FindElement(searchBoxBy).SendKeys(Keys.Enter);
            Thread.Sleep(4000);
        }

        public void ClickOnPageButton(string pageNumber, IWebDriver driver) {

            IWebElement PageNumber = driver.FindElement(By.XPath("//a[@class='page-numbers' and text()="+pageNumber+ "]"));
            PageNumber.SendKeys(""); //Hilighting the element
            Thread.Sleep(2000);
            PageNumber.Click();
            Thread.Sleep(3000);

        }
    }
}

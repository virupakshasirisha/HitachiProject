using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitachiProject.Common
{
    public class Navigation
    {
        public Navigation() { }
        public void NavigateToApplication(string url, IWebDriver driver) {
            driver.Navigate().GoToUrl(url);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStrefaKursow
{
    internal class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        private By name = By.CssSelector("div[class='b-user-section-user u-mr-30']");
        public IWebElement Name => driver.FindElement(name);

        public string NameToText => Name.Text;

        public void GoToUserName()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(c => c.FindElement(name));
            
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TestStrefaKursow
{
    internal class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By login = By.XPath("//*[text()='Zaloguj się']");
        private IWebElement BtnLogin => driver.FindElement(login);

        private By privacyPolicy = By.CssSelector("button[class='cm-btn cm-btn-success cm-btn-accept-all']");
        private By newsletter = By.CssSelector("span[class='b-newsletter-popup__no u-mr-25']");

        private IWebElement PrivacyPolicyBtn => driver.FindElement(privacyPolicy);
        private IWebElement NewsletterBtn => driver.FindElement(newsletter);

        private By email = By.Id("customer_login");

        private IWebElement Email => driver.FindElement(email);

        private By passwd = By.Id("customer_password");
        private IWebElement Passwd => driver.FindElement(passwd);

        private By loginClick = By.CssSelector("button[class='c-btn-standard c-btn-standard--primary c-btn-standard__height-50 u-text-align--center']");

        private IWebElement BtnLoginClick => driver.FindElement(loginClick);

        public void GoToLogin()
        {

            BtnLogin.Click();
        }

        public void GoToPrivacyPolicy()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(c => c.FindElement(privacyPolicy));
            PrivacyPolicyBtn.Click();
        }

        protected void WaitUntilElementNotVisible(By searchElementBy, int timeoutInSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                            .Until(drv => !IsElementVisible(searchElementBy));
        }

        private bool IsElementVisible(By searchElementBy)
        {
            try
            {
                return driver.FindElement(searchElementBy).Displayed;

            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void GoToNewsletter()
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(14));
            //wait.Until(c => c.FindElement(newsletter));
            WaitUntilElementNotVisible(newsletter,10);
            if(IsElementVisible(newsletter))
            NewsletterBtn.Click();
        }

        public void LoginToApp(string email, string passwd)
        {
            Email.SendKeys(email);
            Passwd.SendKeys(passwd);
            BtnLoginClick.Click();
        }

    }
}

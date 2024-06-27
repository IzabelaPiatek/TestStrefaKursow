using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestStrefaKursow
{
    internal class SettingsPage
    {
        private IWebDriver driver;

        private By companyName = By.Id("customer_invoice_company_name");
        private By numberNIP = By.Id("customer_invoice_nip");
        private By streetName = By.Id("customer_invoice_street_name");
        private By buildingNumber = By.Id("customer_invoice_building_number");
        private By postalCode = By.Id("customer_invoice_postal_code");
        private By cityName = By.Id("customer_invoice_city");
        private IWebElement CompanyNameFill => driver.FindElement(companyName);
        private IWebElement NumberNIPFill => driver.FindElement(numberNIP);
        private IWebElement StreetNameFill => driver.FindElement(streetName);
        private IWebElement BuildingNumberFill => driver.FindElement(buildingNumber);
        private IWebElement PostalCodeFill => driver.FindElement(postalCode);
        private IWebElement CityNameFill => driver.FindElement(cityName);

        private By saveChange = By.CssSelector("button[class='c-btn-standard c-btn-standard--primary c-btn-standard__height-50 u-text-align--center u-mt-20']");
        private IWebElement BtnSaveChange => driver.FindElement(saveChange);

        private By saveChangePopUp = By.CssSelector("span[class='u-ml-15 u-flex-grow-2']");
        private IWebElement PopUPSaveChange => driver.FindElement(saveChangePopUp);

        public string PopUPSaveChangeToText => PopUPSaveChange.Text;

        public SettingsPage(IWebDriver browser)
        {
            driver = browser;
        }
        public void FillDataToFV(string companyName,  string numberNIP, string streetName, string buildingNumber, string postalCode, string cityName)
        {
            CompanyNameFill.Clear();
            CompanyNameFill.SendKeys(companyName);
            NumberNIPFill.Clear();
            NumberNIPFill.SendKeys(numberNIP);
            StreetNameFill.Clear();
            StreetNameFill.SendKeys(streetName);
            BuildingNumberFill.Clear();
            BuildingNumberFill.SendKeys(buildingNumber);
            PostalCodeFill.Clear();
            PostalCodeFill.SendKeys(postalCode);
            CityNameFill.Clear();
            CityNameFill.SendKeys(cityName);

            BtnSaveChange.Click();
        }

        public void CheckSaveChanges()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(c => c.FindElement(saveChangePopUp));
        }

    }
}

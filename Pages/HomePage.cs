using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp_SeleniumDemo.Pages
{
    internal class HomePage
    {
        private IWebDriver driver;
        

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ForeNameInput => driver.FindElement(By.Id("forename"));
        private IWebElement SubmitButton => driver.FindElement(By.Id("submit"));
        private IWebElement PopUpElement => driver.FindElement(By.ClassName("popup-message"));
        

        public void SubmitForeName(string foreName)
        {
            ForeNameInput.SendKeys(foreName);
            SubmitButton.Click();
            IsPopUpElementDisplayed();
        }

        public string GetPopUpText()
        {
            IsPopUpElementDisplayed();
            return PopUpElement.Text;
        }

        private bool IsPopUpElementDisplayed()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => PopUpElement.Displayed);
        }

    }
}

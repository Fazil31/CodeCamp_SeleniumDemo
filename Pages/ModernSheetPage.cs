using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp_SeleniumDemo.Pages
{
    public class ModernSheetPage
    {

        private IWebDriver driver;
        
        public ModernSheetPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Name => driver.FindElement(By.Id("name"));
        private IWebElement Email => driver.FindElement(By.Id("email"));
        private IWebElement StateDropDown => driver.FindElement(By.Id("state"));
        private IWebElement DoYouAgree => driver.FindElement(By.ClassName("v-input--selection-controls__ripple"));
        private IWebElement Submit => driver.FindElement(By.XPath("//span[contains(text(),'submit')]"));
        private IWebElement PopUpElement => driver.FindElement(By.ClassName("popup-message"));




        internal void EnterName(string name)
        {
            Name.SendKeys(name);
        }
        internal void EnterEmail(string email)
        {
            Email.SendKeys(email);
        }
        internal void SelectState(State state)
        {
            StateDropDown.SendKeys(state.ToString());
        }
        internal void CheckDoYouAgree()
        {
            DoYouAgree.Click();
        }

        public void SubmitUserInfo()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector("span.v-btn__content")));
            ReadOnlyCollection<IWebElement> spanElements = driver.FindElements(By.CssSelector("span.v-btn__content"));

            IWebElement submitButton = null;
            foreach (IWebElement spanElement in spanElements)
            {                
                if (spanElement.Text == "SUBMIT")
                {
                    submitButton = spanElement;
                    break;
                }
            }
            //Submit.Click();
            submitButton.Click();
        }

        public string GetPopUpText()
        {
            IsPopUpElementDisplayed();
            return PopUpElement.Text;
        }

        private bool IsPopUpElementDisplayed()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => PopUpElement.Displayed);
        }

        public enum State
        {
            NSW,
            VIC,
            QLD,
            NT,
            SA,
            WA,
            TAS
        }
    }
}

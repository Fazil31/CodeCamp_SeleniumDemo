using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp_SeleniumDemo.Models
{
    public class PopUp
    {
        IWebDriver driver;

        public PopUp(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement PopUpElement => driver.FindElement(By.ClassName("popup-message"));


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

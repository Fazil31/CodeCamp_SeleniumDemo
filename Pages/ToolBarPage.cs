using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CodeCamp_SeleniumDemo
{
    internal class ToolBarPage
    {
        private IWebDriver driver;

        public ToolBarPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Forms { get => driver.FindElement(By.ClassName("v-toolbar__items"))
                                                 .FindElement(By.CssSelector("[aria-label=\"forms\"]"));}

        private IWebElement Planets { get => driver.FindElement(By.ClassName("v-toolbar__items"))
                                                 .FindElement(By.CssSelector("[aria-label=\"planets\"]"));
        }

        internal void NavigateToForms()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => Forms.Displayed);
            Forms.Click();
        }

        internal void NavigateToPlanets()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => Planets.Displayed);
            Planets.Click();
        }
    }
}
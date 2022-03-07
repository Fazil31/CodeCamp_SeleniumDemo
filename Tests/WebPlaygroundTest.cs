using CodeCamp_SeleniumDemo.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace CodeCamp_SeleniumDemo
{
    [TestClass]
    public class WebPlaygroundTest
    {
        IWebDriver? driver;
        WebDriverWait? wait;

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
            //driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver?.Quit();
        }

        [Ignore]
        [TestCategory("Smoke")]
        [TestMethod]
        public void PlayGround_VerifyHomePage()
        {
            //act
            wait.Until(ExpectedConditions.ElementExists(By.TagName("h1")));
            ReadOnlyCollection<IWebElement> headerElements = driver.FindElements(By.TagName("h1"));

            IWebElement foundHeader = null;
            foreach (IWebElement headerElement in headerElements)
            {
                if(headerElement.Text == "Web Playground")
                {
                    foundHeader = headerElement;
                    break;
                }
            }
            //assert
            Assert.IsTrue(foundHeader?.Displayed);
            
        }

        [Ignore]
        [TestMethod]
        public void PlayGround_VerifyForename()
        {
            const string name = "FAH";
            //arrange
            HomePage homePage = new HomePage(driver);

            //act
            homePage.SubmitForeName(name);

            //assert
            Assert.AreEqual(expected: $"Hello {name}", actual: homePage.GetPopUpText());
        }
        
    }
}
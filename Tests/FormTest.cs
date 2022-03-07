using CodeCamp_SeleniumDemo.Bases;
using CodeCamp_SeleniumDemo.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CodeCamp_SeleniumDemo.Pages.ModernSheetPage;

namespace CodeCamp_SeleniumDemo.Tests
{
    [TestClass]
    public class FormTest
    {
        IWebDriver driver;
        WebDriverWait wait;

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
        [TestMethod]
        public void PlayGround_VerifyFeedback()
        {
            const string name = "FAH";
            const string email = "nobody@nobody.com";
            const string state = "SA";

            //arrange
            new ToolBarPage(driver).NavigateToForms();
            ModernSheetPage modernSheet = new ModernSheetPage(driver);
            
            //act
            modernSheet.EnterName(name);
            modernSheet.EnterEmail(email);
            modernSheet.SelectState(State.SA);
            modernSheet.CheckDoYouAgree();
            modernSheet.SubmitUserInfo();         

            //assert
            Assert.AreEqual(expected: $"Thanks for your feedback {name}", actual: modernSheet.GetPopUpText());
        }
    }
}

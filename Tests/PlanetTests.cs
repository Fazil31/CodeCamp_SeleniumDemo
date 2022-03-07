using CodeCamp_SeleniumDemo.Models;
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
using System.Threading.Tasks;

namespace CodeCamp_SeleniumDemo.Tests
{
    [TestClass]
    public class PlanetTests
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
        [TestMethod]
        public void PlayGround_VerifyExploreEarth()
        {
            //arrange
            new ToolBarPage(driver).NavigateToPlanets();

            //act
            PlanetsPage planetPage = new PlanetsPage(driver);
            Planet earth = planetPage.GetPlanet(p => p.PlanetName == "Earth");
            earth.ExploreButton.Click();

            //Assert
            Assert.AreEqual(planetPage.PopUp.GetPopUpText(), "Exploring Earth");
        }
        
        [Ignore]
        [TestMethod]
        public void PlayGround_VerifyEarthDistance()
        {
            //arrange
            new ToolBarPage(driver).NavigateToPlanets();

            //act
            PlanetsPage planetsPage = new (driver);
            Planet foundPlanet = planetsPage.GetPlanet(p => p.PlanetDistance.Equals(149600000));

            //assert
            Assert.AreEqual("Earth", foundPlanet.PlanetName);

        }

    }
}

using CodeCamp_SeleniumDemo.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp_SeleniumDemo.Pages
{
    public class PlanetsPage
    {
        private IWebDriver driver;

        public PlanetsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement PopUpElement => driver.FindElement(By.ClassName("popup-message"));
        private ReadOnlyCollection<IWebElement> AllPlanets => driver.FindElements(By.CssSelector("li.planet"));

        public PopUp PopUp => new PopUp(driver);

        public IEnumerable<Planet> GetPlanets()
        {
            var allPlanets = driver.FindElements(By.CssSelector("li.planet"));

            foreach (var planet in AllPlanets) 
            {
                yield return new Planet(planet);
            }
        }

        public Planet GetPlanetOldCopy(string planetName)
        {
            foreach (var planet in GetPlanets())
            {
                if (planet.PlanetName == planetName)
                {
                    return planet;
                }
            }
            throw new NotFoundException($"{planetName} not found.");
        }

        public Planet GetPlanet(Predicate<Planet> matchStrategy)
        {
            foreach (var planet in GetPlanets())
            {
                if (matchStrategy.Invoke(planet))
                {
                    return planet;
                }
            }
            throw new NotFoundException($"Could not find Planet.");
        }
    }
}

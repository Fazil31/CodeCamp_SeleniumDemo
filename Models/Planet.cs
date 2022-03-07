using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp_SeleniumDemo.Models
{
    public class Planet
    {
        private IWebElement planet;

        public Planet(IWebElement planet)
        {
            this.planet = planet;
        }

        public string PlanetName => this.planet.FindElement(By.ClassName("name")).Text;

        public long PlanetDistance
        {
            get
            {
                var distance = this.planet.FindElement(By.ClassName("distance")).Text;
                distance = RemoveKms(distance);
                return long.Parse(distance, NumberStyles.AllowThousands);
            }
        }

        public IWebElement ExploreButton => this.planet.FindElement(By.TagName("button"));
        
        internal string RemoveKms(string distance)
        {
            return distance.Split(" ")[0];
        }

    }
}

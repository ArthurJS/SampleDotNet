using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NETProject.Models.Domain;

namespace NETProject.ViewModels
{
    public class NavigationViewModel
    {

        public IEnumerable<Object> List { get; set; }
        public Grade Grade { get; set; }
        public Continent Continent { get; set; }
        public Country Country { get; set; }
        public Location Location { get; set; }

        public NavigationViewModel()
        {
            Grade = null;
            Continent = null;
            Country = null;
            Location = null;
        }

        public NavigationViewModel(Grade grade) : this() {
            Grade = grade;
            List = grade.Continents.OrderBy(cont => cont.Name).ToList();
        }

        public NavigationViewModel(Grade grade, Continent continent) : this()
        {
            Grade = grade;
            Continent = continent;
            List = continent.Countries.OrderBy(c => c.Name).ToList();
        }

        public NavigationViewModel(Grade grade, Continent continent, Country country) : this()
        {
            Grade = grade;
            Continent = continent;
            Country = country;
            List = country.Locations.OrderBy(l => l.Name).ToList();
        }
    }

    public class SharedViewModel
    {
        public Grade Grade { get; set; }
        public Continent Continent { get; set; }
        public Country Country { get; set; }
        public Location Location { get; set; }


        public SharedViewModel(Grade grade, Continent continent, Country country, Location location)
        {
            Grade = grade;
            Continent = continent;
            Country = country;
            Location = location;
        }
    }
}
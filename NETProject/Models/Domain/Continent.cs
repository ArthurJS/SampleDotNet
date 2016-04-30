using System.Collections.Generic;
using System.Linq;

namespace NETProject.Models.Domain
{
    public class Continent
    {
        #region Constructor

        public Continent()
        {
            Countries = new List<Country>();
        } 

        public Continent(string name) : this()
        {
            Name = name;
        }
        #endregion

        #region Properties
        public virtual ICollection<Country> Countries{ get; private set; }

        public string Name { get; set; }

        public int Id {get; set; } 
        #endregion

        #region Methods

        public Country FindCountryByName(string countryName)
        {
            return Countries.FirstOrDefault(c => c.Name.Equals(countryName));
            
        }
        #endregion
    }
}

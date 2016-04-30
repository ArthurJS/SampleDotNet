using System.Collections.Generic;
using System.Linq;

namespace NETProject.Models.Domain
{
    public class Country
    {
        #region Constructor
        public Country()
        {
            Locations = new List<Location>();
        }

        public Country(string name) : this()
        {
            Name = name;
        }
        
        #endregion

        #region Property
        public virtual ICollection<Location> Locations { get; private set; }

        public string Name { get; set; }

        public int Id { get; set; } 
        #endregion

        #region Methods
        public Location FindLocationByName(string locationName)
        {
             //Location location = null;
             //foreach (var l in Locations){
             //if (l.Name.Equals(locationName))
             //location = l;
             //}

             //if (location == null)
             //throw new Exception("Location doesn't exist.");
             //return location; 
            return Locations.FirstOrDefault(l => l.Name.Equals(locationName));
        }
        #endregion
    }
}

using System.Collections.Generic;
using System.Linq;

namespace NETProject.Models.Domain
{
    public class Grade
    {
        #region Properties

        public int Id { get; set; }
        public virtual Node DeterminationTable{ get; set; }

        public virtual ICollection<Continent> Continents { get; private set; }
        
        #endregion

        #region Constructors
        public Grade() 
        {
            Continents = new List<Continent>();
        }

        public Grade(int id) : this()
        {
            Id = id;
        } 
        #endregion

        #region Methods

        public Continent FindContinentById(int continentId)
        {
            return Continents.FirstOrDefault(c => c.Id == continentId);
        }

        public Continent FindContinentByName(string continentName)
        {
            return Continents.FirstOrDefault(c => c.Name == continentName);
        }
        #endregion

    }
}

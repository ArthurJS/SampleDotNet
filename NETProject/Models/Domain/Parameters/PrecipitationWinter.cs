using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class PrecipitationWinter : AbstractParameter
    {

        public string Situated { get; set; }

        public PrecipitationWinter()
        {
            
        }

        public PrecipitationWinter(Location location)
        {
            Code = "NW";
            Beschrijving = "(Gemiddelde) totale neerslag in de winter";
            Eenheid = "mm";
            CalculateSituated(location);
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.GetPercipitation(Situated, false);
        }

        private void CalculateSituated(Location location)
        {
            Situated = location.CoordinateLat > 0 ? "north" : "south";
        }
    }
}
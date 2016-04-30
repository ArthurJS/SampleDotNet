using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class PrecipitationSummer : AbstractParameter
    {
        public string Situated { get; set; }

        public PrecipitationSummer(Location location)
        {
            Code = "NZ";
            Beschrijving = "(Gemiddelde) totale neerslag in de zomer";
            Eenheid = "mm";
            CalculateSituated(location);
        }

        public PrecipitationSummer()
        {
            
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.GetPercipitation(Situated, true);
        }

        private void CalculateSituated(Location location)
        {
            Situated = location.CoordinateLat > 0 ? "north" : "south";
        }
    }
}
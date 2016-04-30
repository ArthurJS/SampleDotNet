using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class Tm : AbstractParameter
    {
        public Tm()
        {
            Code = "Tm";
            Beschrijving = "Gemiddelde maandtemperatuur";
            Eenheid = "°C";
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.TY;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class Tj : AbstractParameter
    {

        public Tj()
        {
            Code = "Tj";
            Beschrijving = "Gemiddelde jaartemperatuur";
            Eenheid = "°C";
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.TY;
        }
    }
}
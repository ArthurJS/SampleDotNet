using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class Tw : AbstractParameter
    {

        public Tw()
        {
            Code = "Tw";
            Beschrijving = "Gemiddelde temperatuur warmste maand";
            Eenheid = "°C";
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.Tw;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class Tk : AbstractParameter
    {

        public Tk()
        {
            Code = "Tk";
            Beschrijving = "Gemiddelde temperatuur koudste maand";
            Eenheid = "°C";
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.Tk;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class ColdestMonth : AbstractParameter
    {
        public ColdestMonth()
        {
            Code = "ColdestMonth";
            Beschrijving = "Koudste maand";
            Eenheid = "";
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.ColdestMonth;
        }
    }
}
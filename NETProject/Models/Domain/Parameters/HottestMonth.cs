using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class HottestMonth : AbstractParameter
    {

        public HottestMonth()
        {
            Code = "HottestMonth";
            Beschrijving = "Warmste maand";
            Eenheid = "";
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.HottestMonth;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class DryMonths : AbstractParameter
    {
        public DryMonths()
        {
            Code = "D";
            Beschrijving = "Aantal droge maanden";
            Eenheid = "";
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.NumberOfDryMonths;
        }
    }
}
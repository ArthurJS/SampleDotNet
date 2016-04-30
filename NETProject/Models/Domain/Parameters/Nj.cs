using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class Nj : AbstractParameter
    {

        public Nj()// heeft default constr nodig
        {
            Code = "Nj";
            Beschrijving = "(Gemiddelde) totale jaarneerslag";
            Eenheid = "mm";
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.PY;
        }
    }
}
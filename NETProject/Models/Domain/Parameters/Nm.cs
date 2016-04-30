using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class Nm : AbstractParameter
    {

        public Nm()
        {
            Code = "Nm";
            Beschrijving = "Gemiddelde maandneerslag";
            Eenheid = "mm";
        }

        public override double Execute(Climatogram climatogram)
        {
            double waarde = climatogram.Percipitations.Sum() / 12;
            return waarde;
        }
    }
}
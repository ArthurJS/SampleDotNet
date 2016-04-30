using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class TmBiggerOrEqualThan10 : AbstractParameter
    {
        public TmBiggerOrEqualThan10()
        {
            Code = "(# maanden waar Tm >= 10°C) ";
            Beschrijving = "Aantal maanden waar Tm groter of gelijk aan 10°C is";
            Eenheid = " maanden";
        }

        public override double Execute(Climatogram climatogram)
        {
            return climatogram.TmBiggerOrEqualThan10;
        }
    }
}
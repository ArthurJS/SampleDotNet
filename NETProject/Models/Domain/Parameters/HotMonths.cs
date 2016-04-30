using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;

namespace NETProject.Models.Domain
{
    public class HotMonths : AbstractParameter
    {
        public HotMonths()
        {
            Code = "HotMonths";
            Beschrijving = "Aantal warme maanden";
            Eenheid = "";
        }

        public override double Execute(Climatogram climatogram)
        {
            int aantal = 0;
            ICollection<double> temperaturen = climatogram.Temperatures;
            foreach (double temp in temperaturen.Where(temp => (temp >= 10)))
            {
                aantal++;
            }

            return aantal;
        }
    }
}
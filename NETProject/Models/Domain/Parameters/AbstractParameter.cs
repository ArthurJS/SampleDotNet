using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NETProject.Models.Domain
{
    public abstract class AbstractParameter
    {
        public int Id { get; set; }
        public String Code { get; set; }
        public String Beschrijving { get; set; }
        public String Eenheid { get; set; }

        public AbstractParameter()
        {
            
        }

        public abstract double Execute(Climatogram climatogram);
    }
}

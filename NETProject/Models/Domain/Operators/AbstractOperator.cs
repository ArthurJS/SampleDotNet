using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETProject.Models.Domain
{
    public abstract class AbstractOperator
    {
        public int Id { get; set; }
        public String Beschrijving { get; set; }
        public abstract Boolean Execute(double par1, double par2);

        public AbstractOperator()
        {
            
        }
    }
}

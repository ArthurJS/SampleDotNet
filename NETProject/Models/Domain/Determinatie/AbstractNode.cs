using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETProject.Models.Domain
{
    public abstract class AbstractNode
    {
        public int Id { get; set; }

        public AbstractNode()
        {
            
        }

        public abstract String getText();
        public abstract string[] Determineer(Climatogram climatogram);
        public abstract List<Boolean> GetDeterminationPath(Climatogram climatogram, List<Boolean> blist);
    }
}

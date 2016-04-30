using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class SmallerOrEqual : AbstractOperator
    {

        public SmallerOrEqual()
        {
            Beschrijving = "<=";
        }

        public override bool Execute(double par1, double par2)
        {
            return par1 <= par2;
        }
    }
}
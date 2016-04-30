using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class Smaller : AbstractOperator
    {

        public Smaller()
        {
            Beschrijving = "<";
        }

        public override bool Execute(double par1, double par2)
        {
            return par1 < par2;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.Domain
{
    public class Leaf : AbstractNode
    {
        public string Vegetatietype { get; set; }
        public string Klimaattype { get; set; }
        public string Imagepath { get; set; }


        public Leaf(string klim, string veg, string imgpath)
        {
            Klimaattype = klim;
            Vegetatietype = veg;
            Imagepath = imgpath;
        }

        public Leaf()
        {
            
        }

        public override String getText()
        {
            return Klimaattype + ", " + Vegetatietype;
        }

        public override string[] Determineer(Climatogram climatogram)
        {
            return new[]{Klimaattype,Vegetatietype, Imagepath};
        }

        public override List<Boolean> GetDeterminationPath(Climatogram climatogram, List<Boolean> blist)
        {
            return blist;
        }
    }
}
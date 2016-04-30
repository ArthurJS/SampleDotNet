using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETProject.Models.DAL.Domain
{
    public class Vraag
    {
        public string _vraag { get; set; }
        public double Antwoord { get; set; }
        public double[] AntwoordOpties { get; set; }

        public Vraag(string vraag, double antwoord, double[] antwoordOpties)
        {
            _vraag = vraag;
            Antwoord = antwoord;
            AntwoordOpties = antwoordOpties;
        }
    }
}

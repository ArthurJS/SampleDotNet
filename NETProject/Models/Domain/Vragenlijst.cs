using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using NETProject.Models.DAL.Domain;

namespace NETProject.Models.Domain
{
    public class Vragenlijst
    {
        public string[] Vragen { get; set; }
        private List<AbstractParameter> Parameters { get; set; }
        private List<Vraag> VragenLijst { get; set; }
        private Climatogram Climatogram { get; set; }
        public Double[] Maanden { get; set; }
        public double NeerslagZomer { get; set; }
        public double NeerslagWinter { get; set; }
        public double[] NeerslagWinterZomer { get; set; }
        public double[] AantalMaanden { get; set; }
        public double[] TemperatureData { get; set; }
        public Vragenlijst(Location location, Climatogram climatogram)
        {
            string[] Vragen =
            {
                "Wat is de warmste maand?",
                "Wat is de temperatuur van de warmste maand (Tw)?",
                "Wat is de koudste maand?",
                "Wat is de temperatuur van de koudste maand (Tk)?",
                "Hoeveel droge maanden zijn er (D)?",
                "Hoeveel neerslag is er in de zomer?",
                "Hoeveel neerslag is er in de winter?"
            };
            TemperatureData = location.Climatogram.MonthlyDataList.Select(m => m.Temperature).ToArray();
            NeerslagZomer = location.Climatogram.GetPercipitation(location.CalculateSituated(), true);
            NeerslagWinter = location.Climatogram.GetPercipitation(location.CalculateSituated(), false);
            NeerslagWinterZomer = new double[] { NeerslagZomer - 10, NeerslagZomer, NeerslagWinter + 10, NeerslagWinter };
            AantalMaanden = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            double[] Maanden =
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 
                //new SelectListItem{ Value = "1", Text="Januari"},
                //new SelectListItem{ Value = "2", Text="Februari"},
                //new SelectListItem{ Value = "3", Text="Maart"},
                //new SelectListItem{ Value = "4", Text="April"},
                //new SelectListItem{ Value = "5", Text="Mei"},
                //new SelectListItem{ Value = "6", Text="Juni"},
                //new SelectListItem{ Value = "7", Text="Juli"},
                //new SelectListItem{ Value = "8", Text="Augustus"},
                //new SelectListItem{ Value = "9", Text="September"},
                //new SelectListItem{ Value = "10", Text="Oktober"},
                //new SelectListItem{ Value = "11", Text="November"},
                //new SelectListItem{ Value = "12", Text="December"},

            };

            Parameters = new List<AbstractParameter>();
            Parameters.Add(new HottestMonth());
            Parameters.Add(new Tw());
            Parameters.Add(new ColdestMonth());
            Parameters.Add(new Tk());
            Parameters.Add(new DryMonths());
            Parameters.Add(new PrecipitationSummer(location));
            Parameters.Add(new PrecipitationWinter(location));

            VragenLijst = new List<Vraag>();
            VragenLijst.Add(new Vraag(Vragen[0], Parameters[0].Execute(climatogram), Maanden));
            VragenLijst.Add(new Vraag(Vragen[1], Parameters[1].Execute(climatogram), TemperatureData));
            VragenLijst.Add(new Vraag(Vragen[2], Parameters[2].Execute(climatogram), Maanden));
            VragenLijst.Add(new Vraag(Vragen[3], Parameters[3].Execute(climatogram), TemperatureData));
            VragenLijst.Add(new Vraag(Vragen[4], Parameters[4].Execute(climatogram), AantalMaanden));
            VragenLijst.Add(new Vraag(Vragen[5], Parameters[5].Execute(climatogram), NeerslagWinterZomer));
            VragenLijst.Add(new Vraag(Vragen[6], Parameters[6].Execute(climatogram), NeerslagWinterZomer));
        }

        //hier klimatogram meegeven, niet in constr
        public double[] GeefJuisteAntwoorden()
        {
            //double[] juisteAntwoorden = new double[7];
            //for (int i = 0; i < 7; i++)
            //{
            //    foreach (var vraag in VragenLijst)
            //    {
            //        juisteAntwoorden[i] = vraag.Antwoord;
            //    }
            //}
            //return juisteAntwoorden;

            return VragenLijst.Select(p => p.Antwoord).ToArray();
        }

        public string[] GeefVragen()
        {
            //string[] vragen = new string[7];
            
            //foreach (var vraag in VragenLijst)
            //{
            //    for (int i = 0; i < 7; i++)
            //    {
            //        vragen[i] = vraag._vraag.;
            //    }

            //}

            return VragenLijst.Where(v => v._vraag != null).Select(p => p._vraag).ToArray();
        }

        public double[][] GeefAntwoordOpties()
        {
            //double[][] antwoordOpties = new double[7][];
            //for (int i = 0; i < 7; i++)
            //{
            //    foreach (var vraag in VragenLijst)
            //    {
                
            //        antwoordOpties[i] = vraag.AntwoordOpties;
            //    }

            //}
            //return antwoordOpties;

            return VragenLijst.Where(v => v.AntwoordOpties != null).Select(p => p.AntwoordOpties).ToArray();
        }

        //public Boolean[] VerbeterAntwoorden(double[] gegevenAntwoorden)
        //{
        //    Boolean[] juistOfFout = new Boolean[7];
        //    for (int i = 0; i < Parameters.Count; i++)
        //    {
        //        juistOfFout[i] = gegevenAntwoorden[i] == JuisteAntwoorden[i];
        //    }

        //    return juistOfFout;
        //}
    }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Web;

//namespace NETProject.Models.Domain
//{
//    public class Vragenlijst
//    {
//        private List<AbstractParameter> Parameters { get; set; } 
//        private Climatogram Climatogram { get; set; }

//        public Vragenlijst(Location location)
//        {
//            Parameters = new List<AbstractParameter>();
//            Parameters.Add(new HottestMonth());
//            Parameters.Add(new Tw());
//            Parameters.Add(new ColdestMonth());
//            Parameters.Add(new Tk());
//            Parameters.Add(new DryMonths());
//            Parameters.Add(new PrecipitationSummer(location));
//            Parameters.Add(new PrecipitationWinter(location));
//        }

//        //hier klimatogram meegeven, niet in constr
//        public double[] GeefJuisteAntwoorden(Climatogram climatogram)
//        {
//            double[] juisteAntwoorden = new double[7];
//            for (int i = 0; i < Parameters.Count; i++)
//            {
//                juisteAntwoorden[i] = Parameters[i].Execute(climatogram);
//            }
//            return juisteAntwoorden;
//        }

//        //public Boolean[] VerbeterAntwoorden(double[] gegevenAntwoorden)
//        //{
//        //    Boolean[] juistOfFout = new Boolean[7];
//        //    for (int i = 0; i < Parameters.Count; i++)
//        //    {
//        //        juistOfFout[i] = gegevenAntwoorden[i] == JuisteAntwoorden[i];
//        //    }

//        //    return juistOfFout;
//        //}
//    }
//}
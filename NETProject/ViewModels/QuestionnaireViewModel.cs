using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NETProject.Models.Domain;

namespace NETProject.ViewModels
{
    public class QuestionnaireViewModel
    {
        public QuestionnaireViewModel(string[] vragen, double[] juisteAntwoorden, double[][] antwoordOpties, Grade grade)
        {
            Vragen = vragen;
            JuisteAntwoorden = juisteAntwoorden;
            AntwoordOpties = antwoordOpties;
            Grade = grade;
        }

        public string[] Vragen { get; set; }
        public double[] JuisteAntwoorden { get; set; }
        public double[][] AntwoordOpties { get; set; }
        public Grade  Grade { get; set; }

    }
}
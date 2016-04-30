using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NETProject.Models.DAL;
using NETProject.Models.Domain;
using NETProject.ViewModels;

namespace NETProject.Controllers
{
    public class ClimatogramController : Controller
    {
        private AbstractNode Determinatietabel { get; set; }

        private IRepository<Grade> gradeRepository;



        public ClimatogramController(IRepository<Grade> gradeRepository )
        {
            this.gradeRepository = gradeRepository;
        }

        // GET: Climatogram
        public ActionResult ViewClimatogram(int selectedGrade, string selectedContinent, string selectedCountry, string selectedLocation)
        {
            Grade currentGrade = gradeRepository.FindById(selectedGrade);
            Determinatietabel = currentGrade.DeterminationTable;
            ViewBag.Location = selectedLocation;

            Continent currentContinent = currentGrade.FindContinentByName(selectedContinent);
            Country currentCountry = currentContinent.FindCountryByName(selectedCountry);
            Location currentLocation = currentCountry.FindLocationByName(selectedLocation);

            Climatogram climatogram = currentLocation.Climatogram;
            Vragenlijst vragenlijst = new Vragenlijst(currentLocation, climatogram);

            string[] vragen = vragenlijst.GeefVragen();
            double[] juisteAntwoorden = vragenlijst.GeefJuisteAntwoorden();
            double[][] antwoorOpties = vragenlijst.GeefAntwoordOpties();
            
            string[] climatogramSolution = Determinatietabel.Determineer(climatogram);
            List<Boolean> determinatiePad = Determinatietabel.GetDeterminationPath(climatogram, new List<Boolean>());

            ClimatogramViewModel cvm = new ClimatogramViewModel(currentGrade, currentContinent, currentCountry, currentLocation, juisteAntwoorden, vragen, antwoorOpties, Determinatietabel, climatogramSolution, determinatiePad);
           
            return View("ViewClimatogram", cvm);
        }
        [ChildActionOnly]
        public ActionResult RenderDeterminationTable(Node determinatietabel, Boolean[] determinatiePad, Grade selectedGrade,  string[] climatogramSolution)
        {
            return PartialView("_DeterminationTable", new DeterminationTableViewModel(determinatietabel, determinatiePad,selectedGrade, climatogramSolution));
        }

        [ChildActionOnly]
        public ActionResult RenderQuestionnaire(string[] vragen, double[] juisteAntwoorden, double[][] antwoordOpties, Grade grade)
        {
            return PartialView("_Questionnaire", new QuestionnaireViewModel(vragen, juisteAntwoorden, antwoordOpties, grade));
        }
    }
}
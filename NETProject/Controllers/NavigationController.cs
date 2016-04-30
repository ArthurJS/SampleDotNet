using System.Web.Mvc;
using NETProject.Models.DAL;
using NETProject.Models.Domain;
using NETProject.ViewModels;

//VRAAG VOOR DE SESSIE: Tijdens het serialisen worden de tekens omgevormd zoals België => BelgiA>> (hoe op te lossen?)

namespace NETProject.Controllers
{
    public class NavigationController : Controller
    {
        private IRepository<Grade> gradeRepository;

        public NavigationController(IRepository<Grade> gradeRepository)
        {
            this.gradeRepository = gradeRepository;
        }

        public ActionResult SelectGrade()
        {
            return View("SelectGrade", new NavigationViewModel());
        }

        public ActionResult SelectContinent(int selectedGrade)
        {
            int id = selectedGrade;

            Grade currentGrade = gradeRepository.FindById(id);

            return View("SelectContinent", new NavigationViewModel(currentGrade));
        }
        public ActionResult SelectCountry(int selectedGrade, string selectedContinent)
        {
            Grade currentGrade = gradeRepository.FindById(selectedGrade);

            Continent currentContinent = currentGrade.FindContinentByName(selectedContinent);

            return View("SelectCountry", new NavigationViewModel(currentGrade, currentContinent));
        }

        public ActionResult SelectLocation(int selectedGrade, string selectedContinent, string selectedCountry)
        {
            Grade currentGrade = gradeRepository.FindById(selectedGrade);

            Continent currentContinent = currentGrade.FindContinentByName(selectedContinent);

            Country currentCountry = currentContinent.FindCountryByName(selectedCountry);

            return View("SelectLocation", new NavigationViewModel(currentGrade, currentContinent, currentCountry));
        }

        [ChildActionOnly]
        public ActionResult RenderChoiceWindow(Grade grade, Continent continent, Country country, Location location)
        {
            return PartialView("_ChoiceWindow", new SharedViewModel(grade, continent, country, location));
        }

        [ChildActionOnly]
        public ActionResult RenderNavBar(Grade grade, Continent continent, Country country, Location location)
        {
            return PartialView("_NavBar", new SharedViewModel(grade, continent, country, location));
        }
    }
}
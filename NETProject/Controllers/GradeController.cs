using NETProject.ViewModels;
using NETProject.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NETProject.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        public ActionResult Index()
        {
            //var gradeList = new SelectList(
            //    new List<Grade>
            //    {
            //        new Grade(1),
            //        new Grade(2),
            //        new Grade(3),
            //        new Grade(4),
            //        new Grade(5),
            //        new Grade(6),
            //    });
            return View("Index", new GradeViewModel());
        }
    }
}
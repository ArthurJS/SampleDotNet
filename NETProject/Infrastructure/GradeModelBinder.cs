using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.ModelBinding;
using NETProject.Models.Domain;
using IModelBinder = System.Web.Mvc.IModelBinder;
using ModelBindingContext = System.Web.Mvc.ModelBindingContext;

namespace NETProject.Infrastructure
{
    public class GradeModelBinder : IModelBinder // mag weg
    {
        private const string GradeSessionKey = "grade";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Grade grade = controllerContext.HttpContext.Session[GradeSessionKey] as Grade; //<= cookie, niet session
            if (grade == null)
            {
                grade = new Grade();
                controllerContext.HttpContext.Session[GradeSessionKey] = grade;
            }
            return grade;
        }
    }
}
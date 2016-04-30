using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NETProject.Models.Domain;

namespace NETProject.ViewModels
{
    public class GradeViewModel
    {

        #region Properties
        public String Grade { get; set; }

        public Student Student { get; set; }
        public SelectList GradeList { get; set; }
        #endregion

        #region Constructors
        public GradeViewModel() { }

        public GradeViewModel(Student student)
        {
            Grade = student.Grade.ToString();
            Student = student;
        }

        public GradeViewModel(SelectList gradeList)
        {
            GradeList = gradeList;
        }
        #endregion
    }
}
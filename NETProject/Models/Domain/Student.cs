using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;

namespace NETProject.Models.Domain
{
    public class Student
    {
        #region Properties
        public virtual Grade Grade { get; set; } 
	    #endregion

        #region Constructors
        public Student() { }

        public Student(Grade grade) : this()
        {
            Grade = grade;
        } 
        #endregion

        public int GetGraad(Grade grade)
        {
            int graad = 0;
            switch (grade.Id)
            {
                case 1:
                    graad = 1;
                    break;
                case 2:
                    graad = 1;
                    break;
                case 3:
                    graad = 2;
                    break;
                case 4:
                    graad = 2;
                    break;
                case 5:
                    graad = 3;
                    break;
                case 6:
                    graad = 3;
                    break;
            }
            return graad;
        }

    }
}

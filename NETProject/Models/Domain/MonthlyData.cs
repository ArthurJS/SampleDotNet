using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace NETProject.Models.Domain
{
    public class MonthlyData
    {

        #region Constructor
        public MonthlyData()
        {
            
        }

        public MonthlyData(int id, double percipitation, double temperature, string month)
            : this()
        {
            Id = id;
            Percipitation = percipitation;
            Temperature = temperature;
            Month = month;
        } 
        #endregion

        #region Property
        public int Id { get; set; }
        public double Percipitation { get; set; } 
        public double Temperature { get; set; }
        public string Month { get; set; } 
        #endregion

        #region Methods
        public double IdToMonth(string month)
        {
            switch (month)
            {
                case "Jan": 
                    return 1;
                case "Feb":
                    return 2;
                case "Maa":
                    return 3;
                case "Apr":
                    return 4;
                case "Mei":
                    return 5;
                case "Jun":
                    return 6;
                case "Jul":
                    return 7;
                case "Aug":
                    return 8;
                case "Sep":
                    return 9;
                case "Okt":
                    return 10;
                case "Nov":
                    return 11;
                case "Dec":
                    return 12;
                default:
                    return 1;
            }
        }
        #endregion
    }
}

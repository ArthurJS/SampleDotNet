using System;

namespace NETProject.Models.Domain
{
    public class Location
    {
        #region Field
        //private string name;
        //private string station;
 
        //private double coordinateLong;
        //private double coordinateLat;
        //private int yearStart;
        //private int yearEnd;
        //private double height; 
        #endregion

        #region Constructor

        public Location()
        {
                
        }
        public Location(string name, string station, double cooLong, double cooLat, double height)
            : this()
        {
            Name = name;
            Station = station;
            CoordinateLong = cooLong;
            CoordinateLat = cooLat;
            Height = height;
            //CoordinateLong = coordinateLong;
            //CoordinateLat = coordinateLat;
            //Height = height;
            //YearStart = yearStart;
            //YearEnd = yearEnd;
        }
        #endregion

        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Station { get; set; }
        public double CoordinateLong { get; set; }
        public double CoordinateLat { get; set; }
        public double Height { get; set; }

        public virtual Climatogram Climatogram { get; set; }
        //public double CoordinateLong { get; set; }
        //public double CoordinateLat { get; set; }
        //public int YearStart { get; set; }
        //public int YearEnd { get; set; }
        //public double Height { get; set; }
        #endregion

        #region Methods
        public string[] CoordinateDegreeLong(double radian)
        {
            CoordinateLong = radian;
            double complete = radian*(180.0/Math.PI); // 14.56xxxxxx
            int degree = (int)Math.Floor(complete); // 14
            double help = (complete - degree) * 60; //33,xxxx
            int minute = (int)Math.Floor(help); // 33
            //double help2 = (help - minute) * 60; // 36,xxxxx
            //int second = (int)Math.Floor(help2); // 36

            //return new string[] { degree + "", minute + "", second + "", GetSituatedLong() };
            return new string[] { degree + "", minute + "", GetSituatedLong() };
        }

        public string[] CoordinateDegreeLat(double radian)
        {
            CoordinateLat = radian;
            double complete = radian * (180.0 / Math.PI); // 14.56xxxxxx
            int degree = (int)Math.Floor(complete); // 14
            double help = (complete - degree) * 60; //33,xxxx
            int minute = (int)Math.Floor(help); // 33
            //double help2 = (help - minute) * 60; // 36,xxxxx
            //int second = (int)Math.Floor(help2); // 36

            //return new string[] { degree + "", minute + "", second + "", GetSituatedLat() };
            return new string[] { degree + "", minute + "", GetSituatedLat() };
        }

        public string GetSituatedLong()
        {
            string typeLong = "";
            if (CoordinateLong < 0)
            {
                typeLong = "WL";
            }
            if (CoordinateLong >= 0)
            {
                typeLong = "OL";
            }
            return typeLong;
        }
        //ifelse
        public string GetSituatedLat()
        {
            string typeLat = "";
            if (CoordinateLat < 0)
            {
                typeLat = "ZB";
            }
            if (CoordinateLong >= 0)
            {
                typeLat = "NB";
            }
            return typeLat;
        }

        public double GetPercipitationWinter()
        {
            
            return Climatogram.GetPercipitation(CalculateSituated(), false);
        }

        public double GetPercipitationSummer()
        {
            return Climatogram.GetPercipitation(CalculateSituated(), true);
        }
        
        //was origineel een private methode ==> public gemaakt voor de test
        public string CalculateSituated()
        {
            if (CoordinateLat > 0)
                return "north";
            else
            {
                return "south";
            }
        }
        #endregion
    }
}

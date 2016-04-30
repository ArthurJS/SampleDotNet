using System;
using System.Collections.Generic;
using System.Linq;

namespace NETProject.Models.Domain
{
    public class Climatogram
    {
        #region Constructor
        public Climatogram()
        {
            MonthlyDataList = new List<MonthlyData>();
        }
        //constructor met temperatuur/neerslag array
        public Climatogram(ICollection<MonthlyData> monthlyData, string period)
            : this()
        {
            MonthlyDataList = monthlyData;
            Period = period;
        } 
        #endregion

        #region Properties
        public virtual ICollection<MonthlyData> MonthlyDataList { get; private set; }
        public int Id { get; set; }
        public string Period { get; set; }
        public double PY { get { return MonthlyDataList.Sum(data => data.Percipitation); } }

        public double TY
        {
            get
            {
                double total = MonthlyDataList.Sum(data => data.Temperature);
                //De ",1" is om af te ronden top op 1 cijfer na de komma
                return Math.Round(total / 12, 1);
            }
        }

        public virtual ICollection<double> Percipitations
        {
            get
            {
                ICollection<double> perc = MonthlyDataList.Select(data => data.Percipitation).ToList();
                return perc;
            }
        }
        public virtual ICollection<double> Temperatures
        {
            get
            {
                ICollection<double> temp = MonthlyDataList.Select(data => data.Temperature).ToList();
                return temp;
            }
        }

        //----------------Use Case 2 [nog te testen]---------------------

        //Temperature hottest month
        public double Tw
        {
            get { return Temperatures.Max(); }
        }
        //Temperature coldest month
        public double Tk
        {
            get { return Temperatures.Min(); }
        }
        //Hottest Month
        public double HottestMonth
        {
            get
            {
                double max = Temperatures.Max();
                double month = 0;
                foreach (MonthlyData m in MonthlyDataList.Where(m => m.Temperature.Equals(max)))
                {
                    month = m.IdToMonth(m.Month);
                }
                return month;
            }
        }
        //Coldest Month
        public double ColdestMonth
        {
            get
            {
                double min = Temperatures.Min();
                double month = 0;
                foreach (MonthlyData m in MonthlyDataList.Where(m => m.Temperature.Equals(min)))
                {
                    month = m.IdToMonth(m.Month);
                }
                return month;
            }
        }

        public double TmBiggerOrEqualThan10
        {
            get
            {
                double count = 0;
                foreach (MonthlyData m in MonthlyDataList.Where(m => m.Temperature >= 10))
                {
                    count++;
                }
                return count;
            }
        }

        public double NumberOfDryMonths
        {
            get
            {
                int amount = 0;
                for (int index = 0; index < 12; index++)
                {
                    if ((Temperatures.ElementAt(index)*2) > Percipitations.ElementAt(index))
                    {
                        amount++;
                    }
                }
                return amount;
            }
        }

        //public double PercipitationWinter
        //{
        //    get
        //    {
        //        return GetPercipitationWinter();
        //    }
        //}

        public double GetPercipitation(string situated, Boolean summer)
        {
            double perc = 0;
            if (summer)
            {

                if (situated.Equals("south"))
                {
                    for (int i = 3; i < 9; i++)
                    {
                        perc += Percipitations.ElementAt(i);
                    }
                }
                else if (situated.Equals("north"))
                {
                    for (int i = 9; i < 12; i++)
                    {
                        perc += Percipitations.ElementAt(i);
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        perc += Percipitations.ElementAt(i);
                    }
                }
            }
            else
            {
                if (situated.Equals("north"))
                {
                    for (int i = 3; i < 9; i++)
                    {
                        perc += Percipitations.ElementAt(i);
                    }
                }
                else if (situated.Equals("south"))
                {
                    for (int i = 9; i < 12; i++)
                    {
                        perc += Percipitations.ElementAt(i);
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        perc += Percipitations.ElementAt(i);
                    }
                }
            }
            return perc;
        }

        //public double GetPercipitationWinter(string situated)
        //{
        //    double perc = 0;
        //    if (situated.Equals("north"))
        //    {
        //        for (int i = 3; i < 9; i++)
        //        {
        //            perc += Percipitations.ElementAt(i);
        //        }
        //    }
        //    else if (situated.Equals("south"))
        //    {
        //        for (int i = 9; i < 12; i++)
        //        {
        //            perc += Percipitations.ElementAt(i);
        //        }
        //        for (int i = 0; i < 3; i++)
        //        {
        //            perc += Percipitations.ElementAt(i);
        //        }
        //    }
        //    return perc;
        //}

        #endregion
    }
}

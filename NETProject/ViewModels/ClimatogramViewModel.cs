using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.WebPages.Html;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using NETProject.Models.Domain;

namespace NETProject.ViewModels
{
    public class ClimatogramViewModel
    {
        public Grade Grade { get; set; }
        public Continent Continent { get; set; }
        public Country Country { get; set; }
        public Location Location { get; set; }
        public Highcharts Chart { get; set; }
        public double[] TemperatureData { get; set; }
        public double[] PrecipitationData { get; set; }
        public string[] MonthLabels { get; set; }
        public string[] ClimatogramSolution{ get; set; }
        public Boolean[] DeterminatiePad { get; set; } 
        public AbstractNode Determinatietabel { get; set; }
        public string[] Vragen { get; set; }
        public double[] Antwoorden { get; set; }
        public double[][] AntwoordOpties { get; set; }



        public ClimatogramViewModel(Grade grade, Continent continent, Country country, Location location, double[] antwoorden, string[] vragen, double[][] antwoordOpties, AbstractNode determinatietabel, string[] climatogramSolution, List<Boolean> determinatiePad)
        {
            Grade = grade;
            Continent = continent;
            Country = country;
            Location = location;
            Determinatietabel = determinatietabel;
            ClimatogramSolution = climatogramSolution;
            DeterminatiePad = determinatiePad.ToArray(); 
            Vragen = vragen;
            Antwoorden = antwoorden;
            AntwoordOpties = antwoordOpties;
            MonthLabels = Location.Climatogram.MonthlyDataList.Select(m => m.Month).ToArray();
            PrecipitationData = Location.Climatogram.MonthlyDataList.Select(m => m.Percipitation).ToArray();
            TemperatureData = Location.Climatogram.MonthlyDataList.Select(m => m.Temperature).ToArray();
            SetChart();
        }

        public ClimatogramViewModel()
        {
        }

        private void SetChart()
        {
            //extrema bepalen
            int TRangeMax = TemperatureData.Max() >= PrecipitationData.Max() / 2 ? (int)Math.Round(TemperatureData.Max()*1.5/ 5) * 5 : (int)Math.Round(PrecipitationData.Max()*1.5 / 5) * 5 / 2 ;
            int PRangeMax = TemperatureData.Max() < PrecipitationData.Max() / 2 ? (int)Math.Round(TemperatureData.Max()*1.5/ 5) * 10 : (int)Math.Round(PrecipitationData.Max()*1.5 / 5) * 5 ;

            int TRangeMin = TemperatureData.Min() < 0 ? (int) Math.Round(TemperatureData.Min()*1.5/5)*5 : 0;
            int PRangeMin = TRangeMin*2;
            
            
            Chart = new Highcharts("Climatogram")
                .SetTitle(new Title{Text=Location.Name+" ("+Country.Name+") - station "+ Location.Station})
                .SetSubtitle(new Subtitle { Text =  Location.CoordinateDegreeLat(Location.CoordinateLat)[0] + "° " + 
                                                                Location.CoordinateDegreeLat(Location.CoordinateLat)[1] + "\" " +
                                                                    Location.CoordinateDegreeLat(Location.CoordinateLat)[2] + " " +
                                                                        //Location.CoordinateDegreeLat(Location.CoordinateLat)[3] + " " +
                                                    Location.CoordinateDegreeLong(Location.CoordinateLong)[0] + "° " +
                                                                Location.CoordinateDegreeLong(Location.CoordinateLong)[1] + "\" " +
                                                                    Location.CoordinateDegreeLong(Location.CoordinateLong)[2] + " " +
                                                                        //Location.CoordinateDegreeLong(Location.CoordinateLong)[3] + " " +
                                                    Location.Height + "m"
                })
                .SetXAxis(new[]
                {
                    new XAxis()
                    {
                        Categories = MonthLabels
                    }
                })
                .SetYAxis( new []
                {
                    new YAxis()
                    {
                        Title = new YAxisTitle{Text = "Neerslag (mmN)"},
                        Min = PRangeMin,
                        Max = PRangeMax,
                        TickInterval = 10,
                    }, 
                    new YAxis()
                    {
                        Title = new YAxisTitle{Text = "Temperatuur (°C)"},
                        Min = TRangeMin,
                        Max = TRangeMax,
                        TickInterval = 5,
                        Opposite = true
                    }, 
                })
                .SetSeries(new []
                {
                    new Series()
                    {
                        Name = "Neerslag (mmN)",
                        Type = ChartTypes.Column,
                        YAxis = "0",
                        Data = new Data(PrecipitationData.Cast<object>().ToArray())
                    }, 
                    new Series()
                    {
                        Name = "Temperatuur (°C)",
                        Type = ChartTypes.Spline,
                        Color = Color.Red,
                        YAxis = "1",
                        Data = new Data(TemperatureData.Cast<object>().ToArray())
                        
                    }
                });
        }

        public double getTotalPrecipitation()
        {
            return Location.Climatogram.PY;
        }

        public double getAverageTemp()
        {
            return Location.Climatogram.TY;
        }
    }

    public class MonthlyDataViewModel
    {
        public MonthlyDataViewModel()
        {
        }

        public MonthlyDataViewModel(Climatogram climatogram)
        {
            Climatogram = climatogram;
            MonthlyData = climatogram.MonthlyDataList.ToList();
        }

        public IEnumerable<MonthlyData> MonthlyData { get; set; }
        public Climatogram Climatogram { get; set; }
    }

}

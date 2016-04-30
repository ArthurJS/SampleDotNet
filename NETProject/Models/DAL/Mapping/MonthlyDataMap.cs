using NETProject.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NETProject.Models.DAL.Mapping
{
    public class MonthlyDataMap : EntityTypeConfiguration<MonthlyData>
    {
        public MonthlyDataMap()
        {
            //Table
            this.ToTable("MonthlyData");

            //Properties => Kolommen
            this.Property(month => month.Id).IsRequired();
            this.Property(month => month.Temperature).IsRequired();
            this.Property(month => month.Percipitation).IsRequired();

            //Primary Key
            this.HasKey(count => count.Id);

            //-------
            // Geen volgende klasse meer
        }
    }
}
using NETProject.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NETProject.Models.DAL.Mapping
{
    public class ClimatogramMap : EntityTypeConfiguration<Climatogram>
    {
        public ClimatogramMap()
        {
            //Table
            this.ToTable("Climatogram");

            //Properties => Kolommen
            this.Property(clim => clim.Id).IsRequired();
            this.Property(clim => clim.Period).IsRequired().HasMaxLength(35);
            //Is collection van double -> must be non-nullable value type in order to use it as parameter 'T' in the generic type or method
            //this.Property(clim => clim.Temperature).IsRequired();
            //Temperature en Percipitation zitten in MonthlyData

            //Primary Key
            this.HasKey(clim => clim.Id);

            //MonthlyData
            //1 Climatogram bevat meerdere MonthlyData, 1 MonthlyData bevat 1 Climatogram -> 1:N relatie
            HasMany(clim => clim.MonthlyDataList).WithRequired().Map(m =>
            {
                //Relatie 1:N
                m.MapKey("ClimatogramId");
            }).WillCascadeOnDelete(false); ; //Als we de Cclimatogram verwijderen worden de MonthlyData ook verwijderd
        }
    }
}
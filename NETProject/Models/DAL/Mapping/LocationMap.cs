using NETProject.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NETProject.Models.DAL.Mapping
{
    public class LocationMap : EntityTypeConfiguration<Location>
    {
        public LocationMap()
        {
            //Table
            this.ToTable("Location");

            //Properties => Kolommen
            this.Property(l => l.Id).IsRequired();
            this.Property(l => l.Name).IsRequired().HasMaxLength(35);
            //this.Property(l => l.Station).IsRequired().HasMaxLength(35);

            //Primary Key
            this.HasKey(l => l.Id);

            //Climamtogram
            //1 Location bevat 1 Climatogram, 1 Climatogram is van 1 Location -> 1:1 relatie
            HasRequired(l => l.Climatogram).WithRequiredPrincipal().Map(m =>
            {
                //Relatie 1:1
                m.MapKey("LocationId");
            }).WillCascadeOnDelete(false); //Als we de Location verwijderen wordt de Climatogram ook verwijderd
        }
    }
}
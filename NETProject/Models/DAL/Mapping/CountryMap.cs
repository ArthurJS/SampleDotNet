using NETProject.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NETProject.Models.DAL.Mapping
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            //Table
            this.ToTable("Country");

            //Properties => Kolommen
            this.Property(count => count.Id).IsRequired();
            this.Property(count => count.Name).IsRequired().HasMaxLength(35);

            //Primary Key
            this.HasKey(count => count.Id);

            //Locations
            //1 Country bevat meerdere Locations, 1 Location bevat 1 Country -> 1:N relatie
            HasMany(count => count.Locations).WithRequired().Map(m =>
            {
                //Relatie 1:N
                m.MapKey("CountryId");
            }).WillCascadeOnDelete(false); ; //Als we de Country verwijderen worden de Locations ook verwijderd
        }
    }
}
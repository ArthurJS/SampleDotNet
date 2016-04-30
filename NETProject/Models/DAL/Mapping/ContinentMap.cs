using NETProject.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NETProject.Models.DAL.Mapping
{
    public class ContinentMap : EntityTypeConfiguration<Continent>
    {
        public ContinentMap()
        {
            //Table
            this.ToTable("Continent");

            //Properties => Kolommen
            this.Property(cont => cont.Id).IsRequired();
            this.Property(cont => cont.Name).IsRequired().HasMaxLength(35);

            //Primary Key
            this.HasKey(cont => cont.Id);

            //Countries
            //1 Continent bevat meerdere Countries, 1 Country bevat 1 Continent -> 1:N relatie
            HasMany(cont => cont.Countries).WithRequired().Map(m =>
                {
                    //Relatie 1:N
                    m.MapKey("ContinentId");
                }).WillCascadeOnDelete(false); ; //Als we het Continent verwijderen worden de Countries ook verwijderd
        }
    }
}
using NETProject.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NETProject.Models.DAL.Mapping
{
    public class GradeMap : EntityTypeConfiguration<Grade>
    {
        public GradeMap()
        {
            //Table
            this.ToTable("Grade");

            //Properties => Kolommen
            this.Property(g => g.Id).IsRequired();
            
            //Primary Key
            this.HasKey(g => g.Id);

            //Coninents
            //1 Grade bevat meerdere Continents, 1 Continent bevat meerdere Grades -> N:M relatie
            // -> Slides H7 WebIII p. 47 
            HasMany(g => g.Continents).WithMany().Map(m =>
                {
                    //Relatie N:M
                    //Door fluent api komt er nu een GradeContinent met zowel de key van Grade als Continent
                    m.ToTable("GradeContinent");
                    m.MapLeftKey("GradeId");
                    m.MapRightKey("ContinentId");
                });
            HasRequired(g => g.DeterminationTable);
        }
    }
}
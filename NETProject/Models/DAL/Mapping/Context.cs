using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using NETProject.Models.Domain;

namespace NETProject.Models.DAL
{
    //DbContext verzorgt CRUD -> Toegangspoort tot de database -> change tracking en persistentie (SaveChanges)
    //Lazy Loading: laadt enkel het nodige
    public class Context : DbContext
    {
        //Bepalen welke database gebruikt wordt -> ProjectDb
        public Context() : base("ProjectDb")
        {

        }

        //Grades is de rootklasse van de klassenhierarchie -> DbSet (1 per root)
        //DbSet is een lijst van objecten van een bepaald type die de persistentielaag ter beschikking stelt
        //Kan bevragen a.d.h.v. Linq to Entities
        //=> Eerst nagaan of de objecten reeds in cahce aanwezig zijn. Indien niet -> SELECT query genereren naar database
        // DUS: DbSet van Grades zal zorgen dat alle andereklassen in de hierarchie ook kunnen worden opgevraagd
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Zorgen dat de namen van de klassen niet in het meervoud worden weggeschreven naar de databank: Grade -> Grades
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Zorgen dat mer mapper klasse wordt gewerkt
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        //------------------------
        // In Global.asax heb ik de initializer geforceerd omd de databank aan te maken -> database.Database.Initialize(true);
    }
}
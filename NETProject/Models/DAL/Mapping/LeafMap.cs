using System.Data.Entity.ModelConfiguration;
using NETProject.Models.Domain;

namespace NETProject.Models.DAL.Mapping
{
    public class LeafMap : EntityTypeConfiguration<Leaf>
    {
        public LeafMap()
        {
            //Table
            this.ToTable("LEAF");

            this.Property(n => n.Id).IsRequired();
            this.Property(n => n.Klimaattype).IsRequired();
            this.Property(n => n.Vegetatietype).IsRequired();
            this.Property(n => n.Imagepath).IsRequired();


            //Primary Key
            this.HasKey(n => n.Id);

        }
    }
}
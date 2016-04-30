using System.Data.Entity.ModelConfiguration;
using NETProject.Models.Domain;

namespace NETProject.Models.DAL.Mapping
{
    public class NodeMap : EntityTypeConfiguration<Node>
    {
        public NodeMap()
        {
            //Table
            this.ToTable("NODE");

            this.Property(n => n.Id).IsRequired();
            

            //Primary Key
            this.HasKey(n => n.Id);
            
            HasRequired(n => n.YesNode);
            HasRequired(n => n.NoNode);

            HasRequired(n => n.Par1);
            HasOptional(n => n.Par2);
            HasRequired(n => n.Operator);
        }
    }
}
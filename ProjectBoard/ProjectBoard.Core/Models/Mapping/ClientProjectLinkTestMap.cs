using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectBoard.Core.Models.Mapping
{
    public class ClientProjectLinkTestMap : EntityTypeConfiguration<ClientProjectLinkTest>
    {
        public ClientProjectLinkTestMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ClientId, t.ProjectId });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ClientId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProjectId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.ClientProjectLinkTests)
                .HasForeignKey(d => d.ClientId);
            this.HasRequired(t => t.Project)
                .WithMany(t => t.ClientProjectLinkTests)
                .HasForeignKey(d => d.ProjectId);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectBoard.Core.Models.Mapping
{
    public class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(1000);


            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.Projects)
                .HasForeignKey(d => d.ClientId);
            this.HasRequired(t => t.ProjectStatu)
                .WithMany(t => t.Projects)
                .HasForeignKey(d => d.StatusId);

        }
    }
}

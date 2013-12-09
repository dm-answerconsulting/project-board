using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectBoard.Core.Models.Mapping
{
    public class ProjectStatusMap : EntityTypeConfiguration<ProjectStatus>
    {
        public ProjectStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(1000);

        }
    }
}

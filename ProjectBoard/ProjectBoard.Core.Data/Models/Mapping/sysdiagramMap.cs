using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProjectBoard.Core.Data.Models.Unused;

namespace ProjectBoard.Core.Data.Models.Mapping.Unused
{
    public class sysdiagramsMap : EntityTypeConfiguration<sysdiagrams>
    {
        public sysdiagramsMap()
        {
            // Primary Key
            this.HasKey(t => t.diagram_id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(128);

        }
    }
}

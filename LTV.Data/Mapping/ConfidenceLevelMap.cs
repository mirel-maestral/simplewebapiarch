using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LTV.Data.Models.Mapping
{
    public class ConfidenceLevelMap : EntityTypeConfiguration<ConfidenceLevel>
    {
        public ConfidenceLevelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ConfidenceLevels");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}

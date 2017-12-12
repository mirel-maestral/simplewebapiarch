using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LTV.Data.Models.Mapping
{
    public class AveragesSnapshotMap : EntityTypeConfiguration<AveragesSnapshot>
    {
        public AveragesSnapshotMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AveragesSnapshots");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.FKSnapshot).HasColumnName("FKSnapshot");

            // Relationships
            this.HasRequired(t => t.Snapshot)
                .WithMany(t => t.AveragesSnapshots)
                .HasForeignKey(d => d.FKSnapshot);

        }
    }
}

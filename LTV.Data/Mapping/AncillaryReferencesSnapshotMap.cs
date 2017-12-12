using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LTV.Data.Models.Mapping
{
    public class AncillaryReferencesSnapshotMap : EntityTypeConfiguration<AncillaryReferencesSnapshot>
    {
        public AncillaryReferencesSnapshotMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AncillaryName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AncillaryReferencesSnapshots");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AncillaryName).HasColumnName("AncillaryName");
            this.Property(t => t.Revenue).HasColumnName("Revenue");
            this.Property(t => t.Profit).HasColumnName("Profit");
            this.Property(t => t.HasTheAncillary).HasColumnName("HasTheAncillary");
            this.Property(t => t.LTPPre).HasColumnName("LTPPre");
            this.Property(t => t.AdditionPossible).HasColumnName("AdditionPossible");
            this.Property(t => t.LTPPost).HasColumnName("LTPPost");
            this.Property(t => t.FKSnapshot).HasColumnName("FKSnapshot");

            // Relationships
            this.HasRequired(t => t.Snapshot)
                .WithMany(t => t.AncillaryReferencesSnapshots)
                .HasForeignKey(d => d.FKSnapshot);

        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LTV.Data.Models.Mapping
{
    public class SnapshotMap : EntityTypeConfiguration<Snapshot>
    {
        public SnapshotMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Snapshots");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FKTarget).HasColumnName("FKTarget");
            this.Property(t => t.AnnualCollections).HasColumnName("AnnualCollections");
            this.Property(t => t.NumberOfDoctors).HasColumnName("NumberOfDoctors");
            this.Property(t => t.NumberOfPatients).HasColumnName("NumberOfPatients");
            this.Property(t => t.NumberOfVisits).HasColumnName("NumberOfVisits");
            this.Property(t => t.FKStatus).HasColumnName("FKStatus");
            this.Property(t => t.RevenuePerPatient).HasColumnName("RevenuePerPatient");
            this.Property(t => t.RevenuePerVisit).HasColumnName("RevenuePerVisit");
            this.Property(t => t.Profit).HasColumnName("Profit");
            this.Property(t => t.FirstYearRevenue).HasColumnName("FirstYearRevenue");
            this.Property(t => t.FirstYearProfit).HasColumnName("FirstYearProfit");
            this.Property(t => t.FKConfidenceLevel).HasColumnName("FKConfidenceLevel");

            // Relationships
            this.HasRequired(t => t.ConfidenceLevel)
                .WithMany(t => t.Snapshots)
                .HasForeignKey(d => d.FKConfidenceLevel);
            this.HasOptional(t => t.EvaluationStatus)
                .WithMany(t => t.Snapshots)
                .HasForeignKey(d => d.FKStatus);
            this.HasRequired(t => t.Target)
                .WithMany(t => t.Snapshots)
                .HasForeignKey(d => d.FKTarget);

        }
    }
}

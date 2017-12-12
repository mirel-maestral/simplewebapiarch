using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LTV.Data.Models.Mapping
{
    public class EvaluationStatusMap : EntityTypeConfiguration<EvaluationStatus>
    {
        public EvaluationStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EvaluationStatuses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}

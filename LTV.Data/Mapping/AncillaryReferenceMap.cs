using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LTV.Data.Models.Mapping
{
    public class AncillaryReferenceMap : EntityTypeConfiguration<AncillaryReference>
    {
        public AncillaryReferenceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AncillaryName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AncillaryReferences");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AncillaryName).HasColumnName("AncillaryName");
            this.Property(t => t.Revenue).HasColumnName("Revenue");
            this.Property(t => t.Profit).HasColumnName("Profit");
        }
    }
}

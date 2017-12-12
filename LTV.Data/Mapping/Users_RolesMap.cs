using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LTV.Data.Models.Mapping
{
    public class Users_RolesMap : EntityTypeConfiguration<Users_Roles>
    {
        public Users_RolesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Users_Roles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FKUser).HasColumnName("FKUser");
            this.Property(t => t.FKRole).HasColumnName("FKRole");

            // Relationships
            this.HasRequired(t => t.Role)
                .WithMany(t => t.Users_Roles)
                .HasForeignKey(d => d.FKRole);

        }
    }
}

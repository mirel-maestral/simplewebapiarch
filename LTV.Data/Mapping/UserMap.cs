using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LTV.Data.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MiddleName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Salt)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Salt).HasColumnName("Salt");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.IsLockedOut).HasColumnName("IsLockedOut");
            this.Property(t => t.IsOnline).HasColumnName("IsOnline");
            this.Property(t => t.LastActivityDate).HasColumnName("LastActivityDate");
            this.Property(t => t.FKTarget).HasColumnName("FKTarget");

            // Relationships
            this.HasOptional(t => t.Target)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.FKTarget);
            this.HasRequired(t => t.Users_Roles)
                .WithOptional(t => t.User);

        }
    }
}

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LTV.Data.Models.Mapping;
using Repository.Pattern.Ef6;

namespace LTV.Data.Models
{
    public partial class ExtremityLTVDatabaseContext : DataContext
    {
        static ExtremityLTVDatabaseContext()
        {
            Database.SetInitializer<ExtremityLTVDatabaseContext>(null);
        }

        public ExtremityLTVDatabaseContext()
            : base("Name=ExtremityLTVDatabaseContext")
        {
        }

        public DbSet<AncillaryReference> AncillaryReferences { get; set; }
        public DbSet<AncillaryReferencesSnapshot> AncillaryReferencesSnapshots { get; set; }
        public DbSet<Average> Averages { get; set; }
        public DbSet<AveragesSnapshot> AveragesSnapshots { get; set; }
        public DbSet<ConfidenceLevel> ConfidenceLevels { get; set; }
        public DbSet<EvaluationStatus> EvaluationStatuses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Snapshot> Snapshots { get; set; }
        
        public DbSet<Target> Targets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Users_Roles> Users_Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AncillaryReferenceMap());
            modelBuilder.Configurations.Add(new AncillaryReferencesSnapshotMap());
            modelBuilder.Configurations.Add(new AverageMap());
            modelBuilder.Configurations.Add(new AveragesSnapshotMap());
            modelBuilder.Configurations.Add(new ConfidenceLevelMap());
            modelBuilder.Configurations.Add(new EvaluationStatusMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new SnapshotMap());
            modelBuilder.Configurations.Add(new TargetMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new Users_RolesMap());
        }
    }
}

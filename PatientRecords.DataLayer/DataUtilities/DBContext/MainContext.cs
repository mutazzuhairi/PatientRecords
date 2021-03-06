using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PatientRecords.DataLayer.DataUtilities.Extensions;

namespace PatientRecords.DataLayer.DataUtilities.DBContext
{
    public sealed class MainContext : IdentityDbContext<User>
    {
        

        public MainContext (DbContextOptions<MainContext> options) : base(options)
        {

            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddRestrictToRelationshipOnDelete();
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new PatientRecordConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
        } 

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientRecord > PatientRecords { get; set; }
 
 

    }
}

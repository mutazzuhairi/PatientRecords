using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using PatientRecords.DataLayer.DataBasics.Abstractions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PatientRecords.DataLayer.DataBasics.BasicService;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PatientRecords.DataLayer.DataBasics.Extension;

namespace PatientRecords.DataLayer.DataBasics.DBContext
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

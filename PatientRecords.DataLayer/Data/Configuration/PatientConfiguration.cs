using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.DataBasics.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientRecords.DataLayer.Data.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient> 
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
 
        }
    }
}

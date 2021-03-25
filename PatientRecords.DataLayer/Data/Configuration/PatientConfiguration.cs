using PatientRecords.DataLayer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 
namespace PatientRecords.DataLayer.Data.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient> 
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
 
        }
    }
}

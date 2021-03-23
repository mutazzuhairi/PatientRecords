using PatientRecords.DataLayer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 

namespace PatientRecords.DataLayer.Data.Configuration
{
    public class PatientRecordConfiguration : IEntityTypeConfiguration<PatientRecord > 
    {
        public void Configure(EntityTypeBuilder<PatientRecord > builder)
        {
            builder.Property(s => s.Bill).HasPrecision(18, 2);
            builder.Property(b => b.TimeOfEntry).HasDefaultValueSql("getdate()");
 
        }
    }
}

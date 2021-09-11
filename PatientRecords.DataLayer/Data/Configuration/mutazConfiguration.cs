using PatientRecords.DataLayer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PatientRecords.DataLayer.Data.Configuration
{
 
    public class mutazConfiguration : IEntityTypeConfiguration<mutaz> 
    {
        public void Configure(EntityTypeBuilder<mutaz> builder)
        {
 
        }
    }

}





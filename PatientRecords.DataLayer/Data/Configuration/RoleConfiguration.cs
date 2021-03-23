using PatientRecords.DataLayer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PatientRecords.DataLayer.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role> 
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Name).IsRequired();
 
        }
    }
}

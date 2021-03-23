using PatientRecords.DataLayer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PatientRecords.DataLayer.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User> 
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(s=>s.Email).HasMaxLength(100).IsRequired();
            builder.Property(s => s.UserName).HasMaxLength(200).IsRequired();
            builder.Property(s => s.PasswordHash).IsRequired();

        }
    }
}

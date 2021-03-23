using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PatientRecords.DataLayer.DataBasics.Extensions
{
    public static class DataExtension
    {

        public static void AddRestrictToRelationshipOnDelete(this ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
 
 

    }
}

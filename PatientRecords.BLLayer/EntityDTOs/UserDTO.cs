using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
 
namespace PatientRecords.BLLayer.EntityDTOs
{
    public partial class UserDTO  
    {
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}

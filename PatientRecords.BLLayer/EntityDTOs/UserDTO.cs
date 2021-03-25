using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
 
namespace PatientRecords.BLLayer.EntityDTOs
{
    public  class UserDTO : BaseEntityDTO
    {
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(200)]
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }

    }
}

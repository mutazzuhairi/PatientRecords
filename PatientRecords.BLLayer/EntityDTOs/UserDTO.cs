using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.DataLayer.DataBasics.Abstractions;

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
        public string PasswordHash { get; set; }

    }
}

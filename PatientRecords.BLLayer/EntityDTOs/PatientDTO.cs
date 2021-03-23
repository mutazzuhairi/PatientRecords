using PatientRecords.BLLayer.BLBasics.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace PatientRecords.BLLayer.EntityDTOs
{
    public class PatientDTO : BaseEntityDTO
    {

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public string OfficialId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
 
    }
}

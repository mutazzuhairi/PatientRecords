using System;
using System.Collections.Generic;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace PatientRecords.BLLayer.EntityDTOs
{
 
    public partial class PatientDTO : BaseEntityDTO
    {
         [Required]
         [StringLength(200)]
         public string Name { get; set; }
         [Required]
         [StringLength(256)]
         public string OfficialId { get; set; }
         public DateTime? DateOfBirth { get; set; }
         [StringLength(256)]
         public string Email { get; set; }
         public ICollection<PatientRecordDTO> PatientRecords { get; set; }
       
    }
}
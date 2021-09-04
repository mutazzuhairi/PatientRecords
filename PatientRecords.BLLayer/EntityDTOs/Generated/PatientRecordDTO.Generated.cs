using System;
using System.Collections.Generic;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace PatientRecords.BLLayer.EntityDTOs
{
 
    public partial class PatientRecordDTO : BaseEntityDTO
    {
         [Required]
         [StringLength(100)]
         public string DiseaseName { get; set; }
         public DateTime TimeOfEntry { get; set; }
         public string Description { get; set; }
         public decimal Bill { get; set; }
         [Required]
         public int PatientId { get; set; }
         public PatientDTO Patient { get; set; }
       
    }
}
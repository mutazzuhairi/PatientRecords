using PatientRecords.BLLayer.BLUtilities.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace PatientRecords.BLLayer.EntityDTOs
{
    public class PatientRecordDTO : BaseEntityDTO
    {
 
        [Required]
        [StringLength(100)]
        public string DiseaseName { get; set; }
        public DateTime? TimeOfEntry { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public decimal Bill { get; set; }
        [Required]
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }

        public string SearchField { get; set; }
    }
}

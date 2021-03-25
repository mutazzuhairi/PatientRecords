using PatientRecords.DataLayer.DataUtilities.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
 
namespace PatientRecords.DataLayer.Data.Entities
{
    public class PatientRecord : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string DiseaseName { get; set; }
        public DateTime TimeOfEntry { get; set; }
        public string 	Description  { get; set; }
        public decimal Bill  { get; set; }
        [Required]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}

using PatientRecords.DataLayer.DataBasics.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

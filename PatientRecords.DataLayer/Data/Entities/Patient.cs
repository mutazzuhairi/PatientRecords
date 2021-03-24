using PatientRecords.DataLayer.DataUtilities.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.DataLayer.Data.Entities
{
    public class Patient : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string OfficialId  { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        public ICollection<PatientRecord > PatientRecords { get; set; }

    }
}

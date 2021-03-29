using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
 

namespace PatientRecords.DataLayer.Data.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
        [StringLength(200)]
        public string UpdatedBy { get; set; } = string.Empty;
        [StringLength(200)]
        public string CreatedBy { get; set; } = string.Empty;
        public string SearchField { get; set; } = string.Empty;


    }
}

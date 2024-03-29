﻿using System.ComponentModel.DataAnnotations;
 

namespace PatientRecords.BLLayer.Extends.ExtendModelClasses
{
    public class SignUpUserModel
    {
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
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
   
 

    }
}

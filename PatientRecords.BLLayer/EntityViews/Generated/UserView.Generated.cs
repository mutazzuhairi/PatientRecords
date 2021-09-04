using System;
using System.Collections.Generic;
using PatientRecords.BLLayer.BLUtilities.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace PatientRecords.BLLayer.EntityViews
{
 
    public partial class UserView : BaseEntityView
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
         public string UpdatedBy { get; set; }
         [StringLength(200)]
         public string CreatedBy { get; set; }
         public string SearchField { get; set; }
       
    }
}
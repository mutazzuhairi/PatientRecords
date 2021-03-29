using System;
using System.ComponentModel.DataAnnotations;

namespace PatientRecords.DataLayer.DataUtilities.Abstractions
{
    public abstract class  BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
        [Required]
        public virtual DateTime CreatedDate { get; set; }
        [Required]
        public virtual DateTime UpdatedDate { get; set; }
        [StringLength(200)]
        public string UpdatedBy { get; set; } = string.Empty;
        [StringLength(200)]
        public string CreatedBy { get; set; } = string.Empty;
        public string SearchField { get; set; } = string.Empty;


    }
}

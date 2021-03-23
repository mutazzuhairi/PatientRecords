using PatientRecords.DataLayer.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PatientRecords.DataLayer.DataBasics.Abstractions
{
    public abstract class  BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
        [Required]
        public virtual DateTime CreatedDate { get; set; }
        [Required]
        public virtual DateTime UpdatedDate { get; set; }
        [Required]
        [StringLength(200)]
        public string UpdatedBy { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; } = string.Empty;

    }
}

using PatientRecords.BLLayer.EntityDTOs;
using System;
 
namespace PatientRecords.BLLayer.BLBasics.Abstractions
{
    public class BaseEntityDTO
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual string UpdatedBy { get; set; }
        public virtual string CreatedBy { get; set; }
 
    }
}

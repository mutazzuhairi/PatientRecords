using PatientRecords.BLLayer.EntityDTOs;
using System;
 
namespace PatientRecords.BLLayer.BLBasics.Abstractions
{
    public class BaseEntityDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
 
    }
}

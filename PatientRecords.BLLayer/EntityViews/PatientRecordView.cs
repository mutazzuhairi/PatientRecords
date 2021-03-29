

using PatientRecords.BLLayer.EntityDTOs;
using System;

namespace PatientRecords.BLLayer.EntityViews
{
    public class PatientRecordView 
    {
        public int Id { get; set; }
        public string DiseaseName { get; set; }
        public DateTime TimeOfEntry { get; set; }
        public string Description { get; set; }
        public decimal Bill { get; set; }
        public int PatientId { get; set; }
        public PatientView Patient { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string SearchField { get; set; }

    }
}

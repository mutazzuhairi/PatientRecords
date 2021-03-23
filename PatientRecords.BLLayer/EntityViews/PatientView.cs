
using System;
using System.Collections.Generic;

namespace PatientRecords.BLLayer.EntityViews
{
    public class PatientView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OfficialId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<PatientRecordView> PatientRecords { get; set; }

    }
}

using PatientRecords.BLLayer.BLBasics.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
 

namespace PatientRecords.BLLayer.QueryServices.Interfaces
{
    public interface IPatientRecordQueryService : IQueryService<PatientRecordDTO, PatientRecordView>
    {
        public bool IsDiseaseNameAlreadyExist(string diseaseName);
    }

}

using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
 

namespace PatientRecords.BLLayer.QueryServices.Interfaces
{
    public interface IPatientQueryService : IQueryService<PatientDTO, PatientView>
    {
        public bool IsOfficialIdAlreadyExist(string officialId,int entityId);
        public bool IsEmailAlreadyExist(string email, int entityId);
    }

}

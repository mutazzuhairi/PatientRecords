using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.QueryServices.Interfaces
{
    public interface IPatientRecordQueryService : IQueryService<PatientRecordDTO, PatientRecordView>
    {
        public bool IsDiseaseNameAlreadyExist(string diseaseName);
        public Task<PagedResponse<List<PatientRecordView>>> GetAllForPatientId(PaginationFilter filter, string route, int patientId);

    }

}

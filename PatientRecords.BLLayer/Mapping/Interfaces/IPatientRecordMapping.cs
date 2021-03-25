using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
 
namespace PatientRecords.BLLayer.Mapping.Interfaces
{
    public interface IPatientRecordMapping : IMapping<PatientRecord , PatientRecordDTO>
    {
       
    }
}

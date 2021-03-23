using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.BLLayer.BLBasics.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
 
namespace PatientRecords.BLLayer.Mapping.Interfaces
{
    public interface IPatientMapping : IMapping<Patient, PatientDTO>
    {
       
    }
}

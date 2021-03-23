using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.BLLayer.BLBasics.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
 
namespace PatientRecords.BLLayer.Mapping.Interfaces
{
    public interface IUserMapping : IMapping<User, UserDTO>
    {
       
    }
}

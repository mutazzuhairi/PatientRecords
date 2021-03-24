using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
 
namespace PatientRecords.BLLayer.Mapping.Interfaces
{
    public interface IUserMapping : IMapping<User, UserDTO>
    {
       
    }
}

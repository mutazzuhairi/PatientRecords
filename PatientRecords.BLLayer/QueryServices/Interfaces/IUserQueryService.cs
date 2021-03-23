using PatientRecords.BLLayer.BLBasics.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
 

namespace PatientRecords.BLLayer.QueryServices.Interfaces
{
    public interface IUserQueryService : IQueryService<UserDTO, UserView>
    {
 
    }

}

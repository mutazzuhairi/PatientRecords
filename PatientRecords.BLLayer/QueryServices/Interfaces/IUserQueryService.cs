using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.DataLayer.Data.Entities;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.QueryServices.Interfaces
{
    public interface IUserQueryService : IQueryService<UserDTO, UserView>
    {
        public Task<User> FindByEmailAsync(string email);
        public Task<bool> CheckPasswordAsync(User user, string password);
        public Task<UserDTO> FindUserDTOByEmailAsync(string email);
        public bool IsUserNameAlreadyExist(string userName);
    }

}

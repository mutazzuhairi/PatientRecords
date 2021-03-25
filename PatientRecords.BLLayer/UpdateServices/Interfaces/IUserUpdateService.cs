using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.UpdateServices.Interfaces
{
    public interface IUserUpdateService : IUpdateService<UserDTO>
    {
        public Task SetLockoutEnabledAsync(string userId, bool enabled);
        public Task AddToRoleAsync(string userId, string role);
        public Task<UserDTO> CustomCreateAsync(UserDTO entityDTO, string password);
        public Task<UserDTO> CustomUpdateAsync(UserDTO entityDTO);
        public Task UpdatePasswordAsync(string userId, string currentPassword, string newPassword);
        public Task RemoveFromRoleAsync(string userId, string role);
    }
}

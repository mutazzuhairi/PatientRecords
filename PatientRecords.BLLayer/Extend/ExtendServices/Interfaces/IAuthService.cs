using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.Extend.ExtendModelClasses;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.Extend.ExtendServices.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResponseModel> Login(UserAuthModel userAuthModel);
 
    }
}

using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.Extends.ExtendModelClasses;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.Extends.ExtendServices.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResponseModel> Login(UserAuthModel userAuthModel);
 
    }
}

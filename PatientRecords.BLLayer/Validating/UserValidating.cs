using PatientRecords.BLLayer.EntityDTOs;
using System.Collections.Generic;
using PatientRecords.BLLayer.BLBasics.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;

namespace PatientRecords.BLLayer.Validating
{
    public class UserValidating : IUserValidating
    {
        public void Validate(UserDTO entityDTO, List<string> ValidationErrors, bool isNewEntity)
        {
 
 
        }
    }
}

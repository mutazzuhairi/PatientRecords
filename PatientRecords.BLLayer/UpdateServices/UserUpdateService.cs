using PatientRecords.BLLayer.BLBasics.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using PatientRecords.BLLayer.BLBasics.HelperServices.Interfaces;
using System;

namespace PatientRecords.BLLayer.UpdateServices
{
    public class UserUpdateService : EntityUpdateService<User, IUserRepositry, UserDTO, IUserMapping, IUserValidating>, IUserUpdateService
    {
 
        public UserUpdateService(IUserRepositry entityRepositry, 
                                 IUserValidating entityValidating, 
                                 IUserMapping entityMapping,
                                 Lazy<IServiceBuildException> serviceBuildException,
                                 IMapper mapper) :
            base(entityRepositry, entityValidating, entityMapping, serviceBuildException, mapper)
        {

        }


        public override async Task<UserDTO> CreateAsync(UserDTO entityDTO)
        {
          return await base.CreateAsync(entityDTO);

        }

        public override async Task<UserDTO> UpdateAsync(UserDTO entityDTO, params object[] keyValues)
        {
            return await base.UpdateAsync(entityDTO, keyValues);

        }
    }
}

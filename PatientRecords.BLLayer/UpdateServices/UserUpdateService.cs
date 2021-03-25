using PatientRecords.BLLayer.BLUtilities.Abstractions;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System;
using System.Collections.Generic;

namespace PatientRecords.BLLayer.UpdateServices
{
    public class UserUpdateService : EntityUpdateService<User, IUserRepositry, UserDTO, IUserMapping, IUserValidating>, IUserUpdateService
    {

        private readonly Lazy<IUserRepositry> _entityRepositry;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;
        private Lazy<IUserValidating> _entityValidating;
        private Lazy<IUserMapping> _entityMapping;
        private List<string> _vealidationErrors;
        public UserUpdateService(Lazy<IUserRepositry> entityRepositry,
                                 Lazy<IUserValidating> entityValidating,
                                 Lazy<IUserMapping> entityMapping,
                                 Lazy<IServiceBuildException> serviceBuildException,
                                 IMapper mapper) :
            base(entityRepositry, entityValidating, entityMapping, serviceBuildException, mapper)
        {
            _entityRepositry = entityRepositry;
            _entityValidating = entityValidating;
            _entityMapping = entityMapping;
            _serviceBuildException = serviceBuildException;
            _vealidationErrors = new List<string>();
        }
 

        public async Task AddToRoleAsync(string userId, string role)
        {
            User user = await _entityRepositry.Value.FindAsync(userId);
            await _entityRepositry.Value.AddToRoleAsync(user, role);

        }

        public async Task SetLockoutEnabledAsync(string userId, bool enabled)
        {
            User user = await _entityRepositry.Value.FindAsync(userId);
            await _entityRepositry.Value.SetLockoutEnabledAsync(user, enabled);

        }


        public async Task UpdatePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            User user = await _entityRepositry.Value.FindAsync(userId);
            await _entityRepositry.Value.UpdatePasswordAsync(user, currentPassword, newPassword);

        }


        public async Task RemoveFromRoleAsync(string userId, string role)
        {
            User user = await _entityRepositry.Value.FindAsync(userId);
            await _entityRepositry.Value.RemoveFromRoleAsync(user, role);

        }

        public async Task<UserDTO> CustomUpdateAsync(UserDTO entityDTO)
        {
            bool  isNewEntity = false;
            _entityValidating.Value.Validate(entityDTO, _vealidationErrors, isNewEntity);
            if (this._vealidationErrors.Count == 0)
            {
                User entityPoco = await _entityRepositry.Value.FindAsync(entityDTO.Id);
                _entityMapping.Value.MapEntity(entityPoco, entityDTO, isNewEntity);
                await _entityRepositry.Value.UpdateAsync(entityPoco);
            }
            else
                _serviceBuildException.Value.BuildException(this._vealidationErrors.ToArray());

            return entityDTO;
        }

        public async Task<UserDTO> CustomCreateAsync(UserDTO entityDTO, string password)
        {
             bool isNewEntity = true;
             User  entityPoco = new User();
             _entityValidating.Value.Validate(entityDTO, _vealidationErrors, isNewEntity);
            if (this._vealidationErrors.Count == 0)
            {
                 _entityMapping.Value.MapEntity(entityPoco, entityDTO, isNewEntity);
                 await _entityRepositry.Value.CreateAsync(entityPoco, password);
            }
            else
                _serviceBuildException.Value.BuildException(this._vealidationErrors.ToArray());

            return entityDTO;
        }
 
    }
}

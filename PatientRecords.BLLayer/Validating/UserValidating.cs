using PatientRecords.BLLayer.EntityDTOs;
using System.Collections.Generic;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using System;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.BLUtilities.SystemConstants;
using PatientRecords.BLLayer.QueryServices.Interfaces;

namespace PatientRecords.BLLayer.Validating
{
    public class UserValidating : IUserValidating
    {
        private readonly Lazy<ICommonServices> _iCommonServices;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;
        private readonly Lazy<IUserQueryService> _iUserQueryService;

        public UserValidating(Lazy<ICommonServices>  iCommonServices,
                              Lazy<IServiceBuildException>  serviceBuildException,
                              Lazy<IUserQueryService> iUserQueryService)
        {
            _iCommonServices = iCommonServices;
            _serviceBuildException = serviceBuildException;
            _iUserQueryService = iUserQueryService;
        }
        public void Validate(UserDTO entityDTO, List<string> validationErrors, bool isNewEntity)
        {
            if (!IsEmailValid(entityDTO.Email))
            {
                _serviceBuildException.Value.BuildException(SystemConstatnts.ValidationMessage.EmailNotValid);
            }
            else if (IsUserNameAlreadyExist(entityDTO.UserName,   entityDTO.Id+""))
            {
                _serviceBuildException.Value.BuildException(SystemConstatnts.ValidationMessage.UserNameAlreadyExist);
            }
        }


        private bool IsEmailValid(string email)
        {
            return _iCommonServices.Value.IsEmailValid(email);
        }

        private bool IsUserNameAlreadyExist(string userName,string entityId)
        {
            return _iUserQueryService.Value.IsUserNameAlreadyExist(userName, entityId);
        }
    }
}

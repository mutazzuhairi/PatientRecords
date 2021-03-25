using PatientRecords.BLLayer.EntityDTOs;
using System.Collections.Generic;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using System;
using PatientRecords.BLLayer.BLUtilities.HelperServices;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.BLUtilities.SystemConstants;

namespace PatientRecords.BLLayer.Validating
{
    public class PatientValidating : IPatientValidating
    {
        private readonly Lazy<IPatientQueryService> _iPatientQueryService;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;
        private readonly Lazy<ICommonServices> _iCommonServices;

        public PatientValidating(Lazy<IPatientQueryService> iPatientQueryService,
                                 Lazy<IServiceBuildException> serviceBuildException,
                                 Lazy<ICommonServices> iCommonServices)
        {
            _iPatientQueryService = iPatientQueryService;
            _serviceBuildException = serviceBuildException;
            _iCommonServices = iCommonServices;
        }
        public void Validate(PatientDTO entityDTO, List<string> validationErrors, bool isNewEntity)
        {

            if (IsOfficialIdAlreadyExist(entityDTO.OfficialId))
            {
                _serviceBuildException.Value.BuildException(SystemConstatnts.ValidationMessage.OfficialIdAlreadyExist);
            }
            else if (!string.IsNullOrEmpty(entityDTO.Email) && IsEmailAlreadyExist(entityDTO.Email))
            {
                _serviceBuildException.Value.BuildException(SystemConstatnts.ValidationMessage.EmailAlreadyExist);
            }
            else if (!string.IsNullOrEmpty(entityDTO.Email) && !IsEmailValid(entityDTO.Email))
            {
                _serviceBuildException.Value.BuildException(SystemConstatnts.ValidationMessage.EmailNotValid);
            }
        }


        private bool IsOfficialIdAlreadyExist(string officialId)
        {
            return _iPatientQueryService.Value.IsOfficialIdAlreadyExist(officialId);
        }

        private bool IsEmailAlreadyExist(string email)
        {
            return _iPatientQueryService.Value.IsEmailAlreadyExist(email);
        }

        private bool IsEmailValid(string email)
        {
            return _iCommonServices.Value.IsEmailValid(email);
        }
    }
}

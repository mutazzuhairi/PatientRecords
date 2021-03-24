using PatientRecords.BLLayer.EntityDTOs;
using System.Collections.Generic;
using PatientRecords.BLLayer.BLUtilities.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using System;
using PatientRecords.BLLayer.BLUtilities.HelperServices;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;

namespace PatientRecords.BLLayer.Validating
{
    public class PatientValidating : IPatientValidating
    {
        private readonly Lazy<IPatientQueryService> _iPatientQueryService;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;

        public PatientValidating(Lazy<IPatientQueryService> iPatientQueryService,
                                 Lazy<IServiceBuildException> serviceBuildException)
        {
            _iPatientQueryService = iPatientQueryService;
            _serviceBuildException = serviceBuildException;
        }
        public void Validate(PatientDTO entityDTO, List<string> ValidationErrors, bool isNewEntity)
        {

            if (IsOfficialIdAlreadyExist(entityDTO.OfficialId))
            {
                _serviceBuildException.Value.BuildException("This official id already exist.");
            }
            if (!string.IsNullOrEmpty(entityDTO.Email) && IsEmailAlreadyExist(entityDTO.OfficialId))
            {
                _serviceBuildException.Value.BuildException("This email already exist.");
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
    }
}

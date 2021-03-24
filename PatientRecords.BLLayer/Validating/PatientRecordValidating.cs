using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using System;
using System.Collections.Generic;
 
namespace PatientRecords.BLLayer.Validating
{
    public class PatientRecordValidating : IPatientRecordValidating
    {
        private readonly Lazy<IPatientRecordQueryService> _iPatientRecordQueryService;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;

        public PatientRecordValidating(Lazy<IPatientRecordQueryService> iPatientRecordQueryService,
                                      Lazy<IServiceBuildException> serviceBuildException)
        {
            _iPatientRecordQueryService = iPatientRecordQueryService;
            _serviceBuildException = serviceBuildException;

        }
        public void Validate(PatientRecordDTO entityDTO, List<string> ValidationErrors, bool isNewEntity)
        {

            if (IsDiseaseNameAlreadyExist(entityDTO.DiseaseName))
            {
                _serviceBuildException.Value.BuildException("This disease name already exist.");
            }

        }


        private bool IsDiseaseNameAlreadyExist(string diseaseName)
        {
            return _iPatientRecordQueryService.Value.IsDiseaseNameAlreadyExist(diseaseName);
        }
    }
}

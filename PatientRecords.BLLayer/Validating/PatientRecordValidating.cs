using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using System.Collections.Generic;
using System;

namespace PatientRecords.BLLayer.Validating
{
    public class PatientRecordValidating : IPatientRecordValidating
    { 
        public PatientRecordValidating(Lazy<IPatientRecordQueryService> iPatientRecordQueryService,
                                      Lazy<IServiceBuildException> serviceBuildException)
        {

        }
        public void Validate(PatientRecordDTO entityDTO, List<string> validationErrors, bool isNewEntity)
        {

        }
 
    }
}

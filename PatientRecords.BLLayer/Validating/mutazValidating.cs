using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using System.Collections.Generic;
using System;

namespace PatientRecords.BLLayer.Validating
{
 
    public class mutazValidating : ImutazValidating
    { 
        private readonly Lazy<ImutazQueryService> _iEntityQueryService;
        private readonly Lazy<ICommonServices> _iCommonServices;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;

        public mutazValidating(Lazy<ImutazQueryService> iEntityQueryService,
                                      Lazy<ICommonServices> iCommonServices,
                                      Lazy<IServiceBuildException> serviceBuildException)
        {

            _iEntityQueryService = iEntityQueryService;
            _iCommonServices = iCommonServices;
            _serviceBuildException = serviceBuildException;

        }
        public void Validate(mutazDTO entityDTO, List<string> validationErrors, bool isNewEntity)
        {

        }
 
    }

}

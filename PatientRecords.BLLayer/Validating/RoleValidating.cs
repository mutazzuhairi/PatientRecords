using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;
using System.Collections.Generic;
using System;

namespace PatientRecords.BLLayer.Validating
{
 
    public class RoleValidating : IRoleValidating
    { 
        private readonly Lazy<IRoleQueryService> _iEntityQueryService;
        private readonly Lazy<ICommonServices> _iCommonServices;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;

        public RoleValidating(Lazy<IRoleQueryService> iEntityQueryService,
                                      Lazy<ICommonServices> iCommonServices,
                                      Lazy<IServiceBuildException> serviceBuildException)
        {

            _iEntityQueryService = iEntityQueryService;
            _iCommonServices = iCommonServices;
            _serviceBuildException = serviceBuildException;

        }
        public void Validate(RoleDTO entityDTO, List<string> validationErrors, bool isNewEntity)
        {

        }
 
    }

}

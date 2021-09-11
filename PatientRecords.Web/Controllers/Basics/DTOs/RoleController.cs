using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;
using System;

namespace PatientRecords.Web.Controllers.Basics.DTOs
{
 
    public class RoleController : CustomBaseController<RoleDTO, RoleView, IRoleUpdateService, IRoleQueryService>
    {
        private readonly Lazy<IRoleQueryService> _iEntityQueryService;
        private readonly Lazy<IRoleUpdateService> _iEntityUpdateService;
        private readonly Lazy<IApiExceptionBuilder> _iApiExceptionBuilder;

        public RoleController(Lazy<IRoleQueryService> iEntityQueryService,
                                     Lazy<IRoleUpdateService> iEntityUpdateService,
                                     Lazy<IApiExceptionBuilder> iApiExceptionBuilder) :
            base(iEntityQueryService, iEntityUpdateService, iApiExceptionBuilder)
        {

           _iEntityQueryService = iEntityQueryService;
           _iEntityUpdateService = iEntityUpdateService;
           _iApiExceptionBuilder = iApiExceptionBuilder;

        }


    }

}



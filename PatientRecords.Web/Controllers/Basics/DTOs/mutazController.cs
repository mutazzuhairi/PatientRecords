using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;
using System;

namespace PatientRecords.Web.Controllers.Basics.DTOs
{
 
    public class mutazController : CustomBaseController<mutazDTO, mutazView, ImutazUpdateService, ImutazQueryService>
    {
        private readonly Lazy<ImutazQueryService> _iEntityQueryService;
        private readonly Lazy<ImutazUpdateService> _iEntityUpdateService;
        private readonly Lazy<IApiExceptionBuilder> _iApiExceptionBuilder;

        public mutazController(Lazy<ImutazQueryService> iEntityQueryService,
                                     Lazy<ImutazUpdateService> iEntityUpdateService,
                                     Lazy<IApiExceptionBuilder> iApiExceptionBuilder) :
            base(iEntityQueryService, iEntityUpdateService, iApiExceptionBuilder)
        {

           _iEntityQueryService = iEntityQueryService;
           _iEntityUpdateService = iEntityUpdateService;
           _iApiExceptionBuilder = iApiExceptionBuilder;

        }


    }

}



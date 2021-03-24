using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.QueryServices;
using PatientRecords.Web.WebUtilities.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.QueryServices.Interfaces;

namespace PatientRecords.Web.Controllers.Views
{
     
    public class UserViewController : CustomBaseViewController<UserDTO,UserView, IUserQueryService>
    {
        private readonly Lazy<IUserQueryService> _entityQueryService;
        private readonly Lazy<IApiExceptionBuilder> _iApiExceptionBuilder;
 
        public UserViewController(Lazy<IUserQueryService> entityQueryService,
                                  Lazy<IApiExceptionBuilder> iApiExceptionBuilder) :
            base(entityQueryService, iApiExceptionBuilder)
        {
            _entityQueryService = entityQueryService;
            _iApiExceptionBuilder = iApiExceptionBuilder;

        }


    }
}

using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;

namespace PatientRecords.Web.Controllers.Basics.Views
{

    public class UserController : CustomBaseController<UserDTO, UserView, IUserUpdateService, IUserQueryService>
    {


        public UserController(Lazy<IUserQueryService> entityQueryService,
                              Lazy<IUserUpdateService> entityUpdateService,
                              Lazy<IApiExceptionBuilder> iApiExceptionBuilder) :
          
            base(entityQueryService, entityUpdateService, iApiExceptionBuilder)
        {


        }


    }
}

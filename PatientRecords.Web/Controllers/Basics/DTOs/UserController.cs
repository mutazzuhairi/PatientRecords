using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebBasics.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using PatientRecords.Web.WebBasics.BasicServices.Interfaces;

namespace PatientRecords.Web.Controllers.Basics.Views
{

    public class UserController : CustomBaseController<UserDTO, UserView, IUserUpdateService, IUserQueryService>
    {


        public UserController(Lazy<IUserQueryService> entityQueryService,
                              Lazy<IUserUpdateService> entityUpdateService,
                              Lazy<IApiExceptionBuildercs> iApiExceptionBuildercs,
                              Lazy<ITransactionFactory> transactionFactory) :
          
            base(entityQueryService, entityUpdateService, iApiExceptionBuildercs, transactionFactory)
        {


        }


    }
}

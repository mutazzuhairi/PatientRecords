using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.QueryServices;
using PatientRecords.Web.WebBasics.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.Web.WebBasics.Interfaces;
using PatientRecords.DataLayer.DataBasics.BasicService;
using PatientRecords.BLLayer.UpdateServices;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;

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

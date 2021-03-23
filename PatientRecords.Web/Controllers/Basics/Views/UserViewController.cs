using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.QueryServices;
using PatientRecords.Web.WebBasics.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.Web.WebBasics.Interfaces;
using PatientRecords.DataLayer.DataBasics.BasicService;

namespace PatientRecords.Web.Controllers.Views
{
     
    public class UserViewController : CustomBaseViewController<UserDTO,UserView, UserQueryService>
    {
        private readonly Lazy<UserQueryService> _entityQueryService;
        private readonly Lazy<IApiExceptionBuildercs> _iApiExceptionBuildercs;
        private readonly Lazy<ITransactionFactory> _iTransactionFactory;

        public UserViewController(Lazy<UserQueryService> entityQueryService,
                                  Lazy<IApiExceptionBuildercs> iApiExceptionBuildercs,
                                  Lazy<ITransactionFactory> transactionFactory) :
            base(entityQueryService, iApiExceptionBuildercs, transactionFactory)
        {
            _entityQueryService = entityQueryService;
            _iApiExceptionBuildercs = iApiExceptionBuildercs;
            _iTransactionFactory = transactionFactory;

        }


    }
}

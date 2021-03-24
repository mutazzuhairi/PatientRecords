using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;

namespace PatientRecords.Web.Controllers.Views
{
     
    public class PatientViewController : CustomBaseViewController<PatientDTO, PatientView, IPatientQueryService>
    {
        private readonly Lazy<IPatientQueryService> _entityQueryService;
        private readonly Lazy<IApiExceptionBuilder> _iApiExceptionBuilder;
        private readonly Lazy<ITransactionFactory> _iTransactionFactory;

        public PatientViewController(Lazy<IPatientQueryService> entityQueryService, 
                                  Lazy<IApiExceptionBuilder> iApiExceptionBuilder) :
            base(entityQueryService, iApiExceptionBuilder)
        {
            _entityQueryService = entityQueryService;
            _iApiExceptionBuilder = iApiExceptionBuilder;

        }


    }
}

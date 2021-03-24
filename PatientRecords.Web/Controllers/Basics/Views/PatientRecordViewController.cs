using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;

namespace PatientRecords.Web.Controllers.Views
{
     
    public class PatientRecordViewController : CustomBaseViewController<PatientRecordDTO, PatientRecordView, IPatientRecordQueryService>
    {
        private readonly Lazy<IPatientRecordQueryService> _entityQueryService;
        private readonly Lazy<IApiExceptionBuilder> _iApiExceptionBuilder;

        public PatientRecordViewController(Lazy<IPatientRecordQueryService> entityQueryService, 
                                         Lazy<IApiExceptionBuilder> iApiExceptionBuilder) :
            base(entityQueryService, iApiExceptionBuilder)
        {
            _entityQueryService = entityQueryService;
            _iApiExceptionBuilder = iApiExceptionBuilder;

        }


    }
}

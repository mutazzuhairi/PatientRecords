using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;

namespace PatientRecords.Web.Controllers.Basics.DTOs
{

    public class PatientRecordController : CustomBaseController<PatientRecordDTO, PatientRecordView, IPatientRecordUpdateService, IPatientRecordQueryService>
    {


        public PatientRecordController(Lazy<IPatientRecordQueryService> entityQueryService,
                                        Lazy<IPatientRecordUpdateService> entityUpdateService,
                                        Lazy<IApiExceptionBuilder> iApiExceptionBuilder) :

            base(entityQueryService, entityUpdateService, iApiExceptionBuilder)
        {


        }


    }
}

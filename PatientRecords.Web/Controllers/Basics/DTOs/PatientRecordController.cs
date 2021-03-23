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

    public class PatientRecordController : CustomBaseController<PatientRecordDTO, PatientRecordView, IPatientRecordUpdateService, IPatientRecordQueryService>
    {


        public PatientRecordController(Lazy<IPatientRecordQueryService> entityQueryService,
                                        Lazy<IPatientRecordUpdateService> entityUpdateService,
                                        Lazy<IApiExceptionBuildercs> iApiExceptionBuildercs,
                                        Lazy<ITransactionFactory> transactionFactory) :

            base(entityQueryService, entityUpdateService, iApiExceptionBuildercs, transactionFactory)
        {


        }


    }
}

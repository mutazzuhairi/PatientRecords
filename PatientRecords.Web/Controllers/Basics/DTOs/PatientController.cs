using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebBasics.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using PatientRecords.Web.WebBasics.BasicServices.Interfaces;

namespace PatientRecords.Web.Controllers.Views
{

    public class PatientsController : CustomBaseController<PatientDTO, PatientView, IPatientUpdateService, IPatientQueryService>
    {


        public PatientsController(Lazy<IPatientQueryService> entityQueryService,
                                     Lazy<IPatientUpdateService> entityUpdateService,
                                     Lazy<IApiExceptionBuildercs> iApiExceptionBuildercs,
                                     Lazy<ITransactionFactory> transactionFactory) :
            base(entityQueryService, entityUpdateService, iApiExceptionBuildercs, transactionFactory)
        {


        }


    }
}

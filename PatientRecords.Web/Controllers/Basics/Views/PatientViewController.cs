﻿using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebBasics.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.Web.WebBasics.HelperServices.Interfaces;

namespace PatientRecords.Web.Controllers.Views
{
     
    public class PatientViewController : CustomBaseViewController<PatientDTO, PatientView, IPatientQueryService>
    {
        private readonly Lazy<IPatientQueryService> _entityQueryService;
        private readonly Lazy<IApiExceptionBuildercs> _iApiExceptionBuildercs;
        private readonly Lazy<ITransactionFactory> _iTransactionFactory;

        public PatientViewController(Lazy<IPatientQueryService> entityQueryService, 
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

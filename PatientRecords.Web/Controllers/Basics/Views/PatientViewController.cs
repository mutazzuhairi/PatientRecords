﻿using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;

namespace PatientRecords.Web.Controllers.Basics.Views
{
     
    public class PatientViewController : CustomBaseViewController<PatientDTO, PatientView, IPatientQueryService>
    {
         

        public PatientViewController(Lazy<IPatientQueryService> entityQueryService) :
            base(entityQueryService)
        {
        

        }


    }
}

using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using System;

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

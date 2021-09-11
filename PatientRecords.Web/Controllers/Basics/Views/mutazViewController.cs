using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using System;

namespace PatientRecords.Web.Controllers.Basics.Views
{
 
    public class mutazViewController : CustomBaseViewController<mutazDTO, mutazView, ImutazQueryService>
    {

        private readonly Lazy<ImutazQueryService> _iEntityQueryService;         

        public mutazViewController(Lazy<ImutazQueryService> iEntityQueryService) :
            base(iEntityQueryService)
        {
        
          _iEntityQueryService = iEntityQueryService;
        }


    }

}





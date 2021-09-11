using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using System;

namespace PatientRecords.Web.Controllers.Basics.Views
{
 
    public class RoleViewController : CustomBaseViewController<RoleDTO, RoleView, IRoleQueryService>
    {

        private readonly Lazy<IRoleQueryService> _iEntityQueryService;         

        public RoleViewController(Lazy<IRoleQueryService> iEntityQueryService) :
            base(iEntityQueryService)
        {
        
          _iEntityQueryService = iEntityQueryService;
        }


    }

}





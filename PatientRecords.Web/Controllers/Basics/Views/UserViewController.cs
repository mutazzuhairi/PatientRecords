using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;

namespace PatientRecords.Web.Controllers.Basics.Views
{
     
    public class UserViewController : CustomBaseViewController<UserDTO,UserView, IUserQueryService>
    { 
        public UserViewController(Lazy<IUserQueryService> entityQueryService) :
            base(entityQueryService)
        {
 

        }


    }
}

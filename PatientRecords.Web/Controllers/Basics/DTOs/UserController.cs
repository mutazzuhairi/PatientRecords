using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;

namespace PatientRecords.Web.Controllers.Basics.DTOs
{

    public class UserController : CustomBaseController<UserDTO, UserView, IUserUpdateService, IUserQueryService>
    {

        private readonly Lazy<IUserUpdateService> _iUserUpdateService;
        private readonly Lazy<IUserQueryService> _iEntityQueryService;

        public UserController(Lazy<IUserQueryService> entityQueryService,
                              Lazy<IUserUpdateService> entityUpdateService,
                              Lazy<IApiExceptionBuilder> iApiExceptionBuilder) :

            base(entityQueryService, entityUpdateService, iApiExceptionBuilder)
        {

            _iUserUpdateService = entityUpdateService;
            _iEntityQueryService = entityQueryService;
        }


        [HttpPut]
        public override async Task<ActionResult<UserDTO>> Put(UserDTO userDTO)
        {
            await _iUserUpdateService.Value.CustomUpdateAsync(userDTO);
            return Ok(new Response<UserDTO>(userDTO));
        }
 
    }
}
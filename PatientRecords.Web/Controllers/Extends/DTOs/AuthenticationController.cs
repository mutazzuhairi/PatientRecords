
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PatientRecords.BLLayer.Extends.ExtendModelClasses;
using AutoMapper;
using PatientRecords.BLLayer.Extends.ExtendServices.Interfaces;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using PatientRecords.BLLayer.EntityDTOs;

namespace PatientRecords.Web.Controllers.Extends.DTOs
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly Lazy<IAuthService> _iAuthService;
        private readonly Lazy<IUserUpdateService> _iUserUpdateService;
        private readonly IMapper _mapper;

        public AuthenticationController(Lazy<IAuthService> iAuthService,
                                        Lazy<IUserUpdateService> iUserUpdateService,
                                        IMapper mapper)
        {
            _iAuthService = iAuthService;
            _iUserUpdateService = iUserUpdateService;
            _mapper = mapper;
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseModel>> Login(UserAuthModel userAuthModel)
        {
 
            AuthResponseModel authResult = await _iAuthService.Value.Login(userAuthModel);
            if (authResult == null)
                return Unauthorized(new AuthResponseModel { ErrorMessage = "Invalid Authentication" });
            return Ok(new Response<AuthResponseModel>(authResult));
 
        }

        [HttpPost("SignUp")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> PostSignUp(SignUpUserModel signUpUserModel)
        {
 
            UserDTO userDTO = this._mapper.Map<UserDTO>(signUpUserModel);
            await _iUserUpdateService.Value.CustomCreateAsync(userDTO, signUpUserModel.Password);
            return Ok(new Response<UserDTO>(userDTO));
 
        }
 

        [HttpPut("EnableUser/{email}")]
        public async Task<ActionResult<UserDTO>> PutEnableUser(string userId)
        { 
            await _iUserUpdateService.Value.SetLockoutEnabledAsync(userId, true);
            return Ok();
 
        }
  
        [HttpPost("UserRole")]
        public async Task<ActionResult<UserDTO>> PostUserRole(string userId, string role)
        {
            await _iUserUpdateService.Value.AddToRoleAsync(userId, role);
            return Ok();

        }


        [HttpDelete("UserRole")]
        public async Task<ActionResult<UserDTO>> DeleteFromRoleAsync(string userId, string role)
        {
            await _iUserUpdateService.Value.RemoveFromRoleAsync(userId, role);
            return Ok();
        }


        [HttpPut("Password")]
        public async Task<ActionResult<UserDTO>> UpdatePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            await _iUserUpdateService.Value.UpdatePasswordAsync(userId, currentPassword, newPassword);
            return Ok();
        }

    }
}

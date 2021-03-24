
using System;
using Microsoft.AspNetCore.Authorization;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PatientRecords.BLLayer.Extends.ExtendModelClasses;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using PatientRecords.BLLayer.Extends.ExtendServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.Web.WebBasics.HelperServices.Interfaces;
using PatientRecords.BLLayer.BLBasics.HelperClasses;
using PatientRecords.BLLayer.BLBasics.HelperServices;

namespace PatientRecords.Web.Controllers.DTOs
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserExtendController : ControllerBase
    {
        private readonly Lazy<IAuthService> _iAuthService;
        private readonly UserManager<User> _userManager;
        private readonly Lazy<IApiExceptionBuilder> _iApiExceptionBuildercs;
        private readonly IMapper _mapper;

        public UserExtendController(Lazy<IAuthService> iAuthService,
                              UserManager<User> userManager,
                              Lazy<IApiExceptionBuilder> iApiExceptionBuildercs,
                              IMapper mapper)
        {
            _iAuthService = iAuthService;
            _userManager = userManager;
            _iApiExceptionBuildercs = iApiExceptionBuildercs;
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
        public async Task<ActionResult<User>> PostSignUp(SignUpUserModel signUpUserModel)
        {


            User userDTO = this._mapper.Map<User>(signUpUserModel);
            await _userManager.CreateAsync(userDTO, signUpUserModel.Password);
            return Ok(new Response<User>(userDTO));
 

        }

        [HttpPut("EnableUser")]
        [Authorize]
        public async Task<ActionResult<User>> PutEnableUser([Required] string email)
        {


            User userDTO = await _userManager.FindByEmailAsync(email);
            await _userManager.SetLockoutEnabledAsync(userDTO, true);
            return Ok(new Response<User>(userDTO));



        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("api/Tokens")]
        public IActionResult TestAuthorization()
        {
            return Ok("You're Authorized");
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {

            throw new AppException("hhhhhhhhhh");
            List<User> userDTOs = await _userManager.Users.ToListAsync();
            return Ok(new Response<List<User>>(userDTOs));
 
        }

        [HttpPost("UserRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> PostUserRole([Required] string email, [Required] string role)
        {

            User userDTO = await _userManager.FindByEmailAsync(email);
            await _userManager.AddToRoleAsync(userDTO, role);
            return Ok(new Response<User>(userDTO));

        }

    }
}

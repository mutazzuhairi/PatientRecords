using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.BLLayer.QueryServices;
using PatientRecords.BLLayer.UpdateServices;
using PatientRecords.Web.WebBasics.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.Web.WebBasics.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PatientRecords.BLLayer.Extend.ExtendModelClasses;
using AutoMapper;
using PatientRecords.DataLayer.DataBasics.BasicService;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using PatientRecords.BLLayer.Extend.ExtendServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PatientRecords.DataLayer.Data.Entities;

namespace PatientRecords.Web.Controllers.DTOs
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Lazy<IAuthService> _iAuthService;
        private readonly UserManager<User> _userManager;
        private readonly Lazy<IApiExceptionBuildercs> _iApiExceptionBuildercs;
        private readonly Lazy<ITransactionFactory> _iTransactionFactory;
        private readonly IMapper _mapper;

        public UserController(Lazy<IAuthService> iAuthService,
                              UserManager<User> userManager,
                              Lazy<IApiExceptionBuildercs> iApiExceptionBuildercs,
                              Lazy<ITransactionFactory> transactionFactory,
                              IMapper mapper)
        {
            _iAuthService = iAuthService;
            _userManager = userManager;
            _iApiExceptionBuildercs = iApiExceptionBuildercs;
            _iTransactionFactory = transactionFactory;
            _mapper = mapper;
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserAuthModel userAuthModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        AuthResponseModel authResult = await _iAuthService.Value.Login(userAuthModel);
                        scope.Complete();
                        if (authResult == null)
                            return Unauthorized(new AuthResponseModel { ErrorMessage = "Invalid Authentication" });
                        return Ok(authResult);
                    }
                }

                catch (Exception ex)
                {
                    return BadRequest(_iApiExceptionBuildercs.Value.BuildException(ex));
                }
            }

            else
            {
                return BadRequest(_iApiExceptionBuildercs.Value.BuildModelException(ModelState));
            }

        }

        [HttpPost("SignUp")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> PostSignUp(SignUpUserModel signUpUserModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User userDTO = this._mapper.Map<User>(signUpUserModel);
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        await _userManager.CreateAsync(userDTO, signUpUserModel.Password);
                        scope.Complete();
                        return Ok(userDTO);
                    }
                }

                catch (Exception ex)
                {
                    return BadRequest(_iApiExceptionBuildercs.Value.BuildException(ex));
                }
            }

            else
            {
                return BadRequest(_iApiExceptionBuildercs.Value.BuildModelException(ModelState));
            }

        }

        [HttpPut("EnableUser")]
        [Authorize]
        public async Task<ActionResult<User>> PutEnableUser([Required] string email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        User userDTO = await _userManager.FindByEmailAsync(email);
                        await _userManager.SetLockoutEnabledAsync(userDTO, true);
                        scope.Complete();
                        return Ok(userDTO);
                    }
                }

                catch (Exception ex)
                {
                    return BadRequest(_iApiExceptionBuildercs.Value.BuildException(ex));
                }
            }

            else
            {
                return BadRequest(_iApiExceptionBuildercs.Value.BuildModelException(ModelState));
            }

        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("api/Tokens")]
        public IActionResult TestAuthorization()
        {
            return Ok("You're Authorized");
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        List<User> userDTOs = await _userManager.Users.ToListAsync();
                        scope.Complete();
                        return Ok(userDTOs);
                    }
                }

                catch (Exception ex)
                {
                    return BadRequest(_iApiExceptionBuildercs.Value.BuildException(ex));
                }
            }

            else
            {
                return BadRequest(_iApiExceptionBuildercs.Value.BuildModelException(ModelState));
            }

        }

        [HttpPost("UserRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> PostUserRole([Required] string email, [Required] string role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction())
                    {
                        User userDTO = await _userManager.FindByEmailAsync(email);
                        await _userManager.AddToRoleAsync(userDTO, role);
                        scope.Complete();
                        return Ok(userDTO);
                    }
                }

                catch (Exception ex)
                {
                    return BadRequest(_iApiExceptionBuildercs.Value.BuildException(ex));
                }
            }

            else
            {
                return BadRequest(_iApiExceptionBuildercs.Value.BuildModelException(ModelState));
            }

        }

    }
}

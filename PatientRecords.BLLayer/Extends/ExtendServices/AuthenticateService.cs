using Microsoft.AspNetCore.Identity;
using PatientRecords.BLLayer.Extends.ExtendServices.Interfaces;
using PatientRecords.BLLayer.Extends.ExtendModelClasses;
using PatientRecords.DataLayer.Data.Entities;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using PatientRecords.BLLayer.BLUtilities.SystemConstants;

namespace PatientRecords.BLLayer.Extends.ExtendServices
{
    public class AuthenticateService : IAuthService
    {
        private readonly Lazy<IUserQueryService> _iUserQueryService;
        private readonly IConfigurationSection _jwtSettings;
        private readonly IMapper _mapper;
        private readonly Lazy<IServiceBuildException> _serviceBuildException;

        public AuthenticateService(Lazy<IUserQueryService> iUserQueryService,
                                   Lazy<IServiceBuildException>  serviceBuildException,
                                   IConfiguration configuration,
                                   IMapper mapper)

        {
            _iUserQueryService = iUserQueryService;
            _jwtSettings = configuration.GetSection(SystemConstatnts.AppSettings.JwtSettings);
            _serviceBuildException = serviceBuildException;
            _mapper = mapper;
        }

        public async Task<AuthResponseModel> Login(UserAuthModel userAuthModel)
        {
            var user = await _iUserQueryService.Value.FindByEmailAsync(userAuthModel.Email);
            if (user == null || !await CheckUserPassword(user, userAuthModel.Password))
                return null;
            if (user.LockoutEnabled)
            {
                _serviceBuildException.Value.BuildException(SystemConstatnts.ValidationMessage.AccountLockout);
            }
            var loggedUser = this._mapper.Map<UserView>(user);
            var token = GenerateJwtToken(user.Id, user.UserName);
            return new AuthResponseModel { IsAuthSuccessful = true, Token = token, LoggedUser = loggedUser };

        }


        private string GenerateJwtToken(string userId, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.GetSection(SystemConstatnts.AppSettings.SecurityKey).Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, userName.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection(SystemConstatnts.AppSettings.ExpiryInMinutes).Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        private async Task<bool> CheckUserPassword(User user, string password)
        {
            return await _iUserQueryService.Value.CheckPasswordAsync(user, password);
        }
    }
}

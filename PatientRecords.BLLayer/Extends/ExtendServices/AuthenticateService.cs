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

namespace PatientRecords.BLLayer.Extends.ExtendServices
{
    public class AuthenticateService : IAuthService
    {
        private readonly Lazy<IUserQueryService> _iUserQueryService;
        private readonly IConfigurationSection _jwtSettings;
        private readonly IMapper _mapper;
        public AuthenticateService(Lazy<IUserQueryService> iUserQueryService,
                           IConfiguration configuration,
                           IMapper mapper)

        {
            _iUserQueryService = iUserQueryService;
            _jwtSettings = configuration.GetSection("JwtSettings");
            _mapper = mapper;

        }

        public async Task<AuthResponseModel> Login(UserAuthModel userAuthModel)
        {
            var user = await _iUserQueryService.Value.FindByEmailAsync(userAuthModel.Email);
            if (user == null || !await CheckUserPassword(user, userAuthModel.Password))
                return null;
            var loggedUser = this._mapper.Map<UserView>(user);
            var token = GenerateJwtToken(user.Id, user.UserName);
            return new AuthResponseModel { IsAuthSuccessful = true, Token = token, LoggedUser = loggedUser };

        }


        private string GenerateJwtToken(string userId, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, userName.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
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

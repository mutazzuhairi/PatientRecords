using Microsoft.AspNetCore.Identity;
using PatientRecords.BLLayer.Extend.ExtendServices.Interfaces;
using PatientRecords.BLLayer.Extend.ExtendModelClasses;
using PatientRecords.DataLayer.Data.Entities;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace PatientRecords.BLLayer.Extend.ExtendServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfigurationSection _jwtSettings;

        public AuthService(UserManager<User> userManager,IConfiguration configuration)

        {
            _userManager = userManager;
            _jwtSettings = configuration.GetSection("JwtSettings");

        }

        public async Task<AuthResponseModel> Login(UserAuthModel userAuthModel)
        {
            var user = await _userManager.FindByEmailAsync(userAuthModel.Email);
            if (user == null || !await CheckUserPassword(user, userAuthModel.Password))
                return null;
            var token = GenerateJwtToken(user.Id);
            return new AuthResponseModel { IsAuthSuccessful = true, Token = token };

        }


        private string GenerateJwtToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("CurrentUserId", userId.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        private async Task<bool> CheckUserPassword(User userDto , string password)
        {
            if (await _userManager.CheckPasswordAsync(userDto, password))
            {
                return true;
            }
            return false;
        }
    }
}

 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PatientRecords.BLLayer.BLUtilities.SystemConstants;
using System.Text;
 

namespace PatientRecords.Web.WebUtilities.Extensions
{
    public static class JwtSettingsConfigureExtensions
    {
        public static void SetJwtSettingsConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection(SystemConstatnts.AppSettings.JwtSettings);
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
 
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection(SystemConstatnts.AppSettings.SecurityKey).Value))
                };
            });


        }
    }
}

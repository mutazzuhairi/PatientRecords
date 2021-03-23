using Microsoft.Extensions.DependencyInjection;
using PatientRecords.BLLayer.Extend.ExtendServices.Interfaces;
using PatientRecords.BLLayer.Extend.ExtendServices;
using PatientRecords.BLLayer.BLBasics.BasicServices;
using PatientRecords.BLLayer.BLBasics.BasicServices.Interfaces;

namespace PatientRecords.BLLayer.BLBasics.InjectServices
{
    public static class CommonInjectServices
    {

        public static void AddCommonServiceToScoped(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IServiceBuildException, ServiceBuildException>();

        }
    }
}

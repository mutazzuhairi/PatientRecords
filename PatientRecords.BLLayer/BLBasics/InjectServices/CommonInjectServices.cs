using Microsoft.Extensions.DependencyInjection;
using PatientRecords.BLLayer.Extends.ExtendServices.Interfaces;
using PatientRecords.BLLayer.Extends.ExtendServices;
using PatientRecords.BLLayer.BLBasics.HelperServices;
using PatientRecords.BLLayer.BLBasics.HelperServices.Interfaces;

namespace PatientRecords.BLLayer.BLBasics.InjectServices
{
    public static class CommonInjectServices
    {

        public static void AddCommonServiceToScoped(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IServiceBuildException, ServiceBuildException>();
            services.AddScoped<IPaginationHelper,  PaginationHelper>();

        }
    }
}

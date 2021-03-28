using System;
using System.Data;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PatientRecords.BLLayer.Extends.ExtendServices.Interfaces;
using PatientRecords.BLLayer.Extends.ExtendServices;
using PatientRecords.BLLayer.BLUtilities.HelperServices;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
 
namespace PatientRecords.BLLayer.BLUtilities.Extensions
{
    public static class CommonExtensions
    {

        public static void AddCommonServiceToConfigure(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthenticateService>();
            services.AddScoped<IServiceBuildException, ServiceBuildException>();
            services.AddScoped<IPaginationHelper,  PaginationHelper>();
            services.AddScoped<ICommonServices,CommonServices>();

        }
         

    }
}

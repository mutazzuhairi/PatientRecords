
using Microsoft.Extensions.DependencyInjection;
using PatientRecords.Web.WebUtilities.HelperServices;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;

namespace PatientRecords.Web.WebUtilities.Extensions
{
    public static class BasicServicesExtensions
    {

        public static void AddBasicServicesToConfigure(this IServiceCollection services)
        {
            services.AddScoped<IApiExceptionBuilder, ApiExceptionBuilder>();
            services.AddScoped<ITransactionFactory,  TransactionFactory>();

        }
    }
}

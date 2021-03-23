
using Microsoft.Extensions.DependencyInjection;
using PatientRecords.Web.WebBasics.HelperServices;
using PatientRecords.Web.WebBasics.HelperServices.Interfaces;

namespace PatientRecords.Web.WebBasics.InjectServices
{
    public static class BasicServicesInjectServices
    {

        public static void AddBasicServicesToScoped(this IServiceCollection services)
        {
            services.AddScoped<IApiExceptionBuildercs, ApiExceptionBuilder>();
            services.AddScoped<ITransactionFactory,  TransactionFactory>();

        }
    }
}

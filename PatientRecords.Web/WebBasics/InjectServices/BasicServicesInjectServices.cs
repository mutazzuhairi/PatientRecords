
using Microsoft.Extensions.DependencyInjection;
using PatientRecords.Web.WebBasics.BasicServices;
using PatientRecords.Web.WebBasics.BasicServices.Interfaces;

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

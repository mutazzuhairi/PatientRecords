

using PatientRecords.BLLayer.Mapping;
using PatientRecords.BLLayer.QueryServices;
using PatientRecords.BLLayer.UpdateServices;
using PatientRecords.BLLayer.Validating;
using PatientRecords.DataLayer.Data.Repositries;
using Microsoft.Extensions.DependencyInjection;
using System;
using PatientRecords.Web.WebBasics.Interfaces;
using PatientRecords.Web.WebBasics;
using PatientRecords.DataLayer.DataBasics.BasicService;

namespace PatientRecords.Web.InjectServices
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

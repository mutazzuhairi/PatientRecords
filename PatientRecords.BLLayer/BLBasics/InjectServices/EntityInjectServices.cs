using PatientRecords.BLLayer.Mapping;
using PatientRecords.BLLayer.QueryServices;
using PatientRecords.BLLayer.UpdateServices;
using PatientRecords.BLLayer.Validating;
using PatientRecords.DataLayer.Data.Repositries;
using Microsoft.Extensions.DependencyInjection;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using PatientRecords.BLLayer.Mapping.Interfaces;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using PatientRecords.BLLayer.UpdateServices.Interfaces;
using PatientRecords.BLLayer.Validating.Interfaces;

namespace PatientRecords.BLLayer.BLBasics.InjectServices
{
    public static class EntityInjectServices
    {

        public static void AddEntityServicesToScoped(this IServiceCollection services)
        {
            AddPatientServicesToScoped(services);
            AddUserServicesToScoped(services);
            AddPatientRecordServicesToScoped(services);
 
        }
 

        private static void AddPatientServicesToScoped(IServiceCollection services)
        {
            services.AddScoped<IPatientRepositry, PatientRepositry>();
            services.AddScoped<IPatientValidating,PatientValidating>();
            services.AddScoped<IPatientMapping, PatientMapping>();
            services.AddScoped<IPatientQueryService,PatientQueryService>();
            services.AddScoped<IPatientUpdateService,PatientUpdateService>();

        }



        private static void AddPatientRecordServicesToScoped(IServiceCollection services)
        {
            services.AddScoped<IPatientRecordRepositry, PatientRecordRepositry>();
            services.AddScoped<IPatientRecordValidating, PatientRecordValidating>();
            services.AddScoped<IPatientRecordMapping, PatientRecordMapping>();
            services.AddScoped<IPatientRecordQueryService, PatientRecordQueryService>();
            services.AddScoped<IPatientRecordUpdateService, PatientRecordUpdateService>();

        }

        private static void AddUserServicesToScoped(IServiceCollection services)
        {
            services.AddScoped<IUserRepositry, UserRepositry>();
            services.AddScoped<IUserValidating, UserValidating>();
            services.AddScoped<IUserMapping, UserMapping>();
            services.AddScoped<IUserQueryService, UserQueryService>();
            services.AddScoped<IUserUpdateService, UserUpdateService>();

        }

    }
}

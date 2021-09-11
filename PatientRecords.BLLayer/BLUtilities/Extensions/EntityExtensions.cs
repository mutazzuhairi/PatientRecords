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

namespace PatientRecords.BLLayer.BLUtilities.Extensions
{
 
    public static class EntityExtensions
    {

        public static void AddEntityServicesToConfigure(this IServiceCollection services)
        {
            AddRepositriesToScope(services);
            AddMappingToScope(services);
            AddValidatingToScope(services);
            AddQueryServicesToScope(services);
            AddUpdateServicesToScope(services);
        }

        private static void AddRepositriesToScope(IServiceCollection services)
        {

           services.AddScoped<ImutazRepositry, mutazRepositry>();
           services.AddScoped<IPatientRepositry, PatientRepositry>();
           services.AddScoped<IPatientRecordRepositry, PatientRecordRepositry>();
           services.AddScoped<IRoleRepositry, RoleRepositry>();
           services.AddScoped<IUserRepositry, UserRepositry>();
       
        }

        private static void AddValidatingToScope(IServiceCollection services)
        {

           services.AddScoped<ImutazValidating, mutazValidating>();
           services.AddScoped<IPatientValidating, PatientValidating>();
           services.AddScoped<IPatientRecordValidating, PatientRecordValidating>();
           services.AddScoped<IRoleValidating, RoleValidating>();
           services.AddScoped<IUserValidating, UserValidating>();
       
        }

        private static void AddMappingToScope(IServiceCollection services)
        {

           services.AddScoped<ImutazMapping, mutazMapping>();
           services.AddScoped<IPatientMapping, PatientMapping>();
           services.AddScoped<IPatientRecordMapping, PatientRecordMapping>();
           services.AddScoped<IRoleMapping, RoleMapping>();
           services.AddScoped<IUserMapping, UserMapping>();
       
        }

        private static void AddUpdateServicesToScope(IServiceCollection services)
        {

           services.AddScoped<ImutazUpdateService, mutazUpdateService>();
           services.AddScoped<IPatientUpdateService, PatientUpdateService>();
           services.AddScoped<IPatientRecordUpdateService, PatientRecordUpdateService>();
           services.AddScoped<IRoleUpdateService, RoleUpdateService>();
           services.AddScoped<IUserUpdateService, UserUpdateService>();
       
        }

        private static void AddQueryServicesToScope(IServiceCollection services)
        {

           services.AddScoped<ImutazQueryService, mutazQueryService>();
           services.AddScoped<IPatientQueryService, PatientQueryService>();
           services.AddScoped<IPatientRecordQueryService, PatientRecordQueryService>();
           services.AddScoped<IRoleQueryService, RoleQueryService>();
           services.AddScoped<IUserQueryService, UserQueryService>();
       
        }
    }
}

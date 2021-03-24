using PatientRecords.BLLayer.BLUtilities.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientRecords.Web.WebUtilities.InjectServices;

namespace PatientRecords.Web
{
    public class Startup
    {
 
        public Startup(IConfiguration configuration)
        {
             Configuration = configuration;
        }
         
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContextToConfigure(Configuration);
            services.AddHttpContextAccessor();
            services.AddUriToConfigure();
            services.AddAutoMapperToConfigure();
            services.AddControllers();
            services.AddCors();
            services.AddIdentityToConfigure();
            services.SetJwtSettingsConfigure(Configuration);
            services.AddSwagger();
            services.AddBasicServicesToConfigure();
            services.AddEntityServicesToConfigure();
            services.AddCommonServiceToConfigure();
            services.AddLazierToConfigure();
 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerInterface();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCorsSecurity();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseErrorHandlerMiddleware();
            app.UseSystemEndpoints();
        }
 
    }
}

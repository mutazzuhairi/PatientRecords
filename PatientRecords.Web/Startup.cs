using PatientRecords.BLLayer.BLBasics.Configuration;
using PatientRecords.BLLayer.BLBasics.InjectServices;
using PatientRecords.DataLayer.DataBasics.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using PatientRecords.Web.InjectServices;
using Microsoft.AspNetCore.Identity;
using PatientRecords.DataLayer.Data.Entities;
 
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
            
            services.AddDbContext<MainContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PatientRecordConnectionString")));
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            services.AddControllers();
            services.AddCors();
            services.SetJwtSettingsConfigure(Configuration);
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "PatientRecord.Web", Version = "v1" }));
            services.AddBasicServicesToScoped();
            services.AddEntityServicesToScoped();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MainContext>();
            services.AddCommonServiceToScoped();
            services.AddScoped(typeof(Lazy<>), typeof(Lazier<>));
 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientRecord.Web v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
 

        }

        internal class Lazier<T> : Lazy<T> where T : class
        {
            public Lazier(IServiceProvider provider)
                : base(() => provider.GetRequiredService<T>())
            {
            }
        }
    }
}

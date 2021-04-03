using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PatientRecords.BLLayer.BLUtilities.Configuration;
using PatientRecords.BLLayer.BLUtilities.HelperServices;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.DataUtilities.DBContext;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using PatientRecords.Web.WebUtilities.Middlewares;
using PatientRecords.BLLayer.BLUtilities.SystemConstants;
using Microsoft.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PatientRecords.Web.WebUtilities.Extensions
{
    public static class CommonExtensions
    {
        public static void UseSystemEndpoints(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.MapWhen(x => x.Request.Path.Value.StartsWith("/api"), builder =>
            {
                app.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
                });
            });

            app.MapWhen(x => !x.Request.Path.Value.StartsWith("/api"), builder =>
            {
                app.Run(async (context) =>
                {
                    context.Response.ContentType = "text/html";
                    context.Response.Headers[HeaderNames.CacheControl] = "no-store, no-cache, must-revalidate";
                    await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
                });
            });
        }

        public static void AddUriToConfigure(this IServiceCollection services)
        {
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor?.HttpContext?.Request;
                var uri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent());
                return new UriService(uri);
            });

        }
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
        public static void UseCorsSecurity(this IApplicationBuilder app)
        {
            app.UseCors(x => x.AllowAnyOrigin().
                               AllowAnyMethod().
                               AllowAnyHeader());
        }
        public static void UseSwaggerInterface(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = SystemConstatnts.SwaggerProperites.SwaggerRouteTemplate;
            });
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(SystemConstatnts.SwaggerProperites.SwaggerRoute,
                                 SystemConstatnts.SwaggerProperites.SwaggesrName);
                c.RoutePrefix = SystemConstatnts.SwaggerProperites.SwaggerPath;
            });

        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => c.SwaggerDoc(SystemConstatnts.SwaggerProperites.SwaggerVersion, 
                                                           new OpenApiInfo { Title = SystemConstatnts.SwaggerProperites.SwaggerTitle,
                                                                             Version = SystemConstatnts.SwaggerProperites.SwaggerVersion
            }));
 
        }

        public static void AddLazierToConfigure(this IServiceCollection services)
        {
            services.AddScoped(typeof(Lazy<>), typeof(Lazier<>));
        }

        public static void AddDbContextToConfigure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<MainContext>(options => 
                   options.UseSqlServer(configuration.GetConnectionString(SystemConstatnts.ConnectionString.PatientRecord)));
        }

        public static void AddAutoMapperToConfigure(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
        }

        public static void  AddIdentityToConfigure(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MainContext>();
        }


        public static List<Dictionary<string, object>> ToJson(this DataTable dt)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in dt.Columns)
                {
                    if (row[col].ToString().StartsWith('{') || row[col].ToString().StartsWith('['))
                    {
                        dict[col.ColumnName] = JsonConvert.DeserializeObject(row[col].ToString());
                    }
                    else
                    {
                        dict[col.ColumnName] = row[col];
                    }
                }
                list.Add(dict);
            }

            return list;
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

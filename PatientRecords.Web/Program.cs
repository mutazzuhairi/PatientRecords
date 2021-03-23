using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace PatientRecords.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseEnvironment(Environment);
                });


        public static string Environment
        {
            get
            {
                string environmentName;
                #if DEBUG
                environmentName = "Development";
                #else
                environmentName = "Production";
                #endif
                return environmentName;
            }
        }
    }
}

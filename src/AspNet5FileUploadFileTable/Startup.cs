using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AspNet5FileUploadFileTable.Controllers;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace AspNet5FileUploadFileTable
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApplicationConfiguration>( Configuration.GetSection("ApplicationConfiguration"));

            var sqlConnectionString = Configuration["ApplicationConfiguration:SQLConnectionString"];

            services.AddDbContext<FileContext>(options =>
                options.UseSqlServer(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("AspNet5FileUploadFileTable")
                )
            );
            
            services.AddMvc();

            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<ValidateMimeMultipartContentFilter>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            app.UseMvc();
        }

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Exercise1
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllers()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.WriteIndented = true);

            services.AddDbContext<SortDb>(options => options.UseNpgsql(configuration.GetConnectionString(SortDb.ConnectionString)));

            services.AddTransient<IActionBusiness<List<Storage>>, ActionBusiness>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{id?}");
            });

        }
    }
}

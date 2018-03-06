using InventoryManagment.Data;
using InventoryManagment.Repository;
using InventoryManagment.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagment
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
            services.AddMvc();
            services.AddDbContext<InventoryDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("InventoryConnection")));
            services.AddScoped<IInventoryDatabase, InventoryDatabase>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IInventoryDatabase database)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            DbInitializer.Initialize(database);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

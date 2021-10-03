using bantruc_core.Demos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bantruc_core
{
    public class Startup
    {
        //private Demos.Demodulieus dm = new Demos.Demodulieus();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Hubs.ChatHub.Ketnoi();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // requires using Microsoft.Extensions.Options
            services.Configure<BantructoreDatabaseSettings>(
                Configuration.GetSection(nameof(BantructoreDatabaseSettings)));

            services.AddSingleton<IBantructoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BantructoreDatabaseSettings>>().Value);
            services.AddRazorPages();
            services.AddControllers();
            services.AddSignalR();
            services.AddSingleton<Services.BantrucService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<Hubs.ChatHub>("/chatHub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}

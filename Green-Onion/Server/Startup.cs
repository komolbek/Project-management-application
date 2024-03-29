﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GreenOnion.Server;
using Microsoft.EntityFrameworkCore;
using GreenOnion.Server.Services;
using GreenOnion.Server.DataLayer.DataAccess;

namespace Green_Onion.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();

            // custom data access classes DI
            services.AddTransient<UserAccountDataAccess>();
            services.AddTransient<UserDataAccess>();
            services.AddTransient<ProjectDataAccess>();
            services.AddTransient<CompanyDataAccess>();
            services.AddTransient<CompanyEmployeeDataAccess>(); 
            services.AddTransient<ProjectMemberDataAccess>();
            services.AddTransient<PredictionService>();
            services.AddTransient<TicketDataAccess>();
            services.AddTransient<TicketAssigneeDataAccess>();
            services.AddTransient<ReportService>();

            // DbContext DI
            services.AddDbContext<GreenOnionContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("GreenOnionContext")));

            // JSON serialise DI
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}

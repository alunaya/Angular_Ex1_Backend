using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Amazon.EC2;
using Angular_Ex1_Backend.Database.CodeFirst;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Angular_Ex1_Backend.Repository;
using Angular_Ex1_Backend.Business;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using System;

namespace Angular_Ex1_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AngularTest1DbContext>(
                options => options.UseMySql(Configuration.GetConnectionString("Dummy-Data"),
                    new MySqlServerVersion(new System.Version(5, 5, 68)),
                    mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)));

            //services.AddDbContext<AngularTest1DbContext>(options => options.UseSqlite(
            //    "Filename=TestDatabase.db", options =>
            //    {
            //        options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            //    }));

            services.AddScoped<AmazonEC2Client>();

            services.AddScoped<IMonthData, MonthData>();
            services.AddScoped<IServiceBillingData, ServiceBillingData>();
            services.AddScoped<IReservedCoverageData, ReservedCoverageData>();
            services.AddScoped<IMonthRepo, MonthRepo>();
            services.AddScoped<IServicesBillingRepo, ServicesBillingRepo>();
            services.AddScoped<IReservationCoverageRepo, ReservationCoverageRepo>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options=> {
                    options.Authority = "http://localhost:6000";

                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.FromMinutes(5)
                    };
                   
                });
            IdentityModelEventSource.ShowPII = true;

            services.AddHostedService<SeedData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "Frontend";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }

                
            //});

        }
    }
}

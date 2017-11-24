using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleachGameApi.SignalRStuff;
using CoreRepo.DataAccess.AccountAccess;
using CoreRepo.Database;
using CoreRepo.IDataAccess.IAccountAccess;
using CoreServices;
using CoreServices.AccountServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BleachGameApi
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
            services.AddDbContext<CoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NotrsOnPremConnection")));

            #region DataAccess

            #region AccountAccess
            services.AddScoped<ISessionAccess, SessionAccess>();
            services.AddScoped<IUserAccess, UserAccess>();
            #endregion


            #endregion

            #region Services

            #region AccountServices

            services.AddScoped<AccountSerurityService>();
            #endregion


            #endregion

            services.AddSignalR();

            services.AddMvc();

            services.AddCors(o => o.AddPolicy("localHost3000", builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
            services.AddCors(o => o.AddPolicy("localHost4200", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            app.UseCors("localHost3000");
            app.UseCors("localHost4200");

            app.UseSignalR(routes =>
            {
                routes.MapHub<Chat>("chat");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            Email.SendEmail("jawetzel615@gmail.com", "this working?", "checking to see if this is working");
        }
    }
}

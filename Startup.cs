using LMS_App.Interface;
using LMS_App.Models;
using LMS_App.Repository;
using LMS_App.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_App
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
            services.Configure<LMS_AppConfig>(Configuration.GetSection("LMS_AppConfig"));
            //services.AddDbContext<LMS_DbContext>(o =>
            //{
            //    o.UseSqlServer(Configuration["ConnectionStrings:DatabaseConnection"]);
            //});

            services.AddScoped<IUserInfo, UserService>();
            services.AddScoped<ICourseInfo, CourseService>();
            services.AddScoped<ISqlDataRepository, SqlDataRepository>();
            services.AddSwaggerGen();
            //services.AddControllers();

            //services.Configure<TweetAppConfig>(Configuration.GetSection("TweetAppConfig"));
            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
            });

            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
                .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));
            services.AddControllers();
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = Configuration["CacheConnection"];
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
          
            //});
            app.UseCors("CorsPolicy");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LMS App Service");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseMetricServer();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

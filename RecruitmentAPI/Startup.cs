using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Recruitment.Domain.Repository;
using Recruitment.Domain.Services;
using RecruitmentAPI.Mappers;
using Swashbuckle.AspNetCore.Swagger;

namespace RecruitmentAPI
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var connString = GetConnection();
            services.AddDbContext<RecruitmentContext>(x => x.UseSqlServer(connString,
               y => y.CommandTimeout(600)));

            services.AddCors();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Recruitment",
                    Description = "ASP.NET Core 2.0 Web API",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Euromonitor International",
                        Email = "support@euromonitor.com",
                        Url = "https://www.euromonitor.com"
                    }
                });
            });
            services.AddScoped<IService, Service>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICandidateMapper, CandidateMapper>();
        }

        private string GetConnection ()
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");
            Configuration = config.Build();
            return Configuration.GetSection("ConnectionString:RecruitmentDB").Value;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors(builder =>
                builder.WithOrigins().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            //app.UseCors(x => x
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recruitment");
            });
        }
    }
}

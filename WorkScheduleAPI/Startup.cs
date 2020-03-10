using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkScheduleAPI.Database;
using Microsoft.EntityFrameworkCore;
using WorkScheduleAPI.Repositories;
using WorkScheduleAPI.Entities;
using AutoMapper;
using WorkScheduleAPI.Mappers;

namespace WorkScheduleAPI
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

            
            services.AddDbContext<StudContext>(op => op.UseSqlServer(Configuration["ConnectionString:StudDB"]));

            services.AddScoped<IJobItemRepository<JobItem>, JobItemRepository>();
            

            services.AddAutoMapper(c => c.AddProfile<WorkScheduleMapping>(), typeof(Startup));
            services.AddScoped<IWorkScheduleItemRepository<WorkScheduleItem>, WorkScheduleItemRepository>();
            services.AddScoped<IJobScheduleRepository<JobSchedule>, JobScheduleRepository>();
            services.AddScoped<IDepartmentRepository<Department>, DepartmentRepository>();

            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}

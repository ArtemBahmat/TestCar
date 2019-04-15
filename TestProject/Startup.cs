using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using TestProject.Data;
using TestProject.Data.Entities;
using TestProject.Middleware;
using TestProject.Repositories;
using TestProject.Services;

namespace TestProject
{
    public partial class Startup
    {
        private readonly string corsPolicy = "corsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            RegisterAutoMapperConfig();
            RegisterServices(services);

            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin();
                    });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Cars.API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                var swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "LIS.API");

            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(corsPolicy);
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc();
            //InitializeInMemoryDatabase(app);
        }

        private static void InitializeInMemoryDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CarDbContext>();
                context.Areas.Add(new AreaEntity { Id = 1, Name = "area", DateCreated = DateTime.Now });
                context.Garages.Add(new GarageEntity { Id = 1, Name = "garage", DateCreated = DateTime.Now, AreaId = 1 });
                context.CarCategories.Add(new CarCategoryEntity
                { Id = 1, Name = "category", DateCreated = DateTime.Now });
                context.Cars.Add(new CarEntity
                {
                    Id = 1000,
                    Description = "carDescription",
                    Title = "title",
                    DateCreated = DateTime.Now,
                    CategoryId = 1,
                    GarageId = 1
                });
                context.SaveChanges();
            }
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<CarDbContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("appDbConnection"), b => b.MigrationsAssembly("TestProject")));
            //services.AddDbContext<CarDbContext>(c => c.UseInMemoryDatabase("car"));

            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IGarageRepository, GarageRepository>();
            services.AddTransient<ICarCategoryRepository, CarCategoryRepository>();
            services.AddTransient<IAreaRepository, AreaRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IGarageService, GarageService>();
            services.AddTransient<IReportService, ReportService>();
        }
    }
}

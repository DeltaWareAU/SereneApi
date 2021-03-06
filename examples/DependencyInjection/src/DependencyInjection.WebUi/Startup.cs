using DependencyInjection.API;
using DependencyInjection.WebUi.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SereneApi.Extensions.DependencyInjection;
using SereneApi.Extensions.Newtonsoft;

namespace DependencyInjection.WebUi
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
            services.AddControllers().AddNewtonsoftJson();

            services.ConfigureSereneApi(r =>
            {
                r.ResourcePath = "api/v2";
            }).AddNewtonsoft();

            // Add an ApiHandler to the services collection, this enables dependency injection.
            // You are required to supply an interface for the definition and a class inheriting form ApiHandler and the interface as the definition.
            services.RegisterApi<IStudentApi, StudentApiHandler>(builder =>
            {
                // Under appsettings.conf, there is an array called ApiConfig.
                // Inside that array is another array called "Student" as you can see below we are getting that.
                builder.AddConfiguration(Configuration.GetApiConfig("Student"));
            });

            // Here a provider is also being used, this allows you to get services that have been registered with dependency injection
            services.RegisterApi<IClassApi, ClassApiHandler>((builder, provider) =>
            {
                // Instead of using appsettings. You can also manually specify the source information.
                builder.SetSource("http://localhost:52279", "Class");
            });

            services.RegisterApi<IValuesApi, ValuesApiHandler>((builder, p) =>
            {
                builder.SetSource("http://localhost:52279", "Values");
            });

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebUi", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1/swagger.json", "WebUi"); });

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
        }
    }
}

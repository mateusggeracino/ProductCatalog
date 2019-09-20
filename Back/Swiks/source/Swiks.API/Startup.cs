using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwaggerLib.Services;
using Swiks.API.AutoMapper;
using Swiks.Domain.Interfaces.Repository;
using Swiks.Domain.Interfaces.Services;
using Swiks.Domain.Services;
using Swiks.Repository.Repository;

namespace Swiks.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.ConfigureServicesSwagger(false);

            services.AddSingleton(AutoMapperConfig.Register().CreateMapper());
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.ConfigureAppSwagger();
        }
    }
}

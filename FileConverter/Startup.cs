using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileConverter.CloudProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FileConverter.BlobReader;
using Serilog;

namespace FileConverter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //Configuration = configuration;
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IBlobReader, BlobReader.BlobReader>(); parameter less constructor invocation
            services.AddSingleton<IBlobReader>(x => new BlobReader.BlobReader(Configuration["BlobConnectionString"],
                Configuration["ContainerName"],
                Configuration["FileName"])); //parametrised constructor
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerFactory.AddSerilog();
            app.UseMvc();
        }
    }
}

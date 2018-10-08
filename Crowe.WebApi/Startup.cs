using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crowe.Core.Interfaces;
using Crowe.Data;
using Crowe.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Crowe.WebApi
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
            services.AddMvc();
            services.AddTransient<IMessageService, MessageService>();
            AddTransientDataSource(services);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                    });
            }
            );
        }

        private void AddTransientDataSource(IServiceCollection services)
        {
            var cs = Configuration.GetConnectionString("DefaultConnection");
            // TODO ES: connect to DB
            var isConnectedToDb = IsConnectedToDb(cs);
            if (!isConnectedToDb)
                services.AddTransient<IMessageRepository, MessageRepository>();
            else
                services.AddTransient<IMessageRepository, DbMessageRepository>();
        }

        private bool IsConnectedToDb(string cs)
        {
            return false;
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

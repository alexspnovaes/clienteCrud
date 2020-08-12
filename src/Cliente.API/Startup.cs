using Cliente.Domain.Commands;
using Cliente.Domain.Infra.Contexts;
using Cliente.Domain.Infra.Repositories;
using Cliente.Domain.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Cliente.API
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
            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddMvc()
                .AddFluentValidation(); 
            services.AddCors();
            services.AddDbContext<ClienteDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ClienteDataBase")));

            services.AddTransient<IClientRepository, ClienteRepository>();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(NewClienteCommand).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cliente V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
                var dbContextAccount = serviceScope.ServiceProvider.GetRequiredService<ClienteDataContext>();
                dbContextAccount.Database.Migrate();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

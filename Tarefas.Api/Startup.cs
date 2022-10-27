using Microsoft.OpenApi.Models;
using System.Runtime;

namespace Tarefas.Api
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Tarefas", Version = "v1", 
                    Description = "API para controlar fluxo de tarefas de uma pequena equipe.",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Noronha",
                        Email = "lucasnoronha1610@hotmail.com",
                        Url = new Uri("https://github.com/lucas-noronha"),
                    }

                });
            });
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
            
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.Run();
        }
    }
}

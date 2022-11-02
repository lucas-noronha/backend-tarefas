﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Runtime;
using System.Text;
using Tarefas.Data;
using Tarefas.Data.Repositorios;
using Tarefas.Domain.Interfaces.Repositorios;
using Tarefas.Domain.Servicos;
using static System.Net.Mime.MediaTypeNames;

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


            var conStr = configRoot.GetConnectionString("Tarefas");
            services.AddDbContext<TarefasDb>(options =>
            {
                var builder = options.UseNpgsql(conStr);
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
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
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = @$"JWT Authorization header using the Bearer scheme. 
                {Environment.NewLine}Enter 'Bearer'[space] and then your token in the text input below.
                {Environment.NewLine}Example: " + "\"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });

            
            services.AddTransient<IChamadoRepositorio, ChamadoRepositorio>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<ChamadoServico>();
            services.AddTransient<ClienteServico>();
            services.AddTransient<UsuarioServico>();


            var configChave = configRoot["Jwt:Key"];
            var issuer = configRoot["Jwt:Issuer"];
            var audience = configRoot["Jwt:Audience"];
            var chaveBytes = Encoding.ASCII.GetBytes(configChave);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Bearer", x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(chaveBytes),
                     ClockSkew = TimeSpan.FromMinutes(5),
                     ValidIssuer = issuer,
                     ValidAudience = audience

                 };
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(x => x.MapControllers().RequireAuthorization());
            app.Run();
        }
    }
}

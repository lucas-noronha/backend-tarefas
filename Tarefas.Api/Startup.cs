using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tarefas.Data;
using Tarefas.Data.Repositorios;
using Tarefas.Domain.Dtos;
using Tarefas.Domain.Entidades;
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
        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = "";
                var fileName = typeof(UsuarioDto).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }




        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            });

            services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            var conStr = configRoot.GetConnectionString("Tarefas");
            services.AddDbContext<TarefasDb>(options =>
            {
                var builder = options.UseNpgsql(conStr);
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


            #region SwaggerConfigucao
            var contentRoot = configRoot.GetValue<string>(WebHostDefaults.ContentRootKey);
            var strings = contentRoot.Split(@"\");
            var stringsPathBase = strings.Take(strings.Count() - 2);
            var path = string.Join(@"\", stringsPathBase);
            path = @"/app/TarefasDocumentacao.xml";

            services.AddSwaggerGen(c =>
            {
                //c.IncludeXmlComments(path);
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
            #endregion

            #region ImplementacaoJwt
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
            #endregion

            #region AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioDto>()
                .ForMember(x => x.Senha, y => y.Ignore());
                cfg.CreateMap<Cliente, ClienteDto>();
                cfg.CreateMap<HistoricoChamado, HistoricoChamadoDto>();
                cfg.CreateMap<TempoGasto, TempoGastoDto>();
                cfg.CreateMap<Chamado, ChamadoDto>();
            });
            IMapper mapper = config.CreateMapper();
            #endregion

            #region InjecaoDependencias
            services.AddTransient<IChamadoRepositorio, ChamadoRepositorio>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<ChamadoServico>();
            services.AddTransient<ClienteServico>();
            services.AddTransient<UsuarioServico>();
            services.AddSingleton(mapper);
            #endregion


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

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(x => x.MapControllers().RequireAuthorization());
            app.Run();
        }
    }
}

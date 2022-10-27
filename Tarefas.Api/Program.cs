using Tarefas.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method
var app = builder.Build();
startup.Configure(app, builder.Environment); // calling Configure method
using APICatalogo.Context;
using APICatalogo.Extensions;
using APICatalogo.Filters;
using APICatalogo.Logging;
using APICatalogo.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(op => 
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //ignora quando ocorrer um refer�ncia ciclica da serealiza��o do json

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//registrar o servi�o
builder.Services.AddScoped<IMeuServico, MeuServico>();

builder.Services.AddScoped<ApiloggingFilter>();

//inclus�o do servi�o do contexto
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection"); //obter string de conex�o

builder.Services.AddDbContext<AppDbContext>(op => op.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
})); //parte do loggin customozado

var app = builder.Build(); //Equivalente ao Configure

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//middleware de tratamento de error
app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

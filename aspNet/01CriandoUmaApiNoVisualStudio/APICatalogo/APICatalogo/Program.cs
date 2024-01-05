using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(op => 
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //ignora quando ocorrer um refer�ncia ciclica da serealiza��o do json

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inclus�o do servi�o do contexto
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection"); //obter string de conex�o

builder.Services.AddDbContext<AppDbContext>(op => op.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

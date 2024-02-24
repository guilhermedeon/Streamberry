using Microsoft.EntityFrameworkCore;
using Streamberry.Application;
using Streamberry.Infra.Data;
using Streamberry.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add Streamberry Classes
builder.Services.AddApplicationLayer();
builder.Services.AddInterfaces();
builder.Services.AddInfraData();

//Add and Setup WebAPI specific Classes
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
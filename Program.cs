

using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Yummmy.Api.Context;
using Yummmy.Api.Entities;
using Yummmy.Api.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
    });



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddCors();


var connectionString = builder.Configuration.GetConnectionString("PostgreSql");

builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
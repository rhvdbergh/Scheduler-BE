using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api;
using Scheduler.Core.Base;
using Scheduler.Core.Models;
using Scheduler.Infra.Sql.Base;
using Scheduler.Infra.Sql.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

// Configure SQL database.

var dbSettings = builder.Configuration.GetSection("Db");

var connectionString = dbSettings["ConnectionString"];
var majorSqlVersion = int.Parse(dbSettings["Version:Major"]);
var minorSqlVersion = int.Parse(dbSettings["Version:Minor"]);
var serverVersion = new MySqlServerVersion(new Version(majorSqlVersion, minorSqlVersion));

// Add services to the container.

builder.Services.AddDbContext<SchedulerDbContext>(
    dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

builder.Services.AddTransient<IProfessorRepository, ProfessorRepository>();

builder.Services.AddMediatR(typeof(Professor));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

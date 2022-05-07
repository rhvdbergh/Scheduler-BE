using Microsoft.EntityFrameworkCore;
using Scheduler.Infra.Sql.Base;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "server=localhost,3306;user=root;password=secret;database=scheduler";
var serverVersion = new MySqlServerVersion(new Version(5, 7));

// Add services to the container.

builder.Services.AddDbContext<SchedulerDbContext>(
    dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

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

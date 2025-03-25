using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using RubiusTestTask.Application.MappingProfiles;
using RubiusTestTask.Application.Services;
using RubiusTestTask.DataAccess.Data;
using RubiusTestTask.DataAccess.Repositories;
using RubiusTestTask.Domain.Interfaces;
using RubiusTestTask.Web.Middleware;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Initializing application");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMusicRepository, MusicRepository>();
builder.Services.AddScoped<IMusicService, MusicService>();
builder.Services.AddDbContext<MusicDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MusicDbContext))));

var app = builder.Build();
logger.Info("Starting the app");

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});
app.Run();
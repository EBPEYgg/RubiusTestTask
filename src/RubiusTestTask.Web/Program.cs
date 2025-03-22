using Microsoft.EntityFrameworkCore;
using RubiusTestTask.Application.Services;
using RubiusTestTask.DataAccess.Data;
using RubiusTestTask.DataAccess.Repositories;
using RubiusTestTask.Domain.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMusicRepository, MusicRepository>();
builder.Services.AddScoped<IMusicService, MusicService>();
builder.Services.AddDbContext<MusicDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MusicDbContext))));

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
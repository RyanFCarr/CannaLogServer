using Server;
using Server.Contexts;
using Server.Models;
using Server.Repositories;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<CannaLogContext>();

// Add Services and Repos
builder.Services.AddScoped<IPlantService, PlantService>();
builder.Services.AddScoped<IPlantRepository, PlantRepository>();
builder.Services.AddScoped<IGrowLogService, GrowLogService>();
builder.Services.AddScoped<IGrowLogRepository, GrowLogRepository>();
builder.Services.AddScoped<IAdditiveService, AdditiveService>();
builder.Services.AddScoped<IAdditiveRepository, AdditiveRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Automapper config
builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<AutoMapperProfile>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddDbContextCheck<CannaLogContext>();

// CORS
var allowedOriginsPolicy = "allowedOriginsPolicy";
var corsOrigin = Environment.GetEnvironmentVariable("CORS_ORIGIN");
if (!string.IsNullOrEmpty(corsOrigin))
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: allowedOriginsPolicy,
                          policy =>
                          {
                              policy.WithOrigins(corsOrigin)
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                          });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowedOriginsPolicy);
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app
    .MigrateDatabase<CannaLogContext>()
    .Run();

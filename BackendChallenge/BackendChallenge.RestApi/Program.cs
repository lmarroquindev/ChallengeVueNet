using BackendChallenge.Core.Interfaces.Repositories;
using BackendChallenge.Core.Interfaces.Services;
using BackendChallenge.Data;
using BackendChallenge.Data.Repositories;
using BackendChallenge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ChallengeVueNetContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
   options.EnableSensitiveDataLogging();
}, ServiceLifetime.Scoped);


//automapper inyected
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Repositories
builder.Services.AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();
builder.Services.AddTransient<IPermissionRepository, PermissionRepository>();

//Services
builder.Services.AddTransient<IPermissionTypeService, PermissionTypeService>();
builder.Services.AddTransient<IPermissionService, PermissionService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
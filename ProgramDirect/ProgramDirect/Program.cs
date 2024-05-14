using ProgramDirect.Application.Implementations;
using ProgramDirect.Application.Interfaces;
using ProgramDirect.Application;
using ProgramDirect.Infrastruture.Data;
using ProgramDirect.Infrastruture.Implementations;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddDbContext
builder.Services.AddDbContext<ProgramDirectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Automapper
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

// Add Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IProgramService, ProgramService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

using CuentasApi.Data;
using CuentasApi.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
  options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);

// My services
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
  opts.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
  opts.EnableSensitiveDataLogging();
});

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

/* app.UseHttpsRedirection(); */

app.UseCors();

app.MapGroup("/users").MapUserEnpoints();
app.MapGroup("/accounts/{userId:int}").MapAccountEnpoints();

app.Run();

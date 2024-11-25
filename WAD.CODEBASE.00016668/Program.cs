using Microsoft.EntityFrameworkCore;
using WAD.CODEBASE._00016668.Data;
using WAD.CODEBASE._00016668.Models;
using WAD.CODEBASE._00016668.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// registering dependency injection --> line added
builder.Services.AddDbContext<ContactDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SQLConnection")));  


builder.Services.AddScoped<IRepository<Contacts>, ContactRepository>();
builder.Services.AddScoped<IRepository<Groups>, GroupRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseExceptionHandler("/error");

app.MapControllers();

app.Run();

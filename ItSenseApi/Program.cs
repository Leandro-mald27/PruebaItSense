using BLL.Service;
using BLL.Service.Implements;
using DAL.Context;
using DAL.Repository;
using DAL.Repository.Implements;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repository
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
//Services
builder.Services.AddScoped<IProductoService, ProductoService>();

//BdConection 
var conexion = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbContextApi>(
    options =>
    {
        options.UseSqlServer(conexion);
    });

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

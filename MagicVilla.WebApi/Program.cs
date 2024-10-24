using MagicVilla.DatabaseConfig.Data;
using MagicVilla.RepositoryConfig.IRepositories;
using MagicVilla.RepositoryConfig.Repositories;
using MagicVilla.WebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Db context
builder.Services.AddDbContext<MagicVillaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb")));
//Mapping config
builder.Services.AddAutoMapper(typeof(MappingConfig));

//Add IUnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

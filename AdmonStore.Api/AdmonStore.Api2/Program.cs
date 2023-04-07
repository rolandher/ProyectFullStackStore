using AdmonStore.Api2.AutoMapper;
using AdmonStore.Domain2.Gateway;
using AdmonStore.Domain2.Gateway.Repositories;
using AdmonStore.Domain2.UseCases;
using AdmonStore.Infrastructure2.Gateway;
using AdmonStore.Infrastructure2.SqlAdapter;
using AutoMapper.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));

builder.Services.AddScoped<IStoreUseCase, StoreUseCase>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();

builder.Services.AddScoped<ILocationUseCase, LocationUseCase>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

builder.Services.AddScoped<IProductUseCase, ProductUseCase>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddTransient<IDbConnectionBuilder>(e =>
{
    return new DbConnectionBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
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

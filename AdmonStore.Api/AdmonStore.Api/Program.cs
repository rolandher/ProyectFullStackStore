using AdmonStore.Api.AutoMapper;
using AdmonStore.Domain.Gateway;
using AdmonStore.Domain.Gateway.Repositories;
using AdmonStore.Domain.UseCases;
using AdmonStore.Infrastructure;
using AdmonStore.Infrastructure.Interfaces;
using AdmonStore.Infrastructure.Repositories;
using AutoMapper.Data;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));

builder.Services.AddScoped<IUserUseCase, UserUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSingleton<IContext>(provider => new Context(builder.Configuration.GetConnectionString("urlConnection"), "test"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



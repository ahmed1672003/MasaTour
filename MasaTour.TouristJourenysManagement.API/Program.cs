using MasaTour.TouristJourenysManagement.Application;
using MasaTour.TouristJourenysManagement.Domain;
using MasaTour.TouristJourenysManagement.Infrastructure;
using MasaTour.TouristJourenysManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Register Services
builder.Services
       .AddApplicationDependencies()
       .AddServicesDependencies()
       .AddInfrastructureDependencies(builder.Configuration)
       .AddDomainDependencies();
#endregion

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

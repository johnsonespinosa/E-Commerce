using System.Reflection;
using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Server;
using Server.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Comercio Electrónico WEB API", Version = "v1" });
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddKeycloakService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Comercio Electrónico API V1");
        options.RoutePrefix = string.Empty; // Para acceder a Swagger en la raíz
    });
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
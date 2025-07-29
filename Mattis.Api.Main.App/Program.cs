using Mattis.Api.Main.Business;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Mattis.Api.Main.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// START Add configuration
builder.Services.AddSwaggerGen(delegate (SwaggerGenOptions c)
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Main",
        Version = "v1",
        Description = ""
    });
});
builder.Services.AddApiMainDbContext(builder.Configuration);
builder.Services.RegisterMainDbContainer();
builder.Services.AddAutoMapper(typeof(ApiMainProfile));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ApiMainProfile).Assembly));


// END Add configuration

var app = builder.Build();










// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// START Add configuration
app.UseSwagger();
app.UseSwaggerUI(delegate (SwaggerUIOptions c)
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Main" + " V1");
    c.RoutePrefix = "swagger";
});


// END Add configuration

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

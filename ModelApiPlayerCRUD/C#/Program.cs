using FluentValidation;
using FluentValidation.AspNetCore;
using Mattis.Api.Scrabble.Business;
using Mattis.Api.Scrabble.Db;
using Mattis.Api.Scrabble.Db.DbContexts;
using Mattis.Core.WebApi;
using Mattis.Core.WebApi.Validation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Configuration.AddUserSecrets<Program>();
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


builder.Services.AddSwaggerGen(delegate (SwaggerGenOptions c)
{
    //c.SwaggerDoc("v1", new OpenApiInfo
    //{
    //    Title = "Api Main",
    //    Version = "v2",
    //    Description = ""
    //});
});
builder.Services.AddApiScrabbleDbContext(builder.Configuration);
builder.Services.AddDbContext<ApiScrabbleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MattisScrabbleDb")));
builder.Services.RegisterScrabbleDbContainer();
builder.Services.AddAutoMapper(typeof(ApiScrabbleProfile));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ApiScrabbleProfile).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(ApiScrabbleProfile).Assembly);
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));

// END Add configuration


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    
});


var app = builder.Build();


app.UseExceptionHandler(ExceptionMiddleware.Configure);



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

app.UseCors("AllowAllOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();

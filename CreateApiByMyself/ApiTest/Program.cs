using ApiTest.Business;
using ApiTest.Db;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactDevClient", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddSwaggerGen(delegate (SwaggerGenOptions c)
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Test",
        Version = "v1"
    });
    c.AddServer(new OpenApiServer
    {
        Url = "https://localhost:7014",

        //https://localhost:7014/swagger/v1/swagger.json
        Description = "Local dev server"
    });
});
builder.Services.AddApiTestDbContext(builder.Configuration);
builder.Services.RegisterApiTestDbContainer();
builder.Services.AddAutoMapper(typeof(ApiTestProfile).Assembly);
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ApiTestProfile).Assembly));


var app = builder.Build();


app.UseCors("AllowReactDevClient");


// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI(delegate (SwaggerUIOptions c) {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Test v1");
    c.RoutePrefix = "swagger";
})
;
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
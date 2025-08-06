using System.Text.Json.Serialization;
using NexCart.Users.Infrastructure;
using NexCart.Users.Mappers;
using NexCart.UsersApi.Middlewares;
using NextCart.Users.Helpers;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure Services
builder.Services.AddInfrastructure();
builder.Services.AddCore();


//Add Controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{ 
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());  
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();

//Add Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "eCommerce.API", Version = "v1" });
});

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(_=>_.SwaggerEndpoint("/swagger/v1/swagger.json","Yumigo"));
}

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

using NexCart.UsersApi.Middlewares;
using NextCart.Users.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDAInfrastructure();
builder.Services.AddBLInfrastructure();

builder.Services.AddControllers();
var app = builder.Build();


app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

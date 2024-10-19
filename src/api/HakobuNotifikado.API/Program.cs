using HakobuNotifikado.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiLib();

var app = builder.Build();
app.UseAppLib();
app.Run();

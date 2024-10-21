using HakobuNotifikado.Application.Extensions;
using HakobuNotifikado.Infrastructure.Extensions;
using HakobuNotifikado.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddWebApiLib()
    .AddApplicationLib()
    .AddInfrastructureLib();

var app = builder.Build();
app.UseAppLib();
app.Run();

namespace HakobuNotifikado.WebApi.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseAppLib(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.UseHttpsRedirection();
        app.MapControllers();

        return app;
    }
}
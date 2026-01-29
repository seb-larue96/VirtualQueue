using Scalar.AspNetCore;

namespace VirtualQueue.Api.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication ConfigureApplication(this WebApplication app)
        {
            #region OpenApi
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }
            #endregion

            #region
            app.UseHttpsRedirection();
            #endregion

            #region Cors
            app.UseCors();
            #endregion

            return app;
        }
    }
}

using VirtualQueue.Application.Extensions;
using VirtualQueue.Infrastructure.Extensions;

namespace VirtualQueue.Api.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder ConfigureApplicationBuilder(this WebApplicationBuilder builder)
        {
            #region OpenApi
            builder.Services.AddOpenApi();
            #endregion

            #region Project Dependencies
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();
            #endregion

            #region Cors
            builder.Services.AddCors(options =>
            {
                var allowedOrigins = builder.Configuration.GetValue<string>("CORSPolicy:AllowedOrigin");

                options.AddDefaultPolicy(x =>
                {
                    x.WithOrigins(allowedOrigins);
                    x.AllowAnyMethod();
                    x.AllowAnyHeader();
                    x.AllowCredentials();
                });
            });
            #endregion

            return builder;
        }
    }
}

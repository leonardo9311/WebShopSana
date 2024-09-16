using Microsoft.Extensions.DependencyInjection;


namespace WebShop.Infraestructure.Config
{
    public static class CorsConfig
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173") // Add the origin you want to allow
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });
            return services;
        }
    }
}

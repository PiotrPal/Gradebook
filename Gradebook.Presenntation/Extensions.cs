using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// bez NuGet Microsoft.AspNetCore.Hosting

namespace Gradebook.Presenntation {
    public static class Extensions {
        public static IServiceCollection AddPresentation(this IServiceCollection services) {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(swagger => { swagger.EnableAnnotations(); });
            
            services.AddControllers();

            return services;
        }
        public static IApplicationBuilder UsePresentation(this WebApplication app) {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.MapControllers();
            
            return app;
        }
    }
}

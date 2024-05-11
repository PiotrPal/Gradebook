using Gradebook.Domain.Abstractions;
using Gradebook.Infrastructure.Context;
using Gradebook.Infrastructure.Repositoires;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gradebook.Infrastructure {
    public static class Extensions {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddDbContext<GradebookDbContext>(ctx => ctx.UseSqlServer(configuration.GetConnectionString("GradebookCS")));

            return services;
        }
    }
}

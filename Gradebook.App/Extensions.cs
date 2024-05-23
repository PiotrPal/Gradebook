using Gradebook.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Gradebook.App {
    public static class Extensions {
        public static IServiceCollection AddAplication(this IServiceCollection services) {
            var executingAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(executingAssembly);
            services.AddAutoMapper(executingAssembly);
            return services;
        }
    }
}

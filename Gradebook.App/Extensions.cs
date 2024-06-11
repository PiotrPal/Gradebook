using FluentValidation;
using Gradebook.App.Commands.Students.AddStudent;
using Gradebook.App.Commands.Students.UpdateStudent;
using Gradebook.App.Middlewares;
using Gradebook.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Gradebook.App {
    public static class Extensions {
        public static IServiceCollection AddAplication(this IServiceCollection services) {
            var executingAssembly = Assembly.GetExecutingAssembly();
            //services.AddMediatR(executingAssembly); stara wersja
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(executingAssembly);

            services.AddScoped<IValidator<AddStudentCommand>, AddStudentCommandValidation>();
            services.AddScoped<IValidator<UpdateStudentCommand>, UpdateStudentCommandValidation>();

            services.AddTransient<ExceptionHandlingMiddleware>();
            return services;
        }
        public static IApplicationBuilder UseApplication(this WebApplication app) {
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }
    }
}

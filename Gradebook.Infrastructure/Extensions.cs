﻿using Gradebook.Domain.Abstractions;
using Gradebook.Infrastructure.Context;
using Gradebook.Infrastructure.Repositoires;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Web;

namespace Gradebook.Infrastructure {
    public static class Extensions {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentReadOnlyRepository, StudentReadOnlyRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddDbContext<GradebookDbContext>(ctx => ctx.UseSqlServer(configuration.GetConnectionString("GradebookCS")));

            return services;
        }

        public static ConfigureHostBuilder UseInfrastructure(this ConfigureHostBuilder hostBuilder) {
            hostBuilder.UseNLog();

            return hostBuilder;
        }
    }
}

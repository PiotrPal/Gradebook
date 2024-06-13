﻿using Gradebook.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Gradebook.App.Middlewares {
    public class ExceptionHandlingMiddleware : IMiddleware {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
            try {
                await next(context);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);

                await HandleExceptionAsync(context, e);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception) {
            var statusCode = GetStatusCode(exception);
            var response = new {
                title = exception.Message,
                status = statusCode,
                errors = 
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch {
                GradebookException => (int)(exception as GradebookException).StatusCode,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };

        //private static IReadOnlyDictionary<string, string[]> GerErrors(Exception exception) {
        //    IReadOnlyDictionary<string, string[]> errors = null;

        //    if(exception is ValidationException validationException) {
        //        //errors = validationException
        //        //errors = validationException.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage.Split("'
        //    }
        //}
    }
}


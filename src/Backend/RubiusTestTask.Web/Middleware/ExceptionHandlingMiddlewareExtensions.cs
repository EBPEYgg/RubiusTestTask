﻿using Microsoft.AspNetCore.Diagnostics;
using NLog;

namespace RubiusTestTask.Web.Middleware
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        /// <summary>
        /// Метод, который добавляет Middleware для обработки 
        /// всех необработанных глобальных исключений. <br/>
        /// Клиенту возвращается JSON-ответ с сообщением об ошибке и кодом 500.
        /// </summary>
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var logger = LogManager.GetCurrentClassLogger();
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    if (exceptionHandlerPathFeature?.Error is not null)
                    {
                        logger.Error(exceptionHandlerPathFeature.Error, "Unhandled exception occurred.");

                        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
                        {
                            error = "An unexpected error occurred. Please try again later.",
                            details = exceptionHandlerPathFeature.Error.Message
                        }));
                    }
                });
            });
        }
    }
}
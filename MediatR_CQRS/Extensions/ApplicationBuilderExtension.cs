﻿using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Text;
using System.Text.Json;

namespace MediatR_CQRS.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    if (!(exception is ValidationException validationException))
                    {
                        throw exception;
                    }

                    var errors = validationException.Errors.Select(err => new
                    {
                        err.PropertyName,
                        err.ErrorMessage
                    });

                    var errorText=JsonSerializer.Serialize(errors);
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorText,Encoding.UTF8);
                });
            });
        }
    }
}

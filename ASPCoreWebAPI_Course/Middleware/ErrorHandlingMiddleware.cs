﻿using ASPCoreWebAPI_Course.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWebAPI_Course.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException nfe)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(nfe.Message);
            }
            catch(BadHttpRequestException badRequest)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequest.Message);
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 418;
                await context.Response.WriteAsync("Something is no yes");
            }

        }
    }
}

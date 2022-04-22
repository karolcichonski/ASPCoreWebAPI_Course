using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWebAPI_Course.Middleware
{
    public class TaskTimeMeasureMiddleware:IMiddleware
    {
        private readonly Stopwatch _stopwatch;
        private readonly ILogger<TaskTimeMeasureMiddleware> _logger;

        public TaskTimeMeasureMiddleware(ILogger<TaskTimeMeasureMiddleware> logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            
            _stopwatch.Start();

           await next.Invoke(context);

            _stopwatch.Stop();

            if (_stopwatch.Elapsed.Seconds > 4)
            {
                var message = 
                    $"Request [{context.Request.Method}] at {context.Request.Path} took {_stopwatch.ElapsedMilliseconds} ms";
                _logger.LogInformation(message);
            }
        }
    }
}

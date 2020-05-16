using Journey.Infrastructure.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Journey.API.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly ILogger Logger;
        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger)
        {
            this.Next = next;
            this.Logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await Next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ErrorModel errorModel = null;
            if (exception != null && exception.GetType().BaseType == typeof(ExceptionBase))
            {
                errorModel = new ErrorModel(context.Response.StatusCode, exception.Message);
            }
            else
            {
                errorModel = new ErrorModel(context.Response.StatusCode, ApplicationConstants.INTERNAL_SERVER_ERROR);
            }
            await context.Response.WriteAsync(errorModel.ToString());

        }
    }
}

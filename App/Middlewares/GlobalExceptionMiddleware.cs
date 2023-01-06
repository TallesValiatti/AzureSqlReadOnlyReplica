using System.Net;
using App.Domain.Shared;

namespace App.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessException ex)
            {
                await HandleBusinessExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleBusinessExceptionAsync(HttpContext httpContext, BusinessException ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var body = new 
            {
                Message = ex.Message
            };

            await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(body));
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var body = new 
            {
                Message = "Unexpected error"
            };

            await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(body));
        }
    }

}
using System.Net;
using System.Text.Json;

namespace ProductManagement.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception Occured!");
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            var response = new ExceptionResponse
            {
                StatusCode = (int)status,
                Message = "Something Went Wrong. Please try again later.",
                Details = exception.Message // In Production: remove or hide this 
            };

            context.Response.ContentType = "appliaciton/json";
            context.Response.StatusCode = (int)status

                var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}

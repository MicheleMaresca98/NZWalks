using System.Net;

namespace NZWalks.API.Middlewares
{

    public class ExceptionHanlderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHanlderMiddleware> _logger;

        public ExceptionHanlderMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHanlderMiddleware> logger
        )
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
                var errorId = Guid.NewGuid();

                _logger.LogError(ex, $"{errorId} : {ex.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var error = new
                {
                    ErrorId = errorId,
                    Message = "Something went wrong. Please contact support with the ErrorId."
                };

                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }

}
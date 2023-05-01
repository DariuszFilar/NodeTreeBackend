using NodeTree.INFRASTRUCTURE.Exceptions;
using NodeTree.INFRASTRUCTURE.Services.Abstract;
using NodeTree.INFRASTRUCTURE.Responses;
using System.Text.Json;

namespace NodeTree.INFRASTRUCTURE.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        /// <summary>
        /// Middleware for handling exceptions that occur during request processing.
        /// </summary>
        private readonly IExceptionLogService _exceptionLogService;
        public ErrorHandlingMiddleware(IExceptionLogService exceptionLogService)
        {
            _exceptionLogService = exceptionLogService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                context.Request.EnableBuffering();
                await next.Invoke(context);
            }
            catch (SecureException secureException)
            {
                context.Request.Body.Seek(0, SeekOrigin.Begin);

                var jsonDocument = await JsonDocument.ParseAsync(context.Request.Body);
                var requestBody = jsonDocument.RootElement
                    .EnumerateObject()
                    .ToDictionary(x => x.Name, x => x.Value.ToString());

                var queryParameters = context.Request.Query.ToDictionary(x => x.Key, x => x.Value.ToString());

                var exceptionLog = await _exceptionLogService.CreateExceptionLogAsync(secureException,
                    queryParameters,
                    requestBody);
                context.Response.StatusCode = 500;

                var response = new ExceptionMiddlewareResponse(exceptionLog);
                await context.Response.WriteAsJsonAsync(response);
            }          
        }
    }
}

using NodeTree.INFRASTRUCTURE.Exceptions;
using NodeTree.INFRASTRUCTURE.Services.Abstract;
using NodeTree.INFRASTRUCTURE.Responses;
using System.Text.Json;
using NodeTree.DB.Entities;

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

                var requestBody = await JsonDocument.ParseAsync(context.Request.Body)
                    .ContinueWith(doc => doc.Result.RootElement.EnumerateObject())
                    .ContinueWith(objs => objs.Result.Select(item =>
                        new BodyParameter
                        {
                            Key = item.Name,
                            Value = item.Value.ToString()
                        }
                    ).ToList());

                var queryParameters = context.Request.Query.Select(item =>
                    new QueryParameter
                    {
                        Key = item.Key,
                        Value = item.Value
                    }
                ).ToList();

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

using NodeTree.INFRASTRUCTURE.Exceptions;

namespace NodeTree.INFRASTRUCTURE.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (SecureException secureException)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(secureException.Message);
            }
        }
    }
}

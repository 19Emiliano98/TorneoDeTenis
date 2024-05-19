using Contracts.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;

namespace Contracts.Middlewares.MiddlewaresService
{
    public class ExceptionService : IExceptionService
    {
        public async Task GetBadRequestExceptionResponseAsync(HttpContext context, BadRequestException badRequestException)
        {
            context.Response.ContentType = context.Response.ContentType == null ?
                        "application/problem+json" :
                        context.Response.ContentType + ";application/problem+json";

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var error = badRequestException.GetJsonDescription();

            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(error));
        }

        public async Task GetLoopExceptionResponseAsync(HttpContext context, BadRequestException loopException)
        {
            context.Response.ContentType = context.Response.ContentType == null ?
                    "application/problem+json" :
                    context.Response.ContentType + ";application/problem+json";

            context.Response.StatusCode = (int)HttpStatusCode.LoopDetected;

            var error = loopException.GetJsonDescription();

            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(error));
        }

        public async Task GetNotFoundExceptionResponseAsync(HttpContext context, NotFoundException notFoundRequestException)
        {
            context.Response.ContentType = context.Response.ContentType == null ?
                        "application/problem+json" :
                        context.Response.ContentType + ";application/problem+json";

            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var error = notFoundRequestException.GetJsonDescription();

            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(error));
        }

        public Task GetNotFoundExceptionResponseAsync(HttpContext context, BadRequestException notFoundRequestException)
        {
            throw new NotImplementedException();
        }

        public async Task Unauthorized(HttpContext context, BadRequestException uNauthorized)
        {
            context.Response.ContentType = context.Response.ContentType == null ?
                                 "application/problem+json" :
                                 context.Response.ContentType + ";application/problem+json";

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            var error = uNauthorized.GetJsonDescription();

            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(error));
        }
    }
}

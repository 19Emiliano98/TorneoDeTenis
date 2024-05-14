using Contracts.Exceptions;
using Contracts.Middlewares.MiddlewaresService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _loger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> loger)
        {
            _next = next;
            _loger = loger;
        }

        public async Task Invoke(HttpContext context, IExceptionService exceptionService)
        {
            try
            {
                await _next(context);
            }
            catch (BadRequestException badRequestException)
            {
                await exceptionService.GetBadRequestExceptionResponseAsync(context, badRequestException);

            }
            catch(Exception ex) 
            {

                //await exceptionService.Unauthorized(context, uNauthorized);
                
                //Alguna logica de que devolvemos en caso de que capturemos esa exception
                throw;
            }
        }

    }

}

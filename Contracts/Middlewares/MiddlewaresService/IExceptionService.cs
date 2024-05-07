using Contracts.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Middlewares.MiddlewaresService
{
    public interface IExceptionService
    {
        Task GetBadRequestExceptionResponseAsync(HttpContext context, BadRequestException badRequestException);

        Task GetNotFoundExceptionResponseAsync(HttpContext context, BadRequestException notFoundRequestException);

        Task GetLoopExceptionResponseAsync(HttpContext context, BadRequestException loopException);

    }
}

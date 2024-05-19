using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Contracts.Exceptions
{
    public class BadRequestException : Exception
    {
        private readonly string _titulo;
        private readonly string _detalle;
        private readonly List<(string, string)> _errors;

        public BadRequestException(string titulo, string detalle)
        {
            _titulo = titulo;
            _detalle = detalle;
        }

        public BadRequestException(string titulo, string detalle, List<(string, string)> errors)
        {
            _titulo = titulo;
            _detalle = detalle;
            _errors = errors;
        }

        public string GetJsonDescription()
        {
            var problemDetails = new ValidationProblemDetails()
            {
                Title = _titulo,
                Detail = _detalle,
                Status = (int)StatusCodes.Status400BadRequest,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            if (_errors != null)
            {
                var dictionary = _errors.ToDictionary();

                problemDetails.Extensions.Add("Errors", dictionary);

                return JsonConvert.SerializeObject(problemDetails);
            }

            return JsonConvert.SerializeObject(problemDetails);
        }
    }
}

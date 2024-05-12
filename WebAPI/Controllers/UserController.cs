using Contracts.DTO.Responses;
using Contracts.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.User;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationServices _authenticationServices;
        private readonly IHttpContextAccessor _contextaccesor;
        public UserController(IUserService userService, IAuthenticationServices service, IHttpContextAccessor contextaccesor)
        {
            _userService = userService;
            _authenticationServices = service;
            _contextaccesor = contextaccesor;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateUserAsync(UserRequest userReq)
        {
            await _userService.CreateUserAsync(userReq);

            return Ok("Usuario Creado");
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(UserRequest userReq)
        {
            var userValid = await _userService.UserValidationAsync(userReq);

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Error de autorización", "No esta autorizado a estar acá");
            }

            var log = _authenticationServices.generateToken(userValid);

            return Ok(log);

        }
    }
}

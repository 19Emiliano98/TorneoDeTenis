using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : Controller
    {
        private readonly IPlayerService _playerService;

        public TournamentController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateTournament()
        {
            var response = await _playerService.SetLuckAsync();

            return Ok(response);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly IMatchService _matchService;

        public TournamentController(IPlayerService playerService, IMatchService matchService)
        {
            _playerService = playerService;
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateTournament()
        {
            var playersList = await _playerService.SetLuckAsync();
            
            await _matchService.InitMatchAsync(playersList);
            

            return Ok("Ok");
        }

    }
}

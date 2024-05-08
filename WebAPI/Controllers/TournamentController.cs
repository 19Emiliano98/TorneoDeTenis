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
        private readonly ITournamentService _tournamentService;

        public TournamentController(IPlayerService playerService, IMatchService matchService, ITournamentService tournamentService)
        {
            _playerService = playerService;
            _matchService = matchService;
            _tournamentService = tournamentService;
        }

        [HttpPost]
        public async Task<IActionResult> InitTournament()
        {
            await _tournamentService.CreateTournamentAsync("Copa Emiliano");

            var playersList = await _playerService.SetLuckAsync();
            
            var champion = await _matchService.InitMatchAsync(playersList);

            await _tournamentService.SetChampion(champion);

            return Ok(champion);
        }

    }
}

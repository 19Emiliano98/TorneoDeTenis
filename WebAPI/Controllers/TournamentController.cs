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


        [HttpGet]
        /// traemos a los ganadores de los partidos
        //public async Task<IActionResult> GetFirtMatchesWinner()
        [HttpPost]
        public async Task<IActionResult> InitTournament()
        {
            await _tournamentService.CreateTournamentAsync("Copa Carlos");

            var playersList = await _playerService.SetLuckAsync();
            
            var champion = await _matchService.InitMatchAsync(playersList);


            await _tournamentService.SetChampion(champion);

            // acá listaria a los ganador previos 
            // matchgame o matchInitial a definir
                
            //return Ok(response);
            return Ok(champion);
        }

    }
}

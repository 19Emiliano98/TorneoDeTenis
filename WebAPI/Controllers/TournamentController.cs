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
        
        // Posteamos un Torneo / partido 
        //[HttpPost]


        [HttpGet]
        /// traemos a los ganadores de los partidos
        public async Task<IActionResult> GetFirtMatchesWinner()
        {
            var playersList = await _playerService.SetLuckAsync();

            var response = await _matchService.InitMatchAsync(playersList);

            // acá listaria a los ganador previos 
            // matchgame o matchInitial a definir
                
            return Ok(response);
        }



    }
}

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
        [HttpPost]

        // En proceso
        //public async Task<IActionResult> CreateTournament([FromBody]  )
        //{
           

        //        return Ok("Player created Succesfully");
        //}



        [HttpGet]


        /// traemos a los ganadores de los partidos
        public async Task<IActionResult> GetFirtMatchesWinner()
        {
            var playersList = await _playerService.SetLuckAsync();

            await _matchService.InitMatchAsync(playersList);


            return Ok("Ok");
        }



    }
}

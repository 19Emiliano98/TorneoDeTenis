using Microsoft.AspNetCore.Authorization;
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

        // los endpoints se pueden pensar en : después de crearlo puedo listar toda su info

        //[HttpGet("Matches/{Id}")]

        //public async Task<IActionResult> GetListofMatch(int Id)
        //{
        //    var List = await _tournamentService.GetListofMatch(Id);
        //    return Ok(List);
        //}

        //[HttpGet("Players/{Id}")]
        //public async Task<IActionResult> GetPlayersOfTournant(int Id)
        //{
        //    var getPlayers = await _tournamentService.GetAllPlayers(Id);
        //    return Ok(get);
        //}


        [Authorize(Policy ="SuperAdmin")]
        //[Authorize(Roles = "arbitro")]

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAllMatchesFromTournament(int Id)
        {
            var getTournament = await _tournamentService.GetPlayerForTournament(Id);
            return Ok(getTournament);
        }

        //public async Task<IActionResult> GetFirtMatchesWinner()
        [Authorize(Roles = "arbitro")]


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

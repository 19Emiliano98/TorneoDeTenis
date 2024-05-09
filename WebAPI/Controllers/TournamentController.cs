using Contracts.Enums;
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


        // Probando como funcionan los Enums
        [HttpGet]
        public IActionResult Get()
        {
            var test = Enum.GetName(typeof(Gender), Gender.Male);

            return Ok(test);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTournamentByIdAsync(int Id)
        {
            var getTournament = await _tournamentService.GetDataTournamentAsync(Id);
            
            return Ok(getTournament);
        }

        [HttpPost]
        public async Task<IActionResult> InitTournament([FromBody] string name)
        {
            await _tournamentService.CreateTournamentAsync(name);

            var playersList = await _playerService.SetLuckAsync(Enum.GetName(typeof(Gender), Gender.Female));

            var champion = await _matchService.InitMatchAsync(playersList);

            await _tournamentService.SetChampion(champion);

            return Ok(champion);
        }

    }
}

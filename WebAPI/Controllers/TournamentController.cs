using Contracts.Enums;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

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
        [Route("{Id}")]
        public async Task<IActionResult> GetTournamentByIdAsync(int Id)
        {
            var getTournament = await _tournamentService.GetDataTournamentAsync(Id);
            
            return Ok(getTournament);
        }

        [HttpPost]
        [Route("Males")]
        public async Task<IActionResult> InitTournamentMales([FromBody] string name)
        {
            await _tournamentService.CreateTournamentAsync(name);

            var playersList = await _playerService.SetLuckAsync(Enum.GetName(typeof(Gender), Gender.Male));

            var champion = await _matchService.InitMatchAsync(playersList);

            await _tournamentService.SetChampion(champion);

            return Ok(champion);
        }

        [HttpPost]
        [Route("Females")]
        public async Task<IActionResult> InitTournamentFemales([FromBody] string name)
        {
            await _tournamentService.CreateTournamentAsync(name);

            var playersList = await _playerService.SetLuckAsync(Enum.GetName(typeof(Gender), Gender.Female));

            var champion = await _matchService.InitMatchAsync(playersList);

            await _tournamentService.SetChampion(champion);

            return Ok(champion);
        }

    }
}

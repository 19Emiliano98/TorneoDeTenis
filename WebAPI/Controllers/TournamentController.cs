using Contracts.DTO.Requests;
using Contracts.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : Controller
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _tournamentService.GetAllTournamentsAsync();

            if (!response.Any())
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{Id}")]
        [Authorize(Policy = "Jugador")]
        public async Task<IActionResult> GetTournamentByIdAsync(int Id)
        {
            var getTournament = await _tournamentService.GetDataTournamentAsync(Id);

            if (getTournament == null)
            {
                return NotFound();
            }

            return Ok(getTournament);
        }

        [HttpPost]
        [Authorize(Policy = "Arbitro")]
        public async Task<IActionResult> InitTournament([FromBody] InitTournamentRequest data)
        {
            var champion = await _tournamentService.InitTournamentMicroService(data);

            return Ok(champion);
        }
    }
}

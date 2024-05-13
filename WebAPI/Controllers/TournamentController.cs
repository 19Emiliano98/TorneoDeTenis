using Microsoft.AspNetCore.Authorization;
﻿using Contracts.DTO.Requests;
using Contracts.Enums;
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





        //[Authorize(Policy ="SuperAdmin")]

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _tournamentService.GetAllTournamentsAsync();

            return Ok(response);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetTournamentByIdAsync(int Id)
        {
            var getTournament = await _tournamentService.GetDataTournamentAsync(Id);
            
            return Ok(getTournament);
        }

        [Authorize(Roles = "arbitro")]



        [HttpPost]
        public async Task<IActionResult> InitTournament([FromBody] InitTournamentRequest data)
        {
            var champion = await _tournamentService.InitTournamentMicroService(data);

            return Ok(champion);
        }
    }
}

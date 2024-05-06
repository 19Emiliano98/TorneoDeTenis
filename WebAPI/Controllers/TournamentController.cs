﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IMatchHistoryService _matchHistoryService;

        public TournamentController(IPlayerService playerService, IMatchService matchService)
        {
            _playerService = playerService;
            _matchService = matchService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTournament()
        {
            var playersList = await _playerService.SetLuckAsync();
            
            var champion = await _matchService.InitMatchAsync(playersList);
            
            await _matchHistoryService.SaveMatchOnTournamentAsync(champion);

            return Ok(champion);
        }

    }
}

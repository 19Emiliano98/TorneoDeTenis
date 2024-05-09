﻿using Contracts.DTO.Responses.Player;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMatchService
    {
        Task<PlayerStatsResponse> InitMatchAsync(List<PlayerStatsResponse> playerList);

        Task<PlayerStatsResponse> MatchGame(PlayerStatsResponse playerOne, PlayerStatsResponse playerTwo);

     
    }
}

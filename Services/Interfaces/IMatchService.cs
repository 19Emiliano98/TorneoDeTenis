using Data.Entities;
using DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMatchService
    {
        Task<List<PlayerStatsResponse>> InitMatchAsync(List<PlayerStatsResponse> playerList);
        Task<PlayerStatsResponse> MatchGame(PlayerStatsResponse playerOne, PlayerStatsResponse playerTwo);
        PlayerStatsResponse RestHabilitie(PlayerStatsResponse playerHabilitesRest);
     
    }
}

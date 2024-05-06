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
        Task<PlayerStatsResponse> InitMatchAsync(List<PlayerStatsResponse> playerList);

        //Task<PlayerStatsResponse> MatchGame(PlayerStatsResponse playerOne, PlayerStatsResponse playerTwo);

        // todos se tieneq ue cambiar a  playerMatchesResponse 
        //PlayerStatsResponse RestHabilitie(PlayerStatsResponse playerHabilitesRest);
        //Task<List<PlayerStatsResponse>> QuarterMatches(List<PlayerStatsResponse> playerList);
        //Task<List<PlayerStatsResponse>> SemiFinalMatches(List<PlayerStatsResponse> playerList);
        //Task<List<PlayerStatsResponse>> FinalMatche(List<PlayerStatsResponse> playerList);

    }
}

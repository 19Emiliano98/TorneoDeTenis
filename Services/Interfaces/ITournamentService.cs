using Contracts.DTO.Responses;
using Data.Entities;
using DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITournamentService
    {
        Task CreateTournamentAsync(string name);
        Task SetChampion(PlayerStatsResponse champeon);

        // List de jugadores del capeonato
        //Task<List<PlayerStatsResponse>> GetAllPlayers(int Id);
        Task<TournamentResultResponse> GetPlayerForTournament(int Id);

        //Task<List<PlayerMatchesResponse>> GetListofMatch(int Id);



    }
}

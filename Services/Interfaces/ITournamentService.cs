using Contracts.DTO.Responses.Player;
using Contracts.DTO.Responses.Tournament;
using Data.Entities;
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
        Task<TournamentResultResponse> GetDataTournamentAsync(int Id);
    }
}

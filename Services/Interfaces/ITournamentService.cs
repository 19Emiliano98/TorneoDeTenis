﻿using Contracts.DTO.Requests;
using Contracts.DTO.Responses.Player;
using Contracts.DTO.Responses.Tournament;

namespace Services.Interfaces
{
    public interface ITournamentService
    {
        Task SetChampion(PlayerStats champeon);
        Task<TournamentResult> GetDataTournamentByIdAsync(int Id);
        Task<List<TournamentGetAll>> GetAllTournamentsAsync();
        Task<PlayerStats> InitTournamentMicroService(InitTournamentRequest request);
    }
}

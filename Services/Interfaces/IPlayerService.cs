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
    public interface IPlayerService
    {
        //List<List<Player> GetPlayers();
        Task<List<PlayerStatsResponse>> SetLuckAsync();
        // a aplicar
        //Task<List<PlayerStatsResponse>> SetBadLuckAsync();



    }
}

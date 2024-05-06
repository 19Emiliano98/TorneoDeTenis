using Contracts.DTO.Responses;
using Contracts.Mappers;
using Data.Entities;
using Data.Repository;
using DTO.Responses;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly TournamentContext _context;

        public PlayerService(TournamentContext tournamentContext)
        {
            _context = tournamentContext;
        }
        // a probar metodo ( ya listamos dos veces lo mismo )

        //public async Task<List<Player>> GetPlayersAsync()
        //{
        //    var playersList = await _context.Set<Player>().ToListAsync();

        //    return playersList;
        //}

        public async Task<List<PlayerStatsResponse>> SetLuckAsync()
        {
            var playersList = await _context.Set<Player>().ToListAsync();
            
            //var playerList = await GetPlayersAsync();
            
            var playerResponseList = new List<PlayerStatsResponse>();

            foreach (var player in playersList)
            {
                var random = new Random();

                player.Luck = random.Next(0, 101);

                _context.Set<Player>().Update(player);

                var playerResponse = player.ToPlayerStatsResponse();

                playerResponseList.Add(playerResponse);

            }

            await _context.SaveChangesAsync();

            return playerResponseList;
        }

 
    }
}

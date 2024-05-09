using Contracts.DTO.Requests;
using Contracts.DTO.Responses;
using Contracts.DTO.Responses.Player;
using Contracts.Exceptions;
using Contracts.Mappers;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly TournamentContext _context;

        public PlayerService(TournamentContext tournamentContext)
        {
            _context = tournamentContext;

        }

        public async Task<List<PlayerStatsResponse>> SetLuckAsync(string gender)
        {
            var playersList = await _context.Set<Player>()
                                            .Where(x => x.Gender == gender)
                                            .ToListAsync();

            if (!CheckAmountOfPlayers(playersList))
            {
                throw new Exception("Los participantes del torneo no son potencia de 2");
            }

            var playerResponseList = new List<PlayerStatsResponse>();
            
            var random = new Random();

            foreach (var player in playersList)
            {

                player.Luck = random.Next(1, 100);
              
                _context.Set<Player>().Update(player);

                var playerResponse = player.ToPlayerStatsResponse();

                playerResponseList.Add(playerResponse);

            }

            await _context.SaveChangesAsync();

            return playerResponseList;
        }

        private bool CheckAmountOfPlayers(List<Player> playersList)
        {
            var participants = playersList.Count();

            var res = participants > 0 && (participants & (participants - 1)) == 0;

            return res;
        }
    }
}

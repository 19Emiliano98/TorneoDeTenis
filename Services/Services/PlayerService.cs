using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly TournamentContext _tournamentContext;

        public PlayerService(TournamentContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task<List<Player>> SetLuckAsync()
        {
            var playersList = await _tournamentContext.Set<Player>().ToListAsync();

            foreach (var player in playersList)
            {
                var random = new Random();

                player.Luck = random.Next(0, 101);

                _tournamentContext.Set<Player>().Update(player);
            }

            await _tournamentContext.SaveChangesAsync();

            return playersList;
        }

    }
}

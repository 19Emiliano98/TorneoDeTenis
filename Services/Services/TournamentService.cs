using Data.Entities;
using Data.Repository;
using DTO.Responses;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{

    public class TournamentService : ITournamentService
    {
        private readonly TournamentContext _context;

        public TournamentService(TournamentContext context)
        {
            _context = context;
        }

        public async Task CreateTournamentAsync(string name)
        {
            var tournament = new HistoryTournament();

            tournament.Name = name;
            tournament.Date = DateTime.Now;

            _context.Set<HistoryTournament>().Add(tournament);

            await _context.SaveChangesAsync();
        }

        public async Task SetChampion(PlayerStatsResponse champeon)
        {
      
            var lastTournament = await _context.Set<HistoryTournament>().OrderByDescending(t => t.Id).FirstOrDefaultAsync();

            lastTournament.IdPlayer = champeon.Id;

            _context.Set<HistoryTournament>().Update(lastTournament);

            await _context.SaveChangesAsync();
        }
    }
}

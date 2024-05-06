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
    public class MatchHistoryService
    {
        private readonly TournamentContext _context;

        public MatchHistoryService(TournamentContext tournamentContext)
        {
            _context = tournamentContext;
        }

        //public async Task SaveMatchOnTournamentAsync(PlayerStatsResponse champion)
        //{
        //    var matchHistory = new MatchHistory();

        //    var lastTournament = await _context.Set<MatchHistory>()
        //                                        .OrderByDescending(x => x.Id)
        //                                        .FirstOrDefaultAsync();

        //    if (lastTournament == null)
        //    {
        //        matchHistory.IdTournament = 1;
        //    }


        //}
    }
}

using Contracts.DTO.Responses;
using Data.Entities;
using Data.Repository;
using DTO.Responses;
using Microsoft.AspNetCore.Mvc;
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


        // de mas 
        public async Task<TournamentResultResponse> GetPlayerForTournament(int Id)
        {
            var tournament = await _context.Set<HistoryTournament>()
                                    .OrderByDescending(t => t.Id)
                                    .Where(t => t.Id == Id)
                                    .Include(t => t.IdPlayerForeignKey)
                                    .FirstOrDefaultAsync();

            var playerResponse = new PlayerStatsResponse
            {
                Name = tournament.IdPlayerForeignKey.Name,
                Luck = tournament.IdPlayerForeignKey.Luck,
                Hability = tournament.IdPlayerForeignKey.Hability,
                Strenght = tournament.IdPlayerForeignKey.Strenght,
                Speed = tournament.IdPlayerForeignKey.Speed
            };

            var response = new TournamentResultResponse
            {
                DataPlayer = playerResponse,
                Name = tournament.Name,
                Date = tournament.Date
            };

            return response;

        }
        
        //public async Task<List<PlayerStatsResponse>> GetAllPlayers(int Id)
        //{

        //    var List = await _context.Set<Match>()
        //        .Include(m => m.)
        //        .ThenInclude(p => p.IdTournament)
        //        .Include(p => p.)

        //        .Where(ht => ht.IdPlayer == Id)
        //        .ToListAsync();


        //    var rtaList = new List<PlayerStatsResponse>();

        //    foreach (var players in List)
        //    {
        //        var playerResponse = new PlayerStatsResponse
        //        {
        //            Name = players.IdPlayerForeignKey.Name,
        //            Luck = players.IdPlayerForeignKey.Luck,
        //            Hability = players.IdPlayerForeignKey.Hability,
        //            Strenght = players.IdPlayerForeignKey.Strenght,
        //            Speed = players.IdPlayerForeignKey.Speed
        //        };

        //        rtaList.Add(playerResponse);
        //    }
        //    return rtaList;
        //    //return playerResponse;
        //}
        
        // parado //
        //public async Task<List<PlayerMatchesResponse>> GetListofMatch(int Id)
        //{
        //    var matchesResponse = await _context.Set<Match>()

        //        // incluir virtual de IdLoser | trabajar entre uniones de tablas
        //        .Include(t => t.)
        //        .ThenInclude(m => m.MatchWinner)
        //        //.Include(t => t.Matches)
        //        //.ThenInclude(m => m.MatchLoser)
        //        //.Where(t => t.IdPlayer == Id)
        //        .SelectMany(t => t.Matches)
        //        .Where(m => m.IdWinner == Id)
        //             .Select(m => new PlayerMatchesResponse
        //             {
        //                 IdWinner = m.MatchWinner.Id,
        //                 WinnerName = m.MatchWinner.Name,
        //                 IdLoser = m.MatchLoser.Id,
        //                 LoserName = m.MatchLoser.Name,
        //             })
        //                 .ToListAsync();

        //    return matchesResponse;
        //}

        public async Task SetChampion(PlayerStatsResponse champeon)
        {

            var lastTournament = await _context.Set<HistoryTournament>()
                                    .OrderByDescending(t => t.Id) // Ordenar por fecha de registro (o cualquier otro criterio)
                                    .FirstOrDefaultAsync();
            lastTournament.IdPlayer = champeon.Id;

            _context.Set<HistoryTournament>().Update(lastTournament);

            await _context.SaveChangesAsync();
        }
    }
}

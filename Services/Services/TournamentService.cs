using Contracts.DTO.Requests;
using Contracts.DTO.Responses.Match;
using Contracts.DTO.Responses.Player;
using Contracts.DTO.Responses.Tournament;
using Contracts.Enums;
using Contracts.Mappers;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly TournamentContext _context;
        private readonly IPlayerService _playerService;
        private readonly IMatchService _matchService;

        public TournamentService(TournamentContext context, IPlayerService playerService, IMatchService matchService)
        {
            _context = context;
            _playerService = playerService;
            _matchService = matchService;
        }

        public async Task CreateTournamentAsync(string name)
        {
            var tournament = new HistoryTournament();

            tournament.Name = name;
            tournament.Date = DateTime.Now;

            _context.Set<HistoryTournament>().Add(tournament);

            await _context.SaveChangesAsync();
        }

        public async Task<TournamentResult> GetDataTournamentAsync(int Id)
        {
            var tournament = await _context.Set<HistoryTournament>()
                                    .OrderByDescending(t => t.Id)
                                    .Where(t => t.Id == Id)
                                    .Include(t => t.IdPlayerForeignKey)
                                    .FirstOrDefaultAsync();

            var matchs = await _context.Set<Match>()
                                    .Where(t => t.IdTournament == tournament.Id)
                                    .Include(t => t.MatchWinner)
                                    .Include(t => t.MatchLoser)
                                    .ToListAsync();

            var matchListResponse = new List<MatchData>();

            foreach (var match in matchs)
            {
                var matchData = new MatchData();

                matchData.Id = match.Id;
                matchData.Winner = match.MatchWinner.Name;
                matchData.Loser = match.MatchLoser.Name;

                matchListResponse.Add(matchData);
            }

            var response = new TournamentResult
            {
                Name = tournament.Name,
                Date = tournament.Date,
                Champion = tournament.IdPlayerForeignKey.Name,
                MatchsPlayed = matchListResponse
            };

            return response;
        }

        public async Task SetChampion(PlayerStats champeon)
        {

            var lastTournament = await _context.Set<HistoryTournament>()
                                            .OrderByDescending(t => t.Id)
                                            .FirstOrDefaultAsync();

            lastTournament.IdPlayer = champeon.Id;

            _context.Set<HistoryTournament>().Update(lastTournament);

            await _context.SaveChangesAsync();
        }

        public async Task<List<TournamentGetAll>> GetAllTournamentsAsync()
        {
            var allTournaments = await _context.Set<HistoryTournament>()
                                            .Include(t => t.IdPlayerForeignKey)
                                            .ToListAsync();
            
            var AllTournamentList = new List<TournamentGetAll>();

            foreach(var tournament in allTournaments)
            {
                AllTournamentList.Add(tournament.ToPlayerStatsResponse());
            }
            
            return AllTournamentList;
        }

        public async Task<PlayerStats> InitTournamentMicroService(InitTournamentRequest request)
        {
            await CreateTournamentAsync(request.TournamentName);

            var playersList = await _playerService.SetLuckAsync(request.TournamentGenderOfPlayers);

            var champion = await _matchService.InitMatchAsync(playersList);

            await SetChampion(champion);

            return champion;
        }
    }
}

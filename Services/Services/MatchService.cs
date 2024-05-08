using Contracts.DTO.Responses;
using Data.Entities;
using Data.Repository;
using DTO.Responses;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class MatchService : IMatchService
    {
        private readonly TournamentContext _context;

        public MatchService(TournamentContext context)
        {
            _context = context;
        }

        public async Task<PlayerStatsResponse> InitMatchAsync(List<PlayerStatsResponse> playerList)
        {
            var listResults = new List<PlayerStatsResponse>();

            Random rnd = new Random();

            while (playerList.Count != 0)
            {
                var indiceJugador1 = rnd.Next(0, playerList.Count);
                var jugador1 = playerList[indiceJugador1];
                playerList.RemoveAt(indiceJugador1);

                var indiceJugador2 = rnd.Next(0, playerList.Count);
                var jugador2 = playerList[indiceJugador2];
                playerList.RemoveAt(indiceJugador2);

                var winnerOfMatch = await MatchGame(jugador1, jugador2);

                listResults.Add(winnerOfMatch);

                if (playerList.Count == 0 && listResults.Count > 1)
                {
                    foreach (var player in listResults)
                    {
                        playerList.Add(player);
                    }
                    
                    listResults.Clear();
                }
            }

            return listResults[0];
        }

        public async Task<PlayerStatsResponse> MatchGame(PlayerStatsResponse playerOne, PlayerStatsResponse playerTwo)
        {

            var habilityPlayerOne = 10 + 10 + playerOne.Luck;
            var habilityPlayerTwo = 10 + 10 + playerOne.Luck;

            while (habilityPlayerOne.Equals(habilityPlayerTwo))
            {
                var random = new Random();

                habilityPlayerOne = habilityPlayerOne + random.Next(0, 100);
                habilityPlayerTwo = habilityPlayerTwo + random.Next(0, 100);
            }

            var matchNewData = new Match();

            if (habilityPlayerOne > habilityPlayerTwo)
            {
                matchNewData.IdTournament = await SeekTournamentIdAsync();
                matchNewData.IdWinner = playerOne.Id;
                matchNewData.IdLoser = playerTwo.Id;

                _context.Set<Match>().Add(matchNewData);

                await _context.SaveChangesAsync();

                return playerOne;
            }

            matchNewData.IdTournament = await SeekTournamentIdAsync();
            matchNewData.IdWinner = playerTwo.Id;
            matchNewData.IdLoser = playerOne.Id;

            _context.Set<Match>().Add(matchNewData);

            await _context.SaveChangesAsync();

            return playerTwo;
        }

        private async Task<int> SeekTournamentIdAsync()
        {
            var lastTournament = await _context.Set<HistoryTournament>()
                                                .OrderByDescending(x => x.Id)
                                                .FirstOrDefaultAsync();

            if (lastTournament == null)
            {
                throw new Exception();
            }

            return lastTournament.Id;
        }
    }
}


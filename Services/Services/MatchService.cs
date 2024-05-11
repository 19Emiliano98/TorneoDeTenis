using Contracts.DTO.Responses.Player;
using Data.Entities;
using Data.Repository;
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

        public async Task<PlayerStats> InitMatchAsync(List<PlayerStats> playerList)
        {
            var listResults = new List<PlayerStats>();

            while (playerList.Count != 0)
            {
                var playerOne = SelectPlayer(playerList);
                var playerTwo = SelectPlayer(playerList);

                var winnerOfMatch = await MatchGame(playerOne, playerTwo);

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

        public async Task<PlayerStats> MatchGame(PlayerStats playerOne, PlayerStats playerTwo)
        {
            var matchNewData = new Match();

            var pointsPlayerOne = PointsCalculator(playerOne);
            var pointsPlayerTwo = PointsCalculator(playerTwo);

            if (pointsPlayerOne > pointsPlayerTwo)
            {
                matchNewData.IdTournament = await SeekLastTournamentAsync();
                matchNewData.IdWinner = playerOne.Id;
                matchNewData.IdLoser = playerTwo.Id;

                _context.Set<Match>().Add(matchNewData);

                await _context.SaveChangesAsync();

                return playerOne;
            }

            matchNewData.IdTournament = await SeekLastTournamentAsync();
            matchNewData.IdWinner = playerTwo.Id;
            matchNewData.IdLoser = playerOne.Id;

            _context.Set<Match>().Add(matchNewData);

            await _context.SaveChangesAsync();

            return playerTwo;
        }

        private static PlayerStats SelectPlayer(List<PlayerStats> playerList)
        {
            var random = new Random();

            var playerIndex = random.Next(0, playerList.Count);
            var player = playerList[playerIndex];

            playerList.RemoveAt(playerIndex);

            return player;
        }

        private static int PointsCalculator(PlayerStats playerData)
        {
            int totalPoint;

            var basePoints = (int)playerData.Luck * playerData.Hability;

            if (playerData.Gender == "Male")
            {
                totalPoint = basePoints + playerData.Strenght + playerData.Speed;

                return totalPoint;
            }

            totalPoint = basePoints + playerData.TimeReaction;

            return totalPoint;
        }

        private async Task<int> SeekLastTournamentAsync()
        {
            var lastTournament = await _context.Set<HistoryTournament>()
                                                .OrderByDescending(x => x.Id)
                                                .FirstOrDefaultAsync();

            if (lastTournament == null)
            {
                throw new Exception("No existen torneos en la tabla");
            }

            return lastTournament.Id;
        }
    }
}


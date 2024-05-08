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
        // lista de ganadores 
        private readonly TournamentContext _context;
        // lista rde partidos 
        private readonly List<Match> matchResults = new List<Match>();

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

            var habilityPlayerOne = (playerOne.Strenght, playerOne.Speed, playerOne.Luck, playerOne.Hability);
            var habilityPlayerTwo = (playerTwo.Strenght, playerTwo.Speed, playerOne.Luck, playerTwo.Hability);

            var random = new Random();

            int habilityTotalPlayerOne = 0;
            int habilityTotalPlayerTwo = 0;

            while (habilityPlayerOne.Equals(habilityPlayerTwo))
            {

                if (random.Next(2) == 0)
                {

                    playerOne.Strenght += playerOne.Luck ?? 0;

                    playerOne.Luck += playerOne.Hability;

                    playerTwo.Hability -= playerTwo.Luck ?? 0;

                    playerOne.Strenght -= playerOne.Luck ?? 0;

                    playerTwo.Strenght += playerTwo.Luck ?? 0;

                    playerOne.Speed += playerOne.Luck ?? 0;

                    playerTwo.Speed -= playerTwo.Luck ?? 0;

                }
                else
                {
                    playerOne.Strenght += playerOne.Luck ?? 0;
                    playerTwo.Strenght -= playerTwo.Luck ?? 0;

                    playerOne.Speed -= playerOne.Luck ?? 0;
                    playerTwo.Speed += playerOne.Luck ?? 0;

                    playerOne.Hability -= playerOne.Luck ?? 0;
                    playerTwo.Hability += playerTwo.Luck ?? 0;
                }


                habilityTotalPlayerOne = (playerOne.Strenght + playerOne.Speed + playerOne.Hability);
                habilityTotalPlayerTwo = (playerTwo.Strenght + playerTwo.Speed + playerTwo.Hability);
            }
            // esta bien setear la entidad si tenemos el dto ?
            var matchNewData = new Match();
            //var matchNewData = new PlayerMatchesResponse();
            if (habilityTotalPlayerOne > habilityTotalPlayerTwo)
            {
                matchNewData.IdTournament = await SeekTournamentIdAsync();
                matchNewData.IdWinner = playerOne.Id;
                matchNewData.IdLoser = playerTwo.Id;

                _context.Set<Match>().Add(matchNewData);

                await _context.SaveChangesAsync();
                // almaceno a los ganadores
                matchResults.Add(matchNewData);
                return playerOne;
            }

            matchNewData.IdTournament = await SeekTournamentIdAsync();
            matchNewData.IdWinner = playerTwo.Id;
            matchNewData.IdLoser = playerOne.Id;

            _context.Set<Match>().Add(matchNewData);

            await _context.SaveChangesAsync();

            matchResults.Add(matchNewData);

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


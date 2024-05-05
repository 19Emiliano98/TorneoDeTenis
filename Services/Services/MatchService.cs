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
    public class MatchService : IMatchService
    {

        private readonly TournamentContext _context;

        public MatchService(TournamentContext context)
        {
            _context = context;
        }

        public async Task InitMatchAsync(List<PlayerStatsResponse> playerList)
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

                //listResults.Add(winnerOfMatch);
            }
    }

        private async Task<PlayerStatsResponse> MatchGame(PlayerStatsResponse playerOne, PlayerStatsResponse playerTwo)
        {
            var habilityPlayerOne = (playerOne.Strenght * playerOne.Speed) + playerOne.Luck;
            var habilityPlayerTwo = (playerTwo.Strenght * playerTwo.Speed) + playerOne.Luck;

            while (habilityPlayerOne.Equals(habilityPlayerTwo))
            {
                var random = new Random();

                habilityPlayerOne = habilityPlayerOne + random.Next(0, 100);
                habilityPlayerTwo = habilityPlayerTwo + random.Next(0, 100);
            }

            var matchNewData = new Match();

            if (habilityPlayerOne > habilityPlayerTwo)
            {
                matchNewData.IdWinner = playerOne.Id;
                matchNewData.IdLoser = playerTwo.Id;

                _context.Set<Match>().Add(matchNewData);

                await _context.SaveChangesAsync();

                return playerOne;
            }

            matchNewData.IdWinner = playerTwo.Id;
            matchNewData.IdLoser = playerOne.Id;

            _context.Set<Match>().Add(matchNewData);

            await _context.SaveChangesAsync();

            return playerTwo;
        }
    }
}

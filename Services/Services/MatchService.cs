using Contracts.DTO.Responses;
using Data.Entities;
using Data.Repository;
using DTO.Responses;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MatchService : IMatchService
    {
        // lista de ganadores 
        private readonly TournamentContext _context;

        public MatchService(TournamentContext context)
        {
            _context = context;
        }
        private List<PlayerStatsResponse> matchResult;
        public async Task<List<PlayerStatsResponse>> InitMatchAsync(List<PlayerStatsResponse> playerList)
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
                //listResults.Add(player);

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

            return listResults;


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

                    playerOne.Hability += playerOne.Luck;
                    playerTwo.Hability -= playerTwo.Luck;
                    playerOne.Strenght -= playerOne.Luck;
                    playerTwo.Strenght += playerTwo.Luck;
                    playerOne.Speed += playerOne.Luck;
                    playerTwo.Speed -= playerTwo.Luck;

                }
                else
                {
                    playerOne.Strenght += playerOne.Luck;
                    playerTwo.Strenght -= playerTwo.Luck;

                    playerOne.Speed -= playerOne.Luck;
                    playerTwo.Speed += playerOne.Luck;

                    playerOne.Hability -= playerOne.Luck;
                    playerTwo.Hability += playerTwo.Luck;
                }
                // verificar si almacena los datos menos la suerte 
                habilityTotalPlayerOne = (playerOne.Strenght + playerOne.Speed + playerOne.Luck + playerOne.Hability);
                habilityTotalPlayerTwo = (playerTwo.Strenght + playerTwo.Speed + playerTwo.Luck + playerTwo.Hability);
            }


            var matchNewData = new Match();


            if (habilityTotalPlayerOne > habilityTotalPlayerTwo)
            {
                matchNewData.IdWinner = playerOne.Id;
                matchNewData.IdLoser = playerTwo.Id;

                _context.Set<Match>().Add(matchNewData);

                await _context.SaveChangesAsync();
                // almaceno a los ganadores
                matchResult.Add(playerOne);
                return playerOne;
            }

            matchNewData.IdWinner = playerTwo.Id;
            matchNewData.IdLoser = playerOne.Id;

            _context.Set<Match>().Add(matchNewData);

            await _context.SaveChangesAsync();
            matchResult.Add(playerTwo);
            return playerTwo;
        }
    }
}


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

        private readonly TournamentContext _context;

        public MatchService(TournamentContext context)
        {
            _context = context;
        }



        public PlayerStatsResponse RestHabilitie(PlayerStatsResponse playerHabilitesRest)
        {
            playerHabilitesRest.Strenght -= 10;
            playerHabilitesRest.Speed -= 10;
            //playerHabilitesRest.Luck -= 10;

            return playerHabilitesRest;
        }
        public async Task<List<PlayerStatsResponse>> InitMatchAsync(List<PlayerStatsResponse> playerList)
        {

            var listResults = new List<PlayerStatsResponse>();

            Random rnd = new Random();
                

            ///  si entran 12 jugadores o 16 o mas se va a controlar en este ciclo
            ///  el bucle while me da jugadores1 y 2 siempre que la lista sea distinta de 0 
            ///  devolviendo una lista de ganadores 
             

            while (playerList.Count != 0)
            {
                var indiceJugador1 = rnd.Next(0, playerList.Count);
                var jugador1 = playerList[indiceJugador1];
                playerList.RemoveAt(indiceJugador1);

                var indiceJugador2 = rnd.Next(0, playerList.Count);
                var jugador2 = playerList[indiceJugador2];
                playerList.RemoveAt(indiceJugador2);

                var winnerOfMatch = await MatchGame(jugador1, jugador2);
                // le resto -10 a todo habilidad
                winnerOfMatch = RestHabilitie(winnerOfMatch);

                listResults.Add(winnerOfMatch);

            }
            return listResults;
        }

        // Este metodo  es interesante par usarlo de Gral para  todo el torneo 
        // se poddria  hacer diferente las habilidades y utilizarla según partido
        public async Task<PlayerStatsResponse> MatchGame(PlayerStatsResponse playerOne, PlayerStatsResponse playerTwo)
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

        public async Task<List<PlayerStatsResponse>> QuarterMatches(List<PlayerStatsResponse> playerList)
        {
            // Traer a los ganadores previos 
            var previousWinners = await InitMatchAsync(playerList);

            // Realizar una nueva ronda de partidos con los ganadores
            var quarterFinalWinners = await InitMatchAsync(previousWinners);

            // Aquí puedes hacer algo con los ganadores de los cuartos de final

            return quarterFinalWinners;
        }


        public async Task<List<PlayerStatsResponse>> SemiFinalMatches(List<PlayerStatsResponse> playerList)
        {
            var previousWinners = await QuarterMatches(playerList);

        // Realizar una nueva ronda de partidos con los ganadores
        var SemiFinalWinners = await InitMatchAsync(previousWinners);

            // Aquí puedes hacer algo con los ganadores de los cuartos de final

            return SemiFinalWinners;
        }

        public async Task<List<PlayerStatsResponse>> FinalMatche(List<PlayerStatsResponse> playerList)
        {
            var previousWinners = await SemiFinalMatches(playerList);

            // Realizar una nueva ronda de partidos con los ganadores
            var FinalMatche = await InitMatchAsync(previousWinners);

            // Aquí puedes hacer algo con los ganadores de los cuartos de final
            return FinalMatche;
        }
    }
}


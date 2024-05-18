using Contracts.DTO.Responses.Player;
using Contracts.DTO.Responses.Tournament;
using Contracts.Exceptions;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Services
{
    public class TournamentTesting
    {
        private readonly DbContextOptions<TournamentContext> _options;

        public TournamentTesting()
        {
            _options = new DbContextOptionsBuilder<TournamentContext>()
                .UseInMemoryDatabase(databaseName: "TournamentTestingDatabase")
                .Options;
        }

        private TournamentContext CreateContext()
        {
            var context = new TournamentContext(_options);

            return context;
        }

        private static void SeedDatabase(TournamentContext context)
        {
            context.Set<HistoryTournament>().Add(new HistoryTournament
            {
                Id = 1,
                IdPlayer = 1,
                Name = "Copa Pinturillo",
                Date = DateTime.Now
            }); 
            context.Set<HistoryTournament>().Add(new HistoryTournament
            {
                Id = 2,
                IdPlayer = 2,
                Name = "Copa Lagarto",
                Date = DateTime.Now
            });

            context.Set<Match>().Add(new Match
            {
                Id = 1,
                IdTournament = 1,
                IdWinner = 1,
                IdLoser = 2
            });

            context.Set<Player>().Add(new Player
            {
                Id = 1,
                Name = "Carlos",
                Luck = 50,
                Hability = 30,
                Strenght = 30,
                Speed = 20,
                TimeReaction = 20,
                Gender = "Male"
            });
            context.Set<Player>().Add(new Player
            {
                Id = 2,
                Name = "Emiliano",
                Luck = 50,
                Hability = 30,
                Strenght = 30,
                Speed = 20,
                TimeReaction = 20,
                Gender = "Male"
            });

            context.SaveChanges();
        }
        private static void ClearDatabase(TournamentContext context)
        {
            context.Set<HistoryTournament>().RemoveRange(context.Set<HistoryTournament>());
            context.Set<Match>().RemoveRange(context.Set<Match>());
            context.Set<Player>().RemoveRange(context.Set<Player>());

            context.SaveChanges();
        }
        private static void ClearDatabaseTournament(TournamentContext context)
        {
            context.Set<HistoryTournament>().RemoveRange(context.Set<HistoryTournament>());

            context.SaveChanges();
        }
        
        [Fact]
        public async Task GetDataTournamentAsync_ReturnTournamentResult()
        {
            // Arrange
            var context = CreateContext();
            
            ClearDatabase(context);
            SeedDatabase(context);
            
            var playerService = new PlayerService(context);
            var matchService = new MatchService(context);
            var tournamentService = new TournamentService(context, playerService, matchService);

            // Act
            var result = await tournamentService.GetDataTournamentByIdAsync(1);

            // Asserts
            Assert.IsType<TournamentResult>(result);
        }

        [Fact]
        public async Task GetDataTournamentAsync_ThrowNotFoundException()
        {
            // Arrange
            var context = CreateContext();

            ClearDatabase(context);
            SeedDatabase(context);

            var playerService = new PlayerService(context);
            var matchService = new MatchService(context);
            var tournamentService = new TournamentService(context, playerService, matchService);

            // Act && Asserts
            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await tournamentService.GetDataTournamentByIdAsync(100));
        }

        [Fact]
        public async Task SetChampion_ThrowNotFoundException()
        {
            // Arrange
            var context = CreateContext();

            ClearDatabase(context);
            SeedDatabase(context);
            ClearDatabaseTournament(context);

            var playerService = new PlayerService(context);
            var matchService = new MatchService(context);
            var tournamentService = new TournamentService(context, playerService, matchService);

            var newChampion = new PlayerStats
            {
                Id = 200,
                Name = "test",
                Luck = 10,
                Hability = 20,
                Strenght = 30,
                Speed = 20,
                TimeReaction = 30,
                Gender = "Male"
            };

            // Act && Asserts
            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await tournamentService.SetChampion(newChampion));
        }
    }
}

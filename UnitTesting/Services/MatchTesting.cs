using Azure.Core;
using Contracts.DTO.Responses.Player;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Services;


namespace UnitTesting.Services
{
    public class MatchTesting
    {
        private readonly DbContextOptions<TournamentContext> _context;

        public MatchTesting()
        {
            _context = new DbContextOptionsBuilder<TournamentContext>()
                   .UseInMemoryDatabase(databaseName: "Database")
                   .Options;
        }
        private TournamentContext CreateContext()
        {
            var context = new TournamentContext(_context);
            return context;
        }
        private static void SeedDatabase(TournamentContext context)
        {
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
            context.Set<Player>().Add(new Player
            {
                Id = 3,
                Name = "Jorge",
                Luck = 50,
                Hability = 30,
                Strenght = 30,
                Speed = 20,
                TimeReaction = 20,
                Gender = "Male"
            });
            context.Set<Player>().Add(new Player
            {
                Id = 4,
                Name = "Lucas",
                Luck = 50,
                Hability = 30,
                Strenght = 30,
                Speed = 20,
                TimeReaction = 20,
                Gender = "Male"
            });
            context.Set<Player>().Add(new Player
            {
                Id = 5,
                Name = "Lucrecia",
                Luck = 50,
                Hability = 30,
                Strenght = 30,
                Speed = 20,
                TimeReaction = 20,
                Gender = "Male"
            });
            context.Set<Player>().Add(new Player
            {
                Id = 6,
                Name = "Paola",
                Luck = 50,
                Hability = 30,
                Strenght = 30,
                Speed = 20,
                TimeReaction = 20,
                Gender = "Male"
            });
            context.Set<Player>().Add(new Player
            {
                Id = 7,
                Name = "Jorgelina",
                Luck = 50,
                Hability = 30,
                Strenght = 30,
                Speed = 20,
                TimeReaction = 20,
                Gender = "Male"
            });
            context.Set<Player>().Add(new Player
            {
                Id = 8,
                Name = "Fernando",
                Luck = 60,
                Hability = 35,
                Strenght = 40,
                Speed = 25,
                TimeReaction = 25,
                Gender = "Male"
            });

            var tournament = new HistoryTournament
            {
                Name = "Torneo de prueba",
                Date = DateTime.Now // Otra fecha que desees usar
            };

            context.Set<HistoryTournament>().Add(tournament);

            // mathc 
            //var matchOne = new Match
            //{

            //    IdTournament = 1,
            //    IdWinner = playerOne.Id,
            //    IdLoser = playerOne.Id,


            //};
            //context.Set<Match>().AddRange(matchOne);

            context.SaveChanges();
        }

        private static void ClearDatabase(TournamentContext context)
        {
            context.Set<Player>().RemoveRange(context.Set<Player>());
            context.SaveChanges();
        }
        [Fact]

        public async Task MatchGame_ReturnWinnerAndLoserOfMatch()
        {
            // arrg
            var context = CreateContext();
            ClearDatabase(context);
            SeedDatabase(context);
            var matchService = new MatchService(context);
            var playerList = context.Set<Player>().ToList();
            var playerOneEntity = playerList[0];
            var playerTwoEntity = playerList[1];
            var playerOne = new PlayerStats
            {
                Id = playerOneEntity.Id,
                Name = playerOneEntity.Name,
                Luck = playerOneEntity.Luck,
                Hability = playerOneEntity.Hability,
                Strenght = playerOneEntity.Strenght,
                Speed = playerOneEntity.Speed,
                TimeReaction = playerOneEntity.TimeReaction,
                Gender = playerOneEntity.Gender
            };
            var playerTwo = new PlayerStats
            {
                Id = playerTwoEntity.Id,
                Name = playerTwoEntity.Name,
                Luck = playerTwoEntity.Luck,
                Hability = playerTwoEntity.Hability,
                Strenght = playerTwoEntity.Strenght,
                Speed = playerTwoEntity.Speed,
                TimeReaction = playerTwoEntity.TimeReaction,
                Gender = playerTwoEntity.Gender
            };

            // act 

            var result = await matchService.MatchGame(playerOne, playerTwo);

            //result
            Assert.NotNull(result);
            Assert.Contains(result, new List<PlayerStats> { playerOne, playerTwo });



        }

        [Fact]
        public async Task InitMatchAsync_ReturnsWinner()
        {
            // Arrange
            var context = CreateContext();
            ClearDatabase(context);
            SeedDatabase(context);
            var matchService = new MatchService(context);
            var playerList = context.Set<Player>().Select(p => new PlayerStats
            {
                Id = p.Id,
                Name = p.Name,
                Luck = p.Luck,
                Hability = p.Hability,
                Strenght = p.Strenght,
                Speed = p.Speed,
                TimeReaction = p.TimeReaction,
                Gender = p.Gender
            }).ToList();


            // Act
            var result = await matchService.InitMatchAsync(playerList);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(result.Name, new List<string> { "Carlos", "Emiliano", "Jorge", "Lucas", "Lucrecia", "Paola", "Jorgelina","Fernando" });
        }

      

    }
}

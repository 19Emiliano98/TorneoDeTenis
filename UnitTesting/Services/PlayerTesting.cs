using Contracts.DTO.Responses.Player;
using Contracts.Exceptions;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Services;

namespace UnitTesting.Services
{
    public class PlayerTesting
    {
        private readonly DbContextOptions<TournamentContext> _options;

        public PlayerTesting()
        {
            _options = new DbContextOptionsBuilder<TournamentContext>()
                .UseInMemoryDatabase(databaseName: "Database")
                .Options;
        }

        private TournamentContext CreateContext()
        {
            var context = new TournamentContext(_options);

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
                Gender = "Female"
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
                Gender = "Female"
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
                Gender = "Female"
            });

            context.SaveChanges();
        }
        private static void ClearDatabase(TournamentContext context)
        {
            context.Set<Player>().RemoveRange(context.Set<Player>());
            context.SaveChanges();
        }

        [Fact]
        public async Task SetLuckAsync_ReturnsListPlayerStats()
        {
            // Arrange
            var context = CreateContext();
            ClearDatabase(context);
            SeedDatabase(context);
            var playerService = new PlayerService(context);
            var gender = "Male";

            // Act
            var result = await playerService.SetLuckAsync(gender);

            // Asserts
            Assert.IsType<List<PlayerStats>>(result);
        }

        [Fact]
        public async Task SetLuckAsync_ThrowNotFound()
        {
            // Arrange
            var context = CreateContext();
            ClearDatabase(context);
            SeedDatabase(context);
            var playerService = new PlayerService(context);
            var gender = "Uknown";

            // Act && Asserts
            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await playerService.SetLuckAsync(gender));
        }

        [Fact]
        public async Task SetLuckAsync_ThrowBadRequest()
        {
            // Arrange
            var context = CreateContext();

            ClearDatabase(context);
            SeedDatabase(context);
            var gender = "Female";

            var playersList = context.Set<Player>()
                                    .Where(x => x.Gender == gender)
                                    .ToList();

            var playerService = new PlayerService(context);

            // Act && Asserts
            var exception = await Assert.ThrowsAsync<BadRequestException>(async () => await playerService.SetLuckAsync(gender));
        }

        [Fact]
        public void CheckAmountOfPlayers_QuantityAcepted()
        {
            // Arrange
            var context = CreateContext();

            ClearDatabase(context);
            SeedDatabase(context);
            var gender = "Male";

            var playersList = context.Set<Player>()
                                    .Where(x => x.Gender == gender)
                                    .ToList();

            var playerService = new PlayerService(context);

            // Act
            var result = playerService.CheckAmountOfPlayers(playersList);

            // Asserts
            Assert.True(result);
        }

        [Fact]
        public void CheckAmountOfPlayers_QuantityIsNotAcepted()
        {
            // Arrange
            var context = CreateContext();

            ClearDatabase(context);
            SeedDatabase(context);
            var gender = "Female";

            var playersList = context.Set<Player>()
                                    .Where(x => x.Gender == gender)
                                    .ToList();

            var playerService = new PlayerService(context);

            // Act
            var result = playerService.CheckAmountOfPlayers(playersList);

            // Asserts
            Assert.False(result);
        }
    }
}

using Contracts.DTO.Requests;
using Contracts.DTO.Responses.Match;
using Contracts.DTO.Responses.Player;
using Contracts.DTO.Responses.Tournament;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Interfaces;
using WebAPI.Controllers;

namespace UnitTesting
{
    public class TournamentTesting
    {

        [Fact]
        public async Task GetAllAsync_ReturnsValue()
        {
            // Arrange
            var tournamentList = new List<TournamentGetAll>();
            var tournament = new TournamentGetAll
            {
                Id = 1,
                Name = "Copa Profes",
                Champion = "Emiliano",
                Date = DateTime.Now
            };
            tournamentList.Add(tournament);

            var mockServiceTournament = new Mock<ITournamentService>();
            mockServiceTournament.Setup(service => service.GetAllTournamentsAsync()).ReturnsAsync(tournamentList);

            var controller = new TournamentController(mockServiceTournament.Object);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            var returnValue = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsType<List<TournamentGetAll>>(returnValue.Value);

            Assert.Equal("Copa Profes", returnProduct[0].Name);
            Assert.Equal("Emiliano", returnProduct[0].Champion);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsNotFound()
        {
            // Arrange
            var mockServiceTournament = new Mock<ITournamentService>();
            mockServiceTournament.Setup(service => service.GetAllTournamentsAsync()).ReturnsAsync(new List<TournamentGetAll>());

            var controller = new TournamentController(mockServiceTournament.Object);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async Task GetTournamentById_ReturnsValue()
        {
            // Arrange
            var matchsList = new List<MatchData>();
            var match = new MatchData { Id = 1, Winner = "Emiliano", Loser = "Juan" };
            matchsList.Add(match);

            var tournament = new TournamentResult
            {
                Name = "Copa Profes",
                Date = DateTime.Now,
                Champion = "Emiliano",
                MatchsPlayed = matchsList
            };

            var mockServiceTournament = new Mock<ITournamentService>();
            mockServiceTournament.Setup(service => service.GetDataTournamentAsync(1)).ReturnsAsync(tournament);

            var controller = new TournamentController(mockServiceTournament.Object);

            // Act
            var result = await controller.GetTournamentByIdAsync(1);

            // Assert
            var returnValue = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsType<TournamentResult>(returnValue.Value);

            Assert.Equal("Copa Profes", returnProduct.Name);
            Assert.Equal("Emiliano", returnProduct.Champion);
            Assert.Equal(matchsList, returnProduct.MatchsPlayed);
        }

        [Fact]
        public async Task GetTournamentById_ReturnsNotFound()
        {
            // Arrange
            var mockServiceTournament = new Mock<ITournamentService>();
            mockServiceTournament.Setup(service => service.GetDataTournamentAsync(2)).ReturnsAsync((TournamentResult)null);

            var controller = new TournamentController(mockServiceTournament.Object);

            // Act
            var result = await controller.GetTournamentByIdAsync(2);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task InitTournament_CreateTournament_ReturnsChampion()
        {
            // Arrange
            var initTournamentRequest = new InitTournamentRequest
            {
                TournamentName = "Copa UnitTesting",
                TournamentGenderOfPlayers = "Male"
            };

            var champion = new PlayerStats
            {
                Id = 1,
                Name = "Carlos",
                Luck = 50,
                Hability = 30,
                Strenght = 30,
                Speed = 20,
                TimeReaction = 20,
                Gender = "Male"
            };

            var mockServiceTournament = new Mock<ITournamentService>();
            mockServiceTournament.Setup(service => service.InitTournamentMicroService(initTournamentRequest)).ReturnsAsync(champion);

            var controller = new TournamentController(mockServiceTournament.Object);

            // Act
            var result = await controller.InitTournament(initTournamentRequest);

            // Assert
            var okObjectValue = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<PlayerStats>(okObjectValue.Value);

            Assert.Equal("Carlos", value.Name);
            Assert.Equal("Male", value.Gender);
        }
    }
}

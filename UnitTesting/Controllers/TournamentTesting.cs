using Contracts.DTO.Responses.Match;
using Contracts.DTO.Responses.Tournament;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Interfaces;
using WebAPI.Controllers;

namespace UnitTesting.Controllers
{
    public class TournamentTesting
    {

        [Fact]
        public async Task GetTournamentById_ReturnsObject()
        {
            // Arrange
            var matchsList = new List<MatchData>();
            var match = new MatchData { Id = 1, Winner = "Emiliano", Loser = "Juan" };
            matchsList.Add(match);

            var mockServiceTournament = new Mock<ITournamentService>();
            var tournament = new TournamentResult 
            { 
                Name = "Copa Profes",
                Date = DateTime.Now,
                Champion = "Emiliano",
                MatchsPlayed = matchsList
            };
            
            mockServiceTournament.Setup(service => service.GetDataTournamentAsync(1)).ReturnsAsync(tournament);

            var controller = new TournamentController(mockServiceTournament.Object);

            // Act
            var result = await controller.GetTournamentByIdAsync(1);

            // Assert
            var returnValue = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsType<TournamentResult>(returnValue.Value);

            Assert.Equal("Copa Profes", returnProduct.Name);
            Assert.Equal("Emiliano", returnProduct.Champion);
        }
    }
}

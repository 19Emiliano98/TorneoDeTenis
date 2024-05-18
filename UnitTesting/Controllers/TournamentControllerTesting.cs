﻿using Contracts.DTO.Requests;
using Contracts.DTO.Responses.Match;
using Contracts.DTO.Responses.Player;
using Contracts.DTO.Responses.Tournament;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Interfaces;
using WebAPI.Controllers;

namespace UnitTesting.Controllers
{
    public class TournamentControllerTesting
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
            mockServiceTournament.Setup(service => service.GetDataTournamentByIdAsync(1)).ReturnsAsync(tournament);

            var controller = new TournamentController(mockServiceTournament.Object);

            // Act
            var result = await controller.GetTournamentByIdAsync(1);

            // Assert
            var returnValue = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsType<TournamentResult>(returnValue.Value);
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
        }
    }
}
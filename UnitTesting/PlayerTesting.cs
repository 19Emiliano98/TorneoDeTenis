using Contracts.Exceptions;
using Data.Entities;
using Data.Repository;
using Moq;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class PlayerTesting
    {
        // No utilizo Moq por el simple hecho de que no me permite trabajar con 
        // la DB, podria utilizar la libreria inMemory para simular una DB y hacerlo
        // mucho mas dinamico pero para este proyecto al ser chico no es necesario

        private readonly TournamentContext? _context;
        private readonly PlayerService _playerService;

        public PlayerTesting()
        {
            _playerService = new PlayerService(_context);
        }

        [Fact]
        public void SetLuckAsync_ThrowNotFound()
        {
            // Arrange
            var gender = "Unknown";

            // Act && Asserts
            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await _playerService.SetLuckAsync(gender));
        }

        [Fact]
        public void CheckAmountOfPlayers_QuantityAcepted()
        {
            // Arrange
            var playersList = new List<Player>();
            var player = new Player
            {
                Id = 1,
                Name = "Emiliano",
                Luck = 40,
                Hability = 20,
                Strenght = 50,
                Speed = 40,
                TimeReaction = 30,
                Gender = "Male"
            };

            for (int i = 0; i < 8; i++)
            {
                playersList.Add(player);
            }

            // Act
            var result = _playerService.CheckAmountOfPlayers(playersList);

            // Asserts
            Assert.True(result);
        }

        [Fact]
        public void CheckAmountOfPlayers_QuantityIsNotAcepted()
        {
            // Arrange
            var playersList = new List<Player>();
            var player = new Player
            {
                Id = 1,
                Name = "Emiliano",
                Luck = 40,
                Hability = 20,
                Strenght = 50,
                Speed = 40,
                TimeReaction = 30,
                Gender = "Male"
            };

            for (int i = 0; i < 3; i++)
            {
                playersList.Add(player);
            }

            // Act
            var result = _playerService.CheckAmountOfPlayers(playersList);

            // Asserts
            Assert.False(result);
        }
    }
}

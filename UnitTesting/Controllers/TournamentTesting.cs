using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using Services.Services;
using WebAPI.Controllers;

namespace UnitTesting.Controllers
{
    public class TournamentTesting
    {
        private readonly TournamentController _controller;
        private readonly ITournamentService _tournamentService;

        public TournamentTesting()
        {
            _tournamentService = new TournamentService();
            _controller = new TournamentController(_tournamentService);
        }

        //[Fact]
        //public void GetAllAsync_Ok()
        //{
        //    var result = _controller.GetAllAsync();

        //    Assert.IsType<Task<IActionResult>>(result);
        //}

        [Fact]
        public async void GetAllAsync_Ok()
        {
            var result = await _controller.GetAllAsync();

            Assert.IsType<OkObjectResult>(result);
            
        }
    }
}

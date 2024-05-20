using Contracts.DTO.Responses;
using Contracts.DTO.Responses.JwtResponse;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Interfaces.User;
using WebAPI.Controllers;

namespace UnitTesting.Controllers
{
    public class UserControllerTesting
    {
        [Fact]
        public async Task CreateUser()
        {
            // Arrange
            var newUser = new UserRequest
            {
                UserName = "Carlitos@gmail.com",
                Password = "Parafraseo"
            };

            var mockServiceUser = new Mock<IUserService>();
            var authenticationService = new Mock<IAuthenticationServices>();

            mockServiceUser.Setup(service => service.CreateUserAsync(newUser));

            var controller = new UserController(mockServiceUser.Object, authenticationService.Object);

            // act 
            var result = await controller.CreateUserAsync(newUser);
            
            // Assert
            var returnValue = Assert.IsType<OkObjectResult>(result);
            var returnResponse = Assert.IsType<string>(returnValue.Value);

        }
        
        [Fact]
        public async Task LoginUser()
        {
            // Arrange
            var loginUser = new UserRequest
            {
                UserName = "Patatita@arbitro.com",
                Password = "Patatita"
            };

            var expectedUser = new Users
            {
                Name = "Patatita@arbitro.com",
                Password = "Patatita"
            };

            var expectedTokenResponse = new TokenResponse
            {
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjE2IiwidW5pcXVlX25hbWUiOiJQYXRhdGl0YUBhcmJpdHJvLmNvbSIsIlJvbGUiOiJhcmJpdHJvIiwiZXhwIjoxNzE1NzMyMjE8LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdCJ9.qZtBOiM0xC4XuGfZaAVuL0c0TxuQ9vT3VdxScTzdRW4",
                ExpirationToken = DateTime.Parse("2024-05-15T00:16:58.2299383Z"),
                RefreshToken = "qjjEkELkiuzVotGHoCTes0Kakp1eNXEyKNcNsQ/fNo0=",
                RefreshTokenExpiration = DateTime.Parse("2024-05-15T00:31:58.2299847Z")
            };

            var mockService = new Mock<IUserService>();
            var authenticationService = new Mock<IAuthenticationServices>();

  
            mockService.Setup(s => s.UserValidationAsync(loginUser)).ReturnsAsync(expectedUser);
            authenticationService.Setup(a => a.GenerateToken(expectedUser)).Returns(expectedTokenResponse);

            var controller = new UserController(mockService.Object, authenticationService.Object);

            // Act
            var result = await controller.LoginAsync(loginUser);

            // Assert
            var returnValue = Assert.IsType<OkObjectResult>(result);
            var returnResponse = (TokenResponse)returnValue.Value;

            Assert.Equal(expectedTokenResponse.Token, returnResponse.Token);
            Assert.Equal(expectedTokenResponse.ExpirationToken, returnResponse.ExpirationToken);
            Assert.Equal(expectedTokenResponse.RefreshToken, returnResponse.RefreshToken);
            Assert.Equal(expectedTokenResponse.RefreshTokenExpiration, returnResponse.RefreshTokenExpiration);
        }
    }
}

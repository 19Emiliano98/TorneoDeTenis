using Contracts.DTO.Responses;
using Data.Entities;

namespace Services.Interfaces.User
{
    public interface IUserService
    {
        Task<Users> UserValidationAsync(UserRequest user);
        Task CreateUserAsync(UserRequest user);
        Task<Users> GetUserByRefreshToken(string refreshToken);
    }
}

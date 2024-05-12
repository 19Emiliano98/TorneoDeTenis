using Contracts.DTO.Responses;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.User
{
    public interface IUserService
    {
        Task<Users> UserValidationAsync(UserRequest user);
        Task CreateUserAsync(UserRequest user);
        Task<Users> GetUserByRefreshToken(string refreshToken);
    }
}

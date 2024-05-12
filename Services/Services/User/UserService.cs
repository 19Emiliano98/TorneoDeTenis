using Contracts.DTO.Responses;
using Contracts.DTO.Responses.JwtResponse;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.User;

namespace Services.Services.User
{
    public class UserService : IUserService
    {
        private readonly TournamentContext _context;
        private readonly IEncryptionService _encryptionService;

        public UserService(TournamentContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;

        }

        public async Task CreateUserAsync(UserRequest user)
        {
            var User = await _context.Set<Users>()
                                    .FirstOrDefaultAsync(u => u.Name.Equals(user.UserName));

            if (User != null)
            {
                throw new Exception("El usuario ya existe");
            }

            var newUser = new Users
            {
                Name = user.UserName,
                Password = _encryptionService.Encrypt(user.Password)
            };

            _context.Add(newUser);

            await _context.SaveChangesAsync();
        }

        public Task<Users> GetUserByRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> UserValidationAsync(UserRequest user)
        {
            var passDescrypt = _encryptionService.Decrypt(user.Password);

            var users = await _context.Set<Users>()
                                    .FirstOrDefaultAsync(u => u.Name.Equals(user.UserName) && u.Password.Equals(passDescrypt));

            return users;
        }
    }
}

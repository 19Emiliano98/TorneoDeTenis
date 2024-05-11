using Contracts.DTO.Responses;
using Contracts.Mappers;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            Users newUser = user.ToUser();
            newUser.Password = _encryptionService.Encrypt(user.Password);


            // condicion
            _context.Add(newUser);
            await _context.SaveChangesAsync();

            //return newUser;



        }

        public Task<Users> GetUserByRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> UserValidationAsync(UserRequest user)
        {
            var passDescrypt = _encryptionService.Decrypt(user.Password);

            var users = await _context.Set<Users>()
            .FirstOrDefaultAsync(u => u.Name.Equals(user.UserName) &&
              u.Password.Equals(passDescrypt));
                    
            // validacion de null  ?

            return users;


        }
    }
}

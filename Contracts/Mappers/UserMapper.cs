using Contracts.DTO.Responses;
using Data.Entities;

namespace Contracts.Mappers
{
    public static class UserMapper
    {
        public static Users ToUser(this UserRequest request)
        {
            return new Users
            {
                Name = request.UserName,
                Password = request.Password,
            };

        }
    }
}

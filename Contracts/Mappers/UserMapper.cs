using Contracts.DTO.Responses;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

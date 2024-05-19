using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Responses.JwtResponse
{
    public class UserResponse
    {

        public string UserName { get; set; }

        public string Password { get; set; }

      

    }
}

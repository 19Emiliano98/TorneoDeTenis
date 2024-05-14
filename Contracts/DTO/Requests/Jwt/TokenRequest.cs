using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Requests.Jwt
{
    public class TokenRequest
    {
        public string Name { get; set; }
        public string RefreshToken { get; set; }
    }
}

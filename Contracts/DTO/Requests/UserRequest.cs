using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Contracts.DTO.Responses
{
    public class UserRequest
    {
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }
        
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}

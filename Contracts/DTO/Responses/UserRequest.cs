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
        [DefaultValue("@gmail.com")]

        public string UserName { get; set; }


    
        [DefaultValue("")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z]).*$", 
            ErrorMessage = "La contraseña debe tener al menos una mayúscula y una minúscula.")]

        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

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

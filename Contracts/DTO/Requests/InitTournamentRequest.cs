using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Requests
{
    public class InitTournamentRequest
    {
        [MinLength(5)]
        [MaxLength(30)]
        public string TournamentName { get; set; }
        
        [Required]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "El género debe ser 'Male' o 'Female'.")]
        public string TournamentGenderOfPlayers { get; set; }
    }
}

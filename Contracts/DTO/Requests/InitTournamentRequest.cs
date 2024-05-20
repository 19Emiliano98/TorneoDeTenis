using System.ComponentModel.DataAnnotations;

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

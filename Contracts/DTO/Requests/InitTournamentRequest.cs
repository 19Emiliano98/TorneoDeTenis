using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Requests
{
    public class InitTournamentRequest
    {
        public string TournamentName { get; set; }
        public string TournamentGenderOfPlayers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Responses.Player
{
    public class PlayerMatchesResponse
    {
        //public int IdTournament { get; set; }
        public int? IdWinner { get; set; }
        public string WinnerName { get; set; }

        public int? IdLoser { get; set; }
        public string LoserName { get; set; }
    }
}

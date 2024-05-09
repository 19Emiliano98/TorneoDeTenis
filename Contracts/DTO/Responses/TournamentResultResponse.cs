using DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Responses
{
    public class TournamentResultResponse
    {
        public int? IdPlayer { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        //public List<PlayerMatchesResponse> PlayerMatches { get; set; }
        public PlayerStatsResponse DataPlayer { get; set; }
    }
}

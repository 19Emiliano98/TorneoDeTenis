using Contracts.DTO.Responses.Match;
using Contracts.DTO.Responses.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Responses.Tournament
{
    public class TournamentResultResponse
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public PlayerInfo Champion { get; set; }
        public List<MatchData> MatchsPlayed { get; set; }
    }
}

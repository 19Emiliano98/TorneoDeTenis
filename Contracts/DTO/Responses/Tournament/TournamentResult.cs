using Contracts.DTO.Responses.Match;

namespace Contracts.DTO.Responses.Tournament
{
    public class TournamentResult
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Champion { get; set; }
        public List<MatchData> MatchsPlayed { get; set; }
    }
}

namespace Contracts.DTO.Responses.Tournament
{
    public class TournamentGetAll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Champion { get; set; }
        public DateTime Date { get; set; }
    }
}

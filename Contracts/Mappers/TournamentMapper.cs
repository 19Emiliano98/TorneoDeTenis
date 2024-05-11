using Contracts.DTO.Responses.Tournament;
using Data.Entities;

namespace Contracts.Mappers
{
    public static class TournamentMapper
    {
        public static TournamentGetAll ToPlayerStatsResponse(this HistoryTournament data)
        {
            return new TournamentGetAll()
            {
                Id = data.Id,
                Name = data.Name,
                Champion = data.IdPlayerForeignKey.Name,
                Date = data.Date
            };
        }
    }
}

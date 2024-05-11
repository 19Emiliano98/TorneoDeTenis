using Contracts.DTO.Responses.Player;

namespace Services.Interfaces
{
    public interface IMatchService
    {
        Task<PlayerStats> InitMatchAsync(List<PlayerStats> playerList);
        Task<PlayerStats> MatchGame(PlayerStats playerOne, PlayerStats playerTwo);
    }
}

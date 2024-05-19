using Contracts.DTO.Responses.Player;
using Data.Entities;

namespace Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<PlayerStats>> SetLuckAsync(string gender);
        bool CheckAmountOfPlayers(List<Player> playersList);
    }
}

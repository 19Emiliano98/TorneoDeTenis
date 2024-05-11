using Contracts.DTO.Responses.Player;

namespace Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<PlayerStats>> SetLuckAsync(string gender);
    }
}

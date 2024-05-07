using DTO.Responses;

namespace Services.Interfaces
{
    public interface IPlayerService
    {
        //List<List<Player> GetPlayers();
        Task<List<PlayerStatsResponse>> SetLuckAsync();
        // a aplicar
        //Task<List<PlayerStatsResponse>> SetBadLuckAsync();



    }
}

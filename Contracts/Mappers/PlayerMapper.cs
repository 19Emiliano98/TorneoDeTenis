using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.DTO.Responses.Player;
using Data.Entities;

namespace Contracts.Mappers
{
    public static class PlayerMapper
    {
        public static PlayerStatsResponse ToPlayerStatsResponse(this Player data)
        {
            return new PlayerStatsResponse()
            {
                Id = data.Id,
                Name = data.Name,
                Luck = data.Luck,
                Hability = data.Hability,
                Strenght = data.Strenght,
                Speed = data.Speed,
            };
        }
    }
}

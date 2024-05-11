using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.DTO.Responses.Player;
using Data.Entities;

namespace Contracts.Mappers
{
    public static class PlayerMapper
    {
        public static PlayerStats ToPlayerStatsResponse(this Player data)
        {
            return new PlayerStats()
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

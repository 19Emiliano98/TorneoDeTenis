using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using DTO.Responses;

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
                Strenght = data.Strenght,
                Speed = data.Speed
            };
        }
    }
}

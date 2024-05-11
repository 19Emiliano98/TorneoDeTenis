
using Contracts.DTO.Requests;
using Contracts.DTO.Responses;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.DTO.Responses.Player;

namespace Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<PlayerStats>> SetLuckAsync(string gender);
    }
}

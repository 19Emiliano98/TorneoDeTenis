using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Player>> SetLuckAsync();
    }
}

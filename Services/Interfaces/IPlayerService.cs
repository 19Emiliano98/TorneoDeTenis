
﻿using Contracts.DTO.Requests;
using Contracts.DTO.Responses;
using Data.Entities;
using DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using DTO.Responses;

namespace Services.Interfaces
{
    public interface IPlayerService
    {
     
        Task<List<PlayerStatsResponse>> SetLuckAsync();

    }
}

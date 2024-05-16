﻿using Contracts.DTO.Requests.Jwt;
using Contracts.DTO.Responses.JwtResponse;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.User
{
    public interface IAuthenticationServices
    {
        Task<TokenResponse> generateToken(Users user);

        Task UpdateRefreshToken(Users userFromDB, string refreshToken);

        public string GenerateRefreshToken();
    }
}

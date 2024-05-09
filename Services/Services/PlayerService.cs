﻿using Contracts.DTO.Requests;
using Contracts.DTO.Responses;
using Contracts.DTO.Responses.Player;
using Contracts.Exceptions;
using Contracts.Mappers;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Interfaces;

namespace Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly TournamentContext _context;

        public PlayerService(TournamentContext tournamentContext)
        {
            _context = tournamentContext;

        }

        public async Task<List<PlayerStatsResponse>> SetLuckAsync()
        {
            var playersList = await _context.Set<Player>().ToListAsync();
            
            var playerResponseList = new List<PlayerStatsResponse>();
            var random = new Random();

            foreach (var player in playersList)
            {

                player.Luck = random.Next(0, 101);
                //player.Luck = random.Next(20, 30);

                // tiro un nro random 0 u 1 
                // si es dos se sumaria la la luck 
              
                _context.Set<Player>().Update(player);

                var playerResponse = player.ToPlayerStatsResponse();

                playerResponseList.Add(playerResponse);

            }

            await _context.SaveChangesAsync();

            return playerResponseList;
        }


    }
}

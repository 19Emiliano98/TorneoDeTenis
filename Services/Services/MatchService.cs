using Data.Repository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MatchService : IMatchService
    {

        private readonly TournamentContext _context;

        public MatchService(TournamentContext context)
        {
            _context = context;
        }


    }
}

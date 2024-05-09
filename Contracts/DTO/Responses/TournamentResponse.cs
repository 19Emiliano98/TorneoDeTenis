using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Responses
{
    public class TournamentResponse
    {
        public PlayerInfo DataPlayer { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}

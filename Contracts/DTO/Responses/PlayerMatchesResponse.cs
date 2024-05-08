using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Responses
{
    public class PlayerMatchesResponse
    {
        // la idea de esta response es generar un bingo de jugadores para el torneo 
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public int Luck { get; set; }
        //public int Strenght { get; set; }
        //public int Speed { get; set; }
        //public int Hability { get; set; }

        public int IdTournament { get; set; }
        public int? IdWinner { get; set; }
        public int? IdLoser { get; set; }


    }
}

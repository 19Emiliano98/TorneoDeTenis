using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int IdWinner { get; set; }
        public int IdLoser { get; set; }
    }
}

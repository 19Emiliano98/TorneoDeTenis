using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class MatchHistory
    {
        public int Id { get; set; }
        public int IdTournament { get; set; }
        public int IdMatch { get; set; }
    }
}

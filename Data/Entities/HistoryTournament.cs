using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class HistoryTournament
    {
        public int Id { get; set; }
        public int IdPlayer { get; set; }
        public int IdHistoryMatch { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}

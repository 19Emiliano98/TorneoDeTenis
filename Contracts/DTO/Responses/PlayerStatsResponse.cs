using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Responses
{
    public class PlayerStatsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Luck { get; set; }
        public int Hability { get; set; }
        public int Strenght { get; set; }
        public int Speed { get; set; }
    }


}

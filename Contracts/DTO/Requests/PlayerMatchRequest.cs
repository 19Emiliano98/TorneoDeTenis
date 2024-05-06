using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Requests
{
    public class PlayerMatchRequest
    {
        public string Name { get; set; }
        public int Luck { get; set; }
        public int Strenght { get; set; }
        public int Speed { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Responses
{
    public class PlayerInfo
    {
        public string Name { get; set; }
        public int? Luck { get; set; }
        public int Hability { get; set; }
        public int Strenght { get; set; }
        public int Speed { get; set; }
    }
}

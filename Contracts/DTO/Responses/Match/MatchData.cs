﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.Responses.Match
{
    public class MatchData
    {
        public int Id { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }
    }
}

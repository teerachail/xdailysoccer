﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GetMatchesRespond
    {
        public DateTime CurrentDate { get; set; }
        public AccountInformation AccountInfo { get; set; }
        public IEnumerable<MatchInformation> Matches { get; set; }
    }
}

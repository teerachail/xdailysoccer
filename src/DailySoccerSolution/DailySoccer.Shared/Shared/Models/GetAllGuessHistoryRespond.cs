﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GetAllGuessHistoryRespond
    {
        public IEnumerable<GuessHistoryMonthlyInformation> Histories { get; set; }
    }
}

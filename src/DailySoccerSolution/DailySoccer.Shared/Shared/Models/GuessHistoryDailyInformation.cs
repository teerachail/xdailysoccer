using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GuessHistoryDailyInformation
    {
        public DateTime Day { get; set; }
        public int TotalPoints { get; set; }
        public IEnumerable<MatchInformation> Matches { get; set; }
    }
}

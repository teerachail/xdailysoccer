using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GetGuessHistoryByMonthRequest
    {
        public string UserId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}

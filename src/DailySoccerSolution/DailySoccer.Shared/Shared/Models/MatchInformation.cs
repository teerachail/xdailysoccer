using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class MatchInformation
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public string LeagueName { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? CalculatedDate { get; set; }
        public string Status { get; set; }
        public TeamInformation TeamHome { get; set; }
        public TeamInformation TeamAway { get; set; }
    }
}

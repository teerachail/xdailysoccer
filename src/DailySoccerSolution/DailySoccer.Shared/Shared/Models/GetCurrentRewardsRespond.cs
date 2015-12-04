using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GetCurrentRewardsRespond
    {
        public int TicketCost { get; set; }
        public IEnumerable<RewardInformation> Rewards { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GetYourRewardsRespond
    {
        public string ContactNo { get; set; }
        public IEnumerable<YourRewardInformation> CurrentRewards { get; set; }
        public IEnumerable<YourRewardInformation> AllRewards { get; set; }
    }
}

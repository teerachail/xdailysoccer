using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class RewardGroupInformation
    {
        public int Id { get; set; }
        public int RequestPoints { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public IEnumerable<RewardInformation> RewardInfo { get; set; }
    }
}

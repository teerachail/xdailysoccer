using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class BuyTicketRespond
    {
        public AccountInformation AccountInfo { get; set; }
        public bool IsSuccessed { get; set; }
        public DateTime RewardResultDate { get; set; }
    }
}

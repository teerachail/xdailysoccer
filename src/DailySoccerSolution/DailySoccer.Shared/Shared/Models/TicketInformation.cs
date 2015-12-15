using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class TicketInformation
    {
        public int Id { get; set; }
        public Nullable<DateTime> ManualSelectedDate { get; set; }
        public Nullable<DateTime> RandomSelectedDate { get; set; }
        public Nullable<DateTime> ApproveWinnerDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RewardGroupId { get; set; }
        public int AccountId { get; set; }
        public Nullable<int> SelectedRewardId { get; set; }
    }
}

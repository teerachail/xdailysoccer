using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GetSelectedTicketRespond
    {
        public int RewardRemainingAmount { get; set; }
        public int TicketAmount { get; set; }
        public IEnumerable<TicketInformation> SelectedTicket { get; set; }
    }
}

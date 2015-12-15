using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GetSelectedTicketRespond
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardRemainingAmount { get; set; }
        public int TicketAmount { get; set; }
        public IEnumerable<TicketRespond> AllTicket { get; set; }
        public IEnumerable<TicketRespond> SelectedTicket { get; set; }
    }
}

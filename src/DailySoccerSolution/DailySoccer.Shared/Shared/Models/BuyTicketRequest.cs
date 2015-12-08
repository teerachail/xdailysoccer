using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class BuyTicketRequest
    {
        public string UserId { get; set; }
        public int amount { get; set; }
    }
}

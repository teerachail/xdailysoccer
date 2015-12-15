using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class TicketRespond
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public bool IsManualSelected { get; set; }
        public bool IsRandomSelected { get; set; }
        public bool IsApproveWinner { get; set; }
    }
}

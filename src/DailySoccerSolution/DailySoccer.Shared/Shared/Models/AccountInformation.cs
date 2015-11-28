using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class AccountInformation
    {
        public int Points { get; set; }
        public int RemainingGuessAmount { get; set; }
        public int CurrentOrderedCoupon { get; set; }
    }
}

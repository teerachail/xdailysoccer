using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class AccountInformation
    {
        public string SecrectCode { get; set; }
        public int Points { get; set; }
        public int MaximumGuessAmount { get; set; }
        public int CurrentOrderedCoupon { get; set; }
    }
}

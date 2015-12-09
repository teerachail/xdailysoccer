using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class AccountInformation
    {
        public string SecretCode { get; set; }
        public string OAuthId { get; set; }
        public string Email { get; set; }
        public string VerifiedPhoneNumber { get; set; }
        public int Points { get; set; }
        public int MaximumGuessAmount { get; set; }
        public int CurrentOrderedCoupon { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class VerificationPhoneInformation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string VerificationCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class ConfirmPhoneNumberRequest
    {
        public string UserId { get; set; }
        public string VerificationCode { get; set; }
    }
}

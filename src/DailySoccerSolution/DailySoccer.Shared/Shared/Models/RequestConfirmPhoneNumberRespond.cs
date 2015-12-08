using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class RequestConfirmPhoneNumberRespond
    {
        public bool IsSuccessed { get; set; }
        public string VerificationCode { get; set; }
        public string ForPhoneNumber { get; set; }
    }
}

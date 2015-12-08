using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class RequestConfirmPhoneNumberRequest
    {
        public string UserId { get; set; }
        public string PhoneNo { get; set; }
    }
}

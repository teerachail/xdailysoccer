using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class PhoneVerificationFacade
    {
        private ISMSSender _smsSender;
        public PhoneVerificationFacade(ISMSSender phoneVerification)
        {
            _smsSender = phoneVerification;
        }

        public void SendMessage(string phoneNumber, string message)
        {
            _smsSender.Send(phoneNumber, message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace DailySoccer.Shared.Facades
{
    public class TwilioSMSSender : ISMSSender
    {
        public void Send(string sentToPhoneNumber, string message)
        {
            const string accountSID = "AC093f1fcab483e85f464f14cff2581837";
            const string authToken = "86d01be3ddba43100cb5d6641fd3848c";
            var client = new TwilioRestClient(accountSID, authToken);

            const string SentFromPhoneNumber = "+15165709060";
            var result = client.SendMessage(SentFromPhoneNumber, sentToPhoneNumber, message);

            if (result.RestException != null)
            {
                string errorMessage = result.RestException.Message;
            }
        }
    }
}

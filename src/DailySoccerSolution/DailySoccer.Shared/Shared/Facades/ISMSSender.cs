using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public interface ISMSSender
    {
        void Send(string sentToPhoneNumber, string message);
    }
}

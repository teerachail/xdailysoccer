using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.DAC
{
    public interface ITicketDataAccess
    {
        void BuyTicket(string secrectCode, int amount, int rewardGroup);
        IEnumerable<TicketInformation> GetTicketByRewardGroupId(int rewardGroupId);
        IEnumerable<TicketInformation> GetTicketBySelectedRewardId(int selectedRewardId);
    }
}

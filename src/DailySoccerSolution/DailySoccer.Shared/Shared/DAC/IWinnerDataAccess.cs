using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.DAC
{
    public interface IWinnerDataAccess
    {
        void SelectTicket(int rewardId, int ticketId, DateTime selectedDate);
        void CancelSelectedTicket(int rewardId, int ticketId);
        void SubmitSelectedWinner(int rewardId, DateTime approveDate);
    }
}

using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class WinnerFacade
    {
        public GetSelectedTicketRespond GetSelectedTicket(int rewardId)
        {
            var winnerdDac = FacadeRepository.Instance.WinnerDataAccess;
            return winnerdDac.GetSelectedTicket(rewardId);
        }

        public void SelectTicket(int rewardId, int ticketId, DateTime selectedDate)
        {
            var winnerdDac = FacadeRepository.Instance.WinnerDataAccess;
            winnerdDac.SelectTicket(rewardId, ticketId, selectedDate);
        }

        public void CancelSelectedTicket(int rewardId, int ticketId)
        {
            var winnerdDac = FacadeRepository.Instance.WinnerDataAccess;
            winnerdDac.CancelSelectedTicket(rewardId, ticketId);
        }

        public void SubmitSelectedWinner(int rewardId)
        {
            var winnerdDac = FacadeRepository.Instance.WinnerDataAccess;
            winnerdDac.SubmitSelectedWinner(rewardId);
        }
    }
}

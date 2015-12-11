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
    }
}

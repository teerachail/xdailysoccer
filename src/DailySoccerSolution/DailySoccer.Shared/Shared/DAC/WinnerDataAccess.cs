using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailySoccer.Shared.Models;

namespace DailySoccer.Shared.DAC
{
    public class WinnerDataAccess : IWinnerDataAccess
    {
        public GetSelectedTicketRespond GetSelectedTicket(int rewardId)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedReward = dctx.Rewards.FirstOrDefault(it => it.Id == rewardId);
                var selectedTicket = dctx.Tickets.Where(it => it.RewardGroupId == selectedReward.RewardGroupId);
                var selectedWinner = dctx.Tickets.Where(it => it.RewardGroupId == selectedReward.RewardGroupId
                                                          && (it.ManualSelectedDate.HasValue || it.RandomSelectedDate.HasValue));

                var ticketInfo = new List<TicketInformation>();
                if (selectedTicket != null)
                {
                    ticketInfo = (from ticket in selectedWinner
                                  let account = dctx.Accounts.FirstOrDefault(it => it.Id == ticket.AccountId)
                                  select new TicketInformation
                                  {
                                      Id = ticket.Id,
                                      IsManualSelected = ticket.ManualSelectedDate.HasValue,
                                      IsRandomSelected = ticket.RandomSelectedDate.HasValue
                                  }).ToList();
                } 

                return new GetSelectedTicketRespond()
                {
                    RewardRemainingAmount = selectedReward.RemainingAmount.Value,
                    TicketAmount = selectedTicket.Count(),
                    SelectedTicket = ticketInfo
                };
            }
        }
    }
}

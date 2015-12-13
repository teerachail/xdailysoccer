using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailySoccer.Shared.Models;
using DailySoccer.DAC.EF;

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
                var selectedWinner = dctx.Tickets.Where(it => it.SelectedRewardId == rewardId);
               

                var rewardRemainingAmount = selectedReward.Amount - selectedWinner.Count();
                var ticketAmount = selectedTicket.Count() - selectedWinner.Count();

                var ticketInfo = new List<TicketInformation>();
                var allowSelectTicket = new List<TicketInformation>();
                if (selectedTicket != null)
                {
                    var allTicketUnSelected = selectedTicket.Where(it => it.SelectedRewardId == null && it.Account.GuestAccounts.Any());
                    ticketInfo = (from ticket in selectedWinner.OrderBy(it => it.ApproveWinnerDate)
                                  let account = dctx.Accounts.FirstOrDefault(it => it.Id == ticket.AccountId)
                                  select new TicketInformation
                                  {
                                      Id = ticket.Id,
                                      DisplayName = account.VerifiedPhoneNumber,
                                      IsManualSelected = ticket.ManualSelectedDate.HasValue,
                                      IsRandomSelected = ticket.RandomSelectedDate.HasValue,
                                      IsApproveWinner = ticket.ApproveWinnerDate.HasValue
                                  }).ToList();
                    
                    allowSelectTicket = (from ticket in allTicketUnSelected
                                         let account = dctx.Accounts.FirstOrDefault(it => it.Id == ticket.AccountId)
                                        select new TicketInformation
                                        {
                                            Id = ticket.Id,
                                            DisplayName = account.VerifiedPhoneNumber,
                                            IsManualSelected = ticket.ManualSelectedDate.HasValue,
                                            IsRandomSelected = ticket.RandomSelectedDate.HasValue
                                        }).ToList();
                }
                
                 

                return new GetSelectedTicketRespond()
                {
                    RewardRemainingAmount = rewardRemainingAmount,
                    TicketAmount = ticketAmount,
                    SelectedTicket = ticketInfo,
                    AllTicket = allowSelectTicket,
                };
            }
        }

        public void SelectTicket(int rewardId, int ticketId, DateTime selectedDate)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedTicket = dctx.Tickets.FirstOrDefault(it => it.Id == ticketId);
                selectedTicket.ManualSelectedDate = selectedDate;
                selectedTicket.SelectedRewardId = rewardId;
                dctx.SaveChanges();
            }
        }

        public void CancelSelectedTicket(int rewardId, int ticketId)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedTicket = dctx.Tickets.FirstOrDefault(it => it.Id == ticketId);
                selectedTicket.ManualSelectedDate = null;
                selectedTicket.RandomSelectedDate = null;
                selectedTicket.SelectedRewardId = null;
                dctx.SaveChanges();
            }
        }

        public void SubmitSelectedWinner(int rewardId, DateTime approveDate)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                const int RequiredVerificationDigits = 10;
                var verificationCode = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, RequiredVerificationDigits).ToUpper();
                var rewardInfo = dctx.Tickets.Where(it => it.SelectedRewardId.HasValue);
                if (rewardInfo != null)
                {
                    rewardInfo.ToList().ForEach(it => {
                        var selectedTicket = dctx.Tickets.FirstOrDefault(ticket => ticket.Id == it.Id);
                        var accountInfo = dctx.Accounts.FirstOrDefault(account => account.Id == selectedTicket.AccountId);
                        selectedTicket.ApproveWinnerDate = approveDate;
                        dctx.Winners.Add(new Winner
                        {
                            AccountId = accountInfo.Id,
                            RewardId = rewardId,
                            ReferenceCode = verificationCode
                        });
                        dctx.SaveChanges();
                    });
                } 
            }
        }
    }
}

using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class TicketFacade
    {
        public BuyTicketRespond BuyTicket(BuyTicketRequest request, DateTime currentDate)
        {
            var invalidDataModel = new BuyTicketRespond { IsSuccessed = false };

            var areArgumentValid = request != null && !string.IsNullOrEmpty(request.UserId);
            if (!areArgumentValid) return invalidDataModel;

            var selectedAccount = FacadeRepository.Instance.AccountDataAccess.GetAccountBySecrectCode(request.UserId);
            if (selectedAccount == null) return invalidDataModel;
            invalidDataModel.AccountInfo = selectedAccount;

            var MinimumBuyTicketRequest = 1;
            var isRequestAmountValid = request.Amount >= MinimumBuyTicketRequest;
            if (!isRequestAmountValid) return invalidDataModel;

            var rewardDac = FacadeRepository.Instance.RewardDataAccess;
            var currentRewardGroup = rewardDac.GetRewardGroup()
                .OrderByDescending(it => it.ExpiredDate)
                .FirstOrDefault();
            if (currentRewardGroup == null) return invalidDataModel;
            invalidDataModel.RewardResultDate = currentRewardGroup.ExpiredDate;

            var isCurrentRewardAvailableForBuy = currentRewardGroup.RewardInfo.Any() && currentRewardGroup.ExpiredDate.Date > currentDate.Date;
            if (!isCurrentRewardAvailableForBuy) return invalidDataModel;

            var requiredPoints = currentRewardGroup.RequestPoints * request.Amount;
            var isNeedReachMinimumRequirement = selectedAccount.Points >= requiredPoints;
            if (!isNeedReachMinimumRequirement) return invalidDataModel;

            FacadeRepository.Instance.TicketDataAccess.BuyTicket(request.UserId, request.Amount, currentRewardGroup.Id);
            FacadeRepository.Instance.AccountDataAccess.ChargeFromBuyTicket(request.UserId, requiredPoints);

            selectedAccount.Points -= requiredPoints;
            selectedAccount.CurrentOrderedCoupon += request.Amount;
            return new BuyTicketRespond
            {
                AccountInfo = selectedAccount,
                IsSuccessed = true,
                RewardResultDate = currentRewardGroup.ExpiredDate
            };
        }
    }
}

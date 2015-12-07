using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class RewardFacade
    {
        public IEnumerable<RewardGroupInformation> GetRewardGroup()
        {
            var rewardDac = FacadeRepository.Instance.RewardDataAccess;
            return rewardDac.GetRewardGroup();
        }

        public RewardGroupInformation GetRewardGroupById(int id)
        {
            var rewardDac = FacadeRepository.Instance.RewardDataAccess;
            return rewardDac.GetRewardGroupById(id);
        }

        public GetCurrentWinnersRespond GetCurrentWinners(DateTime currentTime)
        {
            var rewardDac = FacadeRepository.Instance.RewardDataAccess;
            var selectedRewardGroup = rewardDac.GetRewardGroup()
                .Where(it => it.ExpiredDate.HasValue)
                .OrderByDescending(it => it.ExpiredDate)
                .FirstOrDefault();

            var invalidDataModel = new GetCurrentWinnersRespond { Winners = Enumerable.Empty<WinnerAwardInformation>() };
            if (selectedRewardGroup == null) return invalidDataModel;

            int ordering = 1;
            var result = selectedRewardGroup.RewardInfo.Select(reward =>
            {
                var winnerNames = rewardDac.GetAllWinners()
                        .Where(it => it.RewardId == reward.Id)
                        .Select(it => it.AccountFullName);

                return new WinnerAwardInformation
                {
                    Description = reward.Description,
                    ImagePath = reward.ImagePath,
                    Ordering = ordering++, // HACK: Reward ordering
                    Winners = winnerNames
                };
            }).ToList();

            return new GetCurrentWinnersRespond
            {
                Winners = result
            };
        }

        public GetYourRewardsRespond GetYourRewards(GetYourRewardsRequest request)
        {
            var invalidDataModel = new GetYourRewardsRespond
            {
                ContactNo = string.Empty,
                AllRewards = Enumerable.Empty<YourRewardInformation>(),
                CurrentRewards = Enumerable.Empty<YourRewardInformation>()
            };
            var isArgumentValid = request != null && !string.IsNullOrEmpty(request.UserId);
            if (!isArgumentValid) return invalidDataModel;

            var allWinRewards = FacadeRepository.Instance.RewardDataAccess.GetWinnersByUserId(request.UserId);
            var allRewards = FacadeRepository.Instance.RewardDataAccess.GetRewardsByIds(allWinRewards.Select(it => it.RewardId));

            var currentRewardGroup = FacadeRepository.Instance.RewardDataAccess.GetRewardGroup().Where(it => it.ExpiredDate.HasValue).OrderByDescending(it => it.ExpiredDate).FirstOrDefault();
            if (currentRewardGroup == null) return invalidDataModel;

            var currentRewardQry = allRewards.Where(it => it.RewardGroupId == currentRewardGroup.Id);
            var otherRewardQry = allRewards.Except(currentRewardQry);

            int ordering = 1;
            var currentRewards = convertToYourReward(currentRewardQry, allWinRewards, currentRewardGroup.ExpiredDate.Value, ref ordering).Where(it => it != null);
            var otherRewards = convertToYourReward(otherRewardQry, allWinRewards, currentRewardGroup.ExpiredDate.Value, ref ordering).Where(it => it != null);

            return new GetYourRewardsRespond
            {
                ContactNo = "123-456-789", // HACK: Contact No
                CurrentRewards = currentRewards,
                AllRewards = otherRewards
            };
        }
        private IEnumerable<YourRewardInformation> convertToYourReward(IEnumerable<RewardInformation> rewards, IEnumerable<WinnerInformation> winners, DateTime expiredDate, ref int ordering)
        {
            var running = ordering;
            var result = rewards.Select(x =>
            {
                var selectedWinReward = winners.FirstOrDefault(it => x.Id == it.RewardId);
                if (selectedWinReward == null) return null;
                return new YourRewardInformation
                {
                    Ordering = running++, // HACK: Ordering
                    Description = x.Description,
                    ExpiredDate = expiredDate,
                    ImagePath = x.ImagePath,
                    ReferenceCode = selectedWinReward.ReferenceCode
                };
            });
            ordering = running;
            return result;
        }

        public void CreateRewardGroup(RewardGroupInformation model)
        {
            var rewardDac = FacadeRepository.Instance.RewardDataAccess;
            rewardDac.CreateRewardGroup(model);
        }

        public void CreateReward(RewardInformation model)
        {
            var rewardDac = FacadeRepository.Instance.RewardDataAccess;
            rewardDac.CreateReward(model);
        }
    }
}

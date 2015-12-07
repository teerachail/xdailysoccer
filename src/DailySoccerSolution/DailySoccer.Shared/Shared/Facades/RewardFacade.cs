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
            // TODO: GetYourRewards
            throw new NotImplementedException();
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

using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.DAC
{
    public interface IRewardDataAccess
    {
        IEnumerable<RewardGroupInformation> GetRewardGroup();
        RewardInformation GetRewardsById(int id);
        RewardGroupInformation GetRewardGroupById(int id);
        void CreateRewardGroup(RewardGroupInformation model);
        void EditRewardGroup(int id, RewardGroupInformation model);
        void DeleteRewardGroup(int id);
        void CreateReward(RewardInformation model);
        IEnumerable<WinnerInformation> GetAllWinners();
        IEnumerable<WinnerInformation> GetWinnersByUserId(string userId);
        IEnumerable<RewardInformation> GetRewardsByIds(IEnumerable<int> ids);
    }
}

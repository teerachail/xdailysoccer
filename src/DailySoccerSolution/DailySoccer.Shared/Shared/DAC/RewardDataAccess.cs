using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailySoccer.Shared.Models;

namespace DailySoccer.Shared.DAC
{
    class RewardDataAccess : IRewardDataAccess
    {
        public IEnumerable<RewardGroupInformation> GetRewardGroup()
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var qry = dctx.RewardGroups.Select(it => new RewardGroupInformation
                {
                    Id = it.Id,
                    RequestPoints = it.RequestPoints,
                    ExpiredDate = it.ExpiredDate,
                    RewardInfo = it.Rewards.Select(reward => new RewardInformation
                    {
                        Id = reward.Id,
                        Name = reward.Name,
                        Description = reward.Description,
                        Amount = reward.Amount,
                        ImagePath = reward.ImagePath,
                        RewardGroupId = reward.RewardGroupId
                    })
                }).ToList();

                return qry;
            }
        }

        public RewardGroupInformation GetRewardGroupById(int id)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var qry = dctx.RewardGroups.FirstOrDefault(it => it.Id == id);

                return new RewardGroupInformation
                {
                    Id = qry.Id,
                    RequestPoints = qry.RequestPoints,
                    ExpiredDate  = qry.ExpiredDate,
                    RewardInfo = qry.Rewards.Select(reward => new RewardInformation
                    {
                        Id = reward.Id,
                        Name = reward.Name,
                        Description = reward.Description,
                        Amount = reward.Amount,
                        ImagePath = reward.ImagePath,
                        RewardGroupId = reward.RewardGroupId
                    })
                };
            }
        }
    }
}

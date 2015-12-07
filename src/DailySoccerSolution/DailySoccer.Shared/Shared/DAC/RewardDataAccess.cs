using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailySoccer.Shared.Models;
using DailySoccer.DAC.EF;

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
                        ThumbnailPath = reward.ThumbnailPath,
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
                    ExpiredDate = qry.ExpiredDate,
                    RewardInfo = qry.Rewards.Select(reward => new RewardInformation
                    {
                        Id = reward.Id,
                        Name = reward.Name,
                        Description = reward.Description,
                        Amount = reward.Amount,
                        ImagePath = reward.ImagePath,
                        ThumbnailPath = reward.ThumbnailPath,
                        RewardGroupId = reward.RewardGroupId,
                    })
                };
            }
        }

        public void CreateRewardGroup(RewardGroupInformation model)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                dctx.RewardGroups.Add(new RewardGroup
                {
                    Id = model.Id,
                    RequestPoints = model.RequestPoints,
                    ExpiredDate = model.ExpiredDate.Value
                });
                dctx.SaveChanges();
            }
        }

        public IEnumerable<WinnerInformation> GetAllWinners()
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                return dctx.Winners.Select(it => new WinnerInformation
                {
                    Id = it.Id,
                    AccountSecrectCode = it.Account.SecrectCode,
                    ReferenceCode = it.ReferenceCode,
                    RewardId = it.RewardId
                }).ToList();
            }
        }

        public void EditRewardGroup(int id, RewardGroupInformation model)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var qry = dctx.RewardGroups.FirstOrDefault(it => it.Id == model.Id);
                qry.Id = model.Id;
                qry.RequestPoints = model.RequestPoints;
                qry.ExpiredDate = model.ExpiredDate.Value;

                dctx.SaveChanges();
            }
        }

        public void DeleteRewardGroup(int id)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var qry = dctx.RewardGroups.FirstOrDefault(it => it.Id == id);
                dctx.RewardGroups.Remove(qry);
                dctx.SaveChanges();
            }
        }

        public void CreateReward(RewardInformation model)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                dctx.Rewards.Add(new Reward
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Amount = model.Amount,
                    RemainingAmount = model.Amount,
                    ImagePath = model.ImagePath,
                    ThumbnailPath = model.ThumbnailPath,
                    RewardGroupId = model.RewardGroupId,
                });
                dctx.SaveChanges();
            }
        }
    }
}

module starter.reward {
    'use strict';

    export class RewardServices implements IRewardService {
        static $inject = ['starter.shared.QueryRemoteDataService'];
        constructor(private queryRemoteSvc: starter.shared.QueryRemoteDataService) {
        }

        public GetCurrentRewards(): ng.IPromise<GetCurrentRewardsRespond> {
            var requestUrl = 'Reward/GetCurrentRewards';
            return this.queryRemoteSvc.RemoteQuery<GetCurrentRewardsRespond>(requestUrl);
        }
        public GetCurrentWinners(): ng.IPromise<GetCurrentWinnersRespond> {
            var requestUrl = 'Reward/GetCurrentWinners';
            return this.queryRemoteSvc.RemoteQuery<GetCurrentWinnersRespond>(requestUrl);
        }

        public GetYourRewards(req: GetYourRewardsRequest): ng.IPromise<GetYourRewardsRespond> {
            var requestUrl = 'Reward/GetYourRewards?userId=' + req.UserId;
            return this.queryRemoteSvc.RemoteQuery<GetYourRewardsRespond>(requestUrl);
        }
    }

    angular
        .module('starter.reward')
        .service('starter.reward.RewardServices', RewardServices);
}

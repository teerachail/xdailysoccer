module starter.reward {
    'use strict';

    export class RewardServices implements IRewardService {
        static $inject = ['starter.shared.QueryRemoteDataService'];
        constructor(private queryRemoteSvc: starter.shared.QueryRemoteDataService) {
        }

        public GetCurrentRewards(): ng.IPromise<GetCurrentRewardsRespond> {
            var requestUrl = 'Reward';
            return this.queryRemoteSvc.RemoteQuery<GetCurrentRewardsRespond>(requestUrl);
        }
    }
    
    

    angular
        .module('starter.reward')
        .service('starter.reward.RewardServices', RewardServices);
}

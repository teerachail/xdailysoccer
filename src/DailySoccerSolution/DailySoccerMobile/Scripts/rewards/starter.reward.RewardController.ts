module starter.reward {
    'use strict';

    class RewardController {

        public CurrentOrderedCoupon: number = 2940;
        public UserCoupon: number = 0;
        public RewardInfo: reward.GetCurrentRewardsRespond;

        
        static $inject = ['$scope', 'starter.reward.RewardServices'];
        constructor(private $scope,
            private rewardSvc: starter.reward.RewardServices) {
            this.GetRewards();
        }

        public GetRewards(): void {
            this.rewardSvc.GetCurrentRewards()
                .then((respond: GetCurrentRewardsRespond): void => {
                    this.RewardInfo = respond;
                    console.log('Get all rewards completed.');
                });
        }
    }

    angular
        .module('starter.reward', [])
        .controller('starter.reward.RewardController', RewardController);
}
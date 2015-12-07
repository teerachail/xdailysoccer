module starter.reward {
    'use strict';

    class RewardController {

        public CurrentOrderedCoupon: number = 2940;
        public UserCoupon: number = 0;
        public RewardInfo: reward.GetCurrentRewardsRespond;
        public CurrentRewards: YourRewardInformation[];
        public AllRewards: YourRewardInformation[];
        public ContactNo: string;
        
        static $inject = ['$scope', 'starter.reward.RewardServices'];
        constructor(private $scope,
            private rewardSvc: starter.reward.RewardServices) {
            this.GetRewards();
            this.updateDisplayRewards();
        }

        public GetRewards(): void {
            this.rewardSvc.GetCurrentRewards()
                .then((respond: GetCurrentRewardsRespond): void => {
                    this.RewardInfo = respond;
                    console.log('Get all rewards completed.');
                });
        }

        private updateDisplayRewards() {
            var user = Ionic.User.current();
            var getYourRewardsRequest = new GetYourRewardsRequest();
            getYourRewardsRequest.UserId = user.id;
            this.rewardSvc.GetYourRewards(getYourRewardsRequest)
                .then((respond: GetYourRewardsRespond): void => {
                    this.ContactNo = respond.ContactNo;
                    this.CurrentRewards = respond.CurrentRewards;
                    this.AllRewards = respond.AllRewards;
                    console.log('# update display rewards completed.');
                });
        }
    }

    angular
        .module('starter.reward', [])
        .controller('starter.reward.RewardController', RewardController);
}
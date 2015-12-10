module starter.reward {
    'use strict';

    class RewardController {

        //public CurrentOrderedCoupon: number = 2940;
        //public UserCoupon: number = 0;
        public RewardInfo: reward.GetCurrentRewardsRespond;
        public WinnersInfo: reward.GetCurrentWinnersRespond;

        public CurrentRewards: YourRewardInformation[];
        public AllRewards: YourRewardInformation[];
        public ContactNo: string;
        
        static $inject = ['$scope', 'starter.reward.RewardServices', 'starter.shared.AccountManagementService'];
        constructor(private $scope, private rewardSvc: starter.reward.RewardServices, private accountManagementSvc: shared.AccountManagementService) {
            this.GetRewards();
            this.GetWinners();
            this.updateDisplayRewards();
        }

        public GetRewards(): void {
            this.rewardSvc.GetCurrentRewards()
                .then((respond: GetCurrentRewardsRespond): void => {
                    this.RewardInfo = respond;
                    this.accountManagementSvc.CurrentTicketCost = respond.TicketCost;
                    console.log('Get all rewards completed.');
                });
        }

        public GetWinners(): void {
            this.rewardSvc.GetCurrentWinners()
                .then((respond: GetCurrentWinnersRespond): void => {
                    this.WinnersInfo = respond;
                    console.log('Get all winners completed.');
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